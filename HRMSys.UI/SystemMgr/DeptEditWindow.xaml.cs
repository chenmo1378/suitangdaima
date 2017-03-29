using System;
using System.Collections.Generic;
using System.Data;
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
using HRMSys.UI;
using HRMSys.DAL;
using HRMSys.Model;

namespace HRMSys.SystemMgr
{
    /// <summary>
    /// DeptEditWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DeptEditWindow : Window
    {
        public DeptEditWindow()
        {
            InitializeComponent();
        }

        public bool IsAddNew { get; set; }

        public Guid EditingId{get;set;}

        private void txtSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            if (string.IsNullOrEmpty(name))
            {
                CommonHelper.ShowError("部门名称不能为空！");
                return;
            }

            if (IsAddNew)
            {
                new DepartmentDAL().Insert(name);
            }
            else
            {
                new DepartmentDAL().Update(EditingId,name);
            }
            DialogResult = true;
        }

        private void txtCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (!IsAddNew)
            {
                Department dept = new DepartmentDAL().GetById(EditingId);
                txtName.Text = dept.Name;
            }

            txtName.Focus();
        }
    }
}
