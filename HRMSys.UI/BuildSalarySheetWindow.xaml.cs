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
    /// BuildSalarySheetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BuildSalarySheetWindow : Window
    {
        public BuildSalarySheetWindow()
        {
            InitializeComponent();
        }

        private void btnCreateSalarySheet_Click(object sender, RoutedEventArgs e)
        {
            int year = (int)cmbYear.SelectedValue;
            int month = (int)cmbMonth.SelectedValue;
            Guid deptId = (Guid)cmbDept.SelectedValue;
            SalarySheetDAL dal = new SalarySheetDAL();
            if (dal.IsExists(year, month, deptId))
            {
                if (MessageBox.Show("工资单已经生成，是否重新生成？",
                    "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    dal.Clear(year, month, deptId);
                }
            }
            dal.Build(year, month, deptId);

            colEmployee.ItemsSource = new EmployeeDAL().ListByDepment(deptId);

            datagridItems.ItemsSource = new SalarySheetDAL().GetSalarySheetItems(
                year,month,deptId);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> listYears = new List<int>();
            for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year + 5; i++)
            {
                listYears.Add(i);
            }
            List<int> months = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                months.Add(i);
            }
            cmbYear.ItemsSource = listYears;
            cmbMonth.ItemsSource = months;

            cmbYear.SelectedValue = DateTime.Now.Year;
            cmbMonth.SelectedValue = DateTime.Now.Month;

            cmbDept.ItemsSource = new DepartmentDAL().ListAll();
        }

        private void datagridItems_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //Binding="{Binding BaseSalary,UpdateSourceTrigger=PropertyChanged}"
            SalarySheetItem item = (SalarySheetItem)e.Row.DataContext;
            //e.Row.DataContext修改后的数据对象
            new SalarySheetDAL().Update(item);
        }
    }
}
