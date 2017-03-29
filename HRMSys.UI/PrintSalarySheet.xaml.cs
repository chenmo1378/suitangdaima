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
using System.Windows.Shapes;
using HRMSys.DAL;
using HRMSys.Model;

namespace HRMSys.UI
{
    /// <summary>
    /// PrintSalarySheet.xaml 的交互逻辑
    /// </summary>
    public partial class PrintSalarySheet : Window
    {
        public PrintSalarySheet()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            int year = Convert.ToInt32(txtYear.Text);
            int month = Convert.ToInt32(txtMonth.Text);
            Guid deptId = (Guid)cmbDepts.SelectedValue;
            SalarySheetDAL sheetDAL = new SalarySheetDAL();
            if (sheetDAL.IsExists(year, month, deptId) == false)
            {
                MessageBox.Show("还未生成工资！");
                return;
            }
            SalarySheetItem[] items =
                sheetDAL.GetSalarySheetItems(year, month, deptId);
            SalarySheetItemRpt[] rptItems = new SalarySheetItemRpt[items.Length];
            for (int i = 0; i < items.Length;i++ )
            {
                SalarySheetItem item = items[i];
                SalarySheetItemRpt rptItem = new SalarySheetItemRpt();
                rptItem.BaseSalary = item.BaseSalary;
                rptItem.Bonus = item.Bonus;
                rptItem.Fine = item.Fine;
                rptItem.Other = item.Other;
                //select emp.Name join T_employee

                rptItem.EmployeeName = 
                    new EmployeeDAL().GetById(item.EmployeeId).Name;
                rptItems[i] = rptItem;
            }

            SalarySheetReport report = new SalarySheetReport();
            report.SetDataSource(rptItems);
            report.SetParameterValue("年",year);
            report.SetParameterValue("月", month);
            report.SetParameterValue("部门名称", cmbDepts.Text);

            reportsViewerItems.ViewerCore.ReportSource = report;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbDepts.ItemsSource = new DepartmentDAL().ListAll();
        }
    }
}
