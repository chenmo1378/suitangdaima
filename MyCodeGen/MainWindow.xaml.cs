using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace MyCodeGen
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private DataTable ExecuteDataTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(txtConnStr.Text))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //只获得表的架构信息（列信息）
                    cmd.CommandText =sql;
                    DataSet ds = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.FillSchema(ds, SchemaType.Source);//获得表信息必须要写
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }



        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            DataTable table;
            try
            {
               table = ExecuteDataTable(@"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_TYPE = 'BASE TABLE'");
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("连接数据库出错！错误消息："+sqlex.Message);
                return;
            }
            string[] tables = new string[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                tables[i] = (string)row["TABLE_NAME"];
            }
            cmbTables.ItemsSource = tables;
            cmbTables.IsEnabled = true;
            btnGenerateCode.IsEnabled = true;

            //把连接字符串记录到文件中，避免用户每次都需要输入连接字符串
            //File.WriteAllText("connstr.txt", txtConnStr.Text);
            //AppDomain.CurrentDomain.BaseDirectory//获得当前程序的文件夹，最稳定
            //string configFile = currenctDir + "connstr.txt";
            string configFile = GetConfigFilePath();
            File.WriteAllText(configFile, txtConnStr.Text);

            //除非真的有捕获异常的需要，否则不要try...catch
        }

        private static string GetConfigFilePath()
        {
            string currenctDir = AppDomain.CurrentDomain.BaseDirectory;
            string configFile = System.IO.Path.Combine(currenctDir, "connstr.txt");
            return configFile;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string configFile = GetConfigFilePath();
            txtConnStr.Text = File.ReadAllText(configFile);
        }

        private void btnGenerateCode_Click(object sender, RoutedEventArgs e)
        {
            string tablename = (string)cmbTables.SelectedItem;
            if (tablename == null)
            {
                MessageBox.Show("请选择要生成的表");
                return;
            }
            CreateModelCode(tablename);
            CreateDALCode(tablename);
        }

        private void CreateModelCode(string tablename)
        {
            //bool b = true;//bool和System.Boolean是同一个东西
            //System.Boolean b1 = true;//CTS
            //System.String s1 = "";
            //string s2 = "";    

            DataTable table = ExecuteDataTable("select top 0 * from "
                +tablename);
            StringBuilder sb = new StringBuilder();
            sb.Append("public class ").Append(tablename).AppendLine("{");
            foreach (DataColumn column in table.Columns)
            {
                string columnDataType = GetDataTypeName(column);
                sb.Append("public ").Append(columnDataType).Append(" ")
                    .Append(column.ColumnName).AppendLine("{get;set;}");
            }
            sb.AppendLine("}");
            txtModelCode.Text = sb.ToString();
        }

        //进行可空类型的处理
        private static string GetDataTypeName(DataColumn column)
        {
            //如果列允许为null，并且列在C#中的类型是不可为空的（值类型ValueType）
            if (column.AllowDBNull && column.DataType.IsValueType)
            {
                return column.DataType + "?";
            }
            else
            {
                return column.DataType.ToString();
            }
        }

        private void CreateDALCode(string tablename)
        {
            DataTable table = ExecuteDataTable("select top 0 * from "
                + tablename);
            StringBuilder sb = new StringBuilder();
            sb.Append("public class ").Append(tablename).Append("DAL {");
            
            //tomodel开始
            sb.Append("private ").Append(tablename)
                .AppendLine(" ToModel(DataRow row){");
            sb.Append(tablename).AppendLine(" model = new " + tablename + "();");
            foreach (DataColumn column in table.Columns)
            {
                //无论列是否允许为空，都进行判断DbNull的处理（省事）
                //model.Id = (Guid)SqlHelper.FromDbValue(row["Id"]);
                sb.Append("model.").Append(column.ColumnName).Append("=(")
                    .Append(GetDataTypeName(column)).Append(")SqlHelper.FromDbValue(row[\"")
                   .Append(column.ColumnName) .AppendLine("\"]);");
            }
            sb.AppendLine("return model;");
            sb.AppendLine("}");
            //tomodel的结束
            
            //listall开始
            //public IEnumerable<Department> ListAll()
            sb.Append("public IEnumerable<").Append(table)
                .AppendLine("> ListAll(){");
            //List<Department> list = new List<Department>();
            sb.Append("List<").Append(tablename).Append("> list=new List<")
                .Append(tablename).AppendLine(">();");
            // DataTable dt = SqlHelper.ExecuteDataTable
            //("select * from T_Department");
            sb.Append("DataTable dt = SqlHelper.ExecuteDataTable(\"")
                .Append("select * from "+tablename).AppendLine("\");");
            sb.AppendLine("foreach (DataRow row in dt.Rows)");
            //Department dept = ToModel(row);
            sb.Append(tablename).AppendLine(" model=ToModel(row);");
            //list.Add(model);
            sb.AppendLine("list.Add(model);}");

            sb.AppendLine("}");
            //listall结束

            //GetById();
            //DeleteById();

            //生成器要求列名必须是Id，类型必须是Guid

            //Insert开始
            //public void Insert(Operator op)
            sb.Append("public void Insert(")
                .Append(tablename).AppendLine(" model){");
            //SqlHelper.ExecuteNonQuery(@"insert into T_Operator(
            sb.Append("SqlHelper.ExecuteNonQuery(@\"")
                .Append("insert into ").Append(tablename).AppendLine("(");
            string[] colNames = GetColumnNames(table);
            sb.AppendLine(string.Join(",",colNames));
            string[] colParamNames = GetParamColumnNames(table);
            sb.Append("values(").AppendLine(string.Join(",", colParamNames));
            sb.AppendLine("}");
            //Insert结束

            sb.AppendLine("}");
            txtDALCode.Text = sb.ToString();
        }

        //以数组形式返回列名
        private static string[] GetColumnNames(DataTable table)
        {
            string[] colnames = new string[table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
            {
                DataColumn dataCol = table.Columns[i];
                colnames[i] = dataCol.ColumnName;
            }
            return colnames;
        }

        //以数组形式返回@列名
        private static string[] GetParamColumnNames(DataTable table)
        {
            string[] colnames = new string[table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
            {
                DataColumn dataCol = table.Columns[i];
                colnames[i] = "@"+dataCol.ColumnName;
            }
            return colnames;
        }
    }
}
