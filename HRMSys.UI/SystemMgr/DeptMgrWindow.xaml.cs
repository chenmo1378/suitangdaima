using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using HRMSys.Model;
using HRMSys.UI;
using HRMSys.DAL;

namespace HRMSys.SystemMgr
{
    /// <summary>
    /// DeptMgrWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DeptMgrWindow : Window
    {
        public DeptMgrWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DeptEditWindow win = new DeptEditWindow();
            win.IsAddNew = true;
            if (win.ShowDialog() == true)
            {
                ReloadData();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Department dept = datagrid.SelectedItem as Department;
            if (dept == null)
            {
                CommonHelper.ShowError("没有选中任何行！");
                return;
            }
            new DepartmentDAL().DeleteById(dept.Id);
            ReloadData();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            datagrid.ItemsSource = new DepartmentDAL().ListAll();
        }

        private void datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Department dept = datagrid.SelectedItem as Department;
            if (dept != null)
            {
                DeptEditWindow win = new DeptEditWindow();
                win.IsAddNew = false;
                win.EditingId = dept.Id;
                if (win.ShowDialog() == true)
                {
                    ReloadData();
                }
            }
        }
    }
}
