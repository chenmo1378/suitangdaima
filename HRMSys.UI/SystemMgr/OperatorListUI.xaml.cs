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

namespace HRMSys.UI.SystemMgr
{
    /// <summary>
    /// OperatorListUI.xaml 的交互逻辑
    /// </summary>
    public partial class OperatorListUI : Window
    {
        public OperatorListUI()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            OperatorEditiUI editUI = new OperatorEditiUI();
            editUI.IsInsert = true;
            if (editUI.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            OperatorDAL dal = new OperatorDAL();
            gridOperators.ItemsSource = dal.ListAll();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Operator op = (Operator)gridOperators.SelectedItem;
            if (op == null)
            {
                MessageBox.Show("没有选中任何行！");
                return;
            }

            OperatorEditiUI editUI = new OperatorEditiUI();
            editUI.IsInsert = false;
            editUI.EditingId = op.Id;
            if (editUI.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Operator op = (Operator)gridOperators.SelectedItem;
            if (op == null)
            {
                MessageBox.Show("没有选中任何行！");
                return;
            }
            if (MessageBox.Show("真的要删除" + op.UserName + "吗？", "提醒",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                OperatorDAL dal = new OperatorDAL();
                dal.DeleteById(op.Id);//软删除

                Guid operatorId = CommonHelper.GetOperatorId();
                new T_OperationLogDAL().Insert(operatorId, "删除管理员" + op.UserName);
                LoadData();
            }            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
