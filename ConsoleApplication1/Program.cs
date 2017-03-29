using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> list = new List<string>();
            //list.Add("333");
            //list.Add("阿法士大夫");
            //list.Add("23233232");
            //list.Add("fasdfasfads");

            //string s = string.Join(" and ", list);
            //Console.WriteLine(s);

            //dynamic excel = Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application", string.Empty);
            ////excel.Visible = true;
            //excel.workbooks.Add();
                 
            //dynamic sheet = excel.ActiveSheet;

            //dynamic headerCell = sheet.Cells[0, 0];
            ////把当前Grid中表头信息赋值给Excel表头.
            //headerCell.Value = "你好";
            //headerCell.Font.Bold = true;//加粗
            //headerCell.Interior.Color = 0xFF00;//设置背景颜色
 
           //Workbook工作簿，Sheet页，row行，cell：单元格

//            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
//            ISheet sheet1 = hssfworkbook.CreateSheet("俺的第一页");
//            IRow rowHeader = sheet1.CreateRow(0);//第i行
//            rowHeader.CreateCell(0, CellType.STRING).SetCellValue("传智播客");
////xls,xlsx
//            IRow row2 = sheet1.CreateRow(1);
//            row2.CreateCell(3, CellType.STRING).SetCellValue("fasdfasdfas");

//            using (Stream stream = File.OpenWrite("d:/1.xls"))
//            {
//                hssfworkbook.Write(stream);
//            }
            //hssfworkbook.Write(

           //using( Stream stream = File.OpenRead("d:/1.xls"))
           //{
           //    HSSFWorkbook workbook = new HSSFWorkbook(stream);
           //    workbook.GetSheetAt(0).GetRow(0).GetCell(1).StringCellValue;
           //}            

            //using (SqlConnection conn = new SqlConnection("Data Source=.; Initial Catalog=HRMSYSDB;User ID=hrmsa;Password=love@beijing"))
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        //只获得表的架构信息（列信息）
            //        cmd.CommandText = "select top 0 * from T_Employee";
            //        DataSet ds = new DataSet();
            //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //        adapter.FillSchema(ds,SchemaType.Source);//获得表信息必须要写
            //        adapter.Fill(ds);

            //        DataTable table = ds.Tables[0];
            //        foreach (DataColumn col in table.Columns)
            //        {
            //            Console.WriteLine(col.ColumnName+","+col.AllowDBNull+","+col.DataType);
            //        }
            //    }
            //}

            //string s1 = "aaa"+"bbb";
            //s1 = s1+"fasfdas" + "fasdfads";
            StringBuilder sb = new StringBuilder();
            sb.Append("fasdfas")
                .Append("haha").Append("dfasdfa");
            sb.Append("323232323232");
            sb.AppendLine("这是一行");
            sb.AppendLine("又一行");

            string s = sb.ToString();//取得连接后的字符串
            Console.ReadKey();
        }
    }
}
