using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HRMSys.DAL;
using HRMSys.Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace HRMSys.UI
{
    /// <summary>
    /// EmployeeListWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeListWindow : Window
    {
        public EmployeeListWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeEditWindow win = new EmployeeEditWindow();
            win.IsAddNew = true;
            if (win.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            datagrid.ItemsSource = new EmployeeDAL().ListAll();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            columnDepartmentId.ItemsSource = new DepartmentDAL().ListAll();
            columnEducationId.ItemsSource = new IdNameDAL().GetByCategory("学历");
            LoadData();

            cbSearchByName.IsChecked = true;
            dpInDateStart.SelectedDate = DateTime.Today.AddMonths(-1);
            dpInDateEnd.SelectedDate = DateTime.Today;

            cmbDept.ItemsSource = new DepartmentDAL().ListAll();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<string> whereList = new List<string>();
            List<SqlParameter> paramsList = new List<SqlParameter>();
            if (cbSearchByName.IsChecked==true)
            {
                whereList.Add("Name=@Name");
                paramsList.Add(new SqlParameter("@Name",txtName.Text));
            }
            if (cbSearchByInDate.IsChecked == true)
            {
                whereList.Add("InDate>=@InDateStart and InDate<=@InDateEnd");
                paramsList.Add(new SqlParameter("@InDateStart",dpInDateStart.SelectedDate));
                paramsList.Add(new SqlParameter("@InDateEnd", dpInDateEnd.SelectedDate));
            }
            if (cbSearchByDept.IsChecked == true)
            {
                whereList.Add("DepartmentId=@DepartmentId");
                paramsList.Add(new SqlParameter("@DepartmentId",cmbDept.SelectedValue));
            }

            string whereSql = string.Join(" and ", whereList);
            string sql = "select * from T_Employee";
            if (whereSql.Length > 0)
            {
                sql = sql + " where " + whereSql;
            }
            Employee[] result = new EmployeeDAL().Search(sql, paramsList);
            datagrid.ItemsSource = result;
        }

        private void btnExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sdfExport = new SaveFileDialog();
            sdfExport.Filter = "Excel文件|*.xls";
            if (sdfExport.ShowDialog() != true)
            {
                return;
            }
            string filename = sdfExport.FileName;
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("员工数据");

            IRow rowHeader = sheet.CreateRow(0);//表头行
            rowHeader.CreateCell(0, CellType.STRING).SetCellValue("姓名");
            rowHeader.CreateCell(1, CellType.STRING).SetCellValue("工号");
            rowHeader.CreateCell(2, CellType.STRING).SetCellValue("入职日期");

            //把查询结果导出到Excel
            Employee[] employees = (Employee[])datagrid.ItemsSource;
            for (int i = 0; i < employees.Length; i++)
            {
                Employee employee = employees[i];
                IRow row = sheet.CreateRow(i + 1);
                row.CreateCell(0, CellType.STRING).SetCellValue(employee.Name);
                row.CreateCell(1, CellType.STRING).SetCellValue(employee.Number);

                ICellStyle styledate = workbook.CreateCellStyle();
               IDataFormat format = workbook.CreateDataFormat();
            //格式具体有哪些请看单元格右键中的格式，有说明
               styledate.DataFormat = format.GetFormat("yyyy\"年\"m\"月\"d\"日\"");

               ICell cellInDate = row.CreateCell(2, CellType.NUMERIC);
                cellInDate.CellStyle = styledate;
                cellInDate.SetCellValue(employee.InDate);
            }

            using (Stream stream = File.OpenWrite(filename))
            {
                workbook.Write(stream);
            }
        }
    }
}
