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
    /// OperatorEditiUI.xaml 的交互逻辑
    /// </summary>
    public partial class OperatorEditiUI : Window
    {
        public OperatorEditiUI()
        {
            InitializeComponent();
        }

        public bool IsInsert { get; set; }
        public Guid EditingId { get; set; }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (IsInsert)
            {
                Operator op = new Operator();
                op.RealName = txtRealName.Text;
                op.UserName = txtUserName.Text;
                op.Password = CommonHelper.GetMD5(pwdPassword.Password+CommonHelper.GetPasswordSalt());
                new OperatorDAL().Insert(op);

                Guid operatorId = CommonHelper.GetOperatorId();
                new T_OperationLogDAL().Insert(operatorId, "新增操作员" + txtUserName.Text);

                DialogResult = true;
            }
            else
            {
                string pwd = pwdPassword.Password;
                if (pwd.Length <= 0)//编辑的时候如果密码为空，则保留现有密码不动
                {
                    //new OperatorDAL().Update(EditingId, 
                    //    txtUserName.Text, txtRealName.Text);
                    new OperatorDAL().Update(EditingId,
                        null, txtRealName.Text);
                }
                else//如果密码不为空，则把密码重置为用户输入的密码
                {
                    string pwdMd5 = CommonHelper.GetMD5(pwd + CommonHelper.GetPasswordSalt());
                    new OperatorDAL().Update(EditingId,
                        txtUserName.Text, txtRealName.Text, pwdMd5);
                    
                }
                Guid operatorId = CommonHelper.GetOperatorId();
                new T_OperationLogDAL().Insert(operatorId, "修改操作员" + txtUserName.Text);
                DialogResult = true;
            }           
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsInsert)
            {
            }
            else
            {
                OperatorDAL dal = new OperatorDAL();
                Operator op = dal.GetById(EditingId);
                txtUserName.Text = op.UserName;
                txtRealName.Text = op.RealName;
            }
        }

    }
}
