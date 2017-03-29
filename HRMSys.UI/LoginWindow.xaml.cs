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
using System.Security.Cryptography;
using HRMSys.Model;
using HRMSys.DAL;

namespace HRMSys.UI
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text;
            string pwd = pwdPassword.Password;

            Operator op = new OperatorDAL().GetByUserName(username);
            if (op == null)
            {
                MessageBox.Show("用户名或者密码错误！");
            }
            else
            {
                string dbMd5 = op.Password; //数据库中存储的密码值
                string mymd5 = CommonHelper.GetMD5(pwd +CommonHelper.GetPasswordSalt());
                if (dbMd5 == mymd5)
                {
                    new T_OperationLogDAL().Insert(op.Id, "登录成功");
                    //MessageBox.Show("登录成功");

                    //把登录操作者的Id保存到全局的“Session”
                    //存到Application.Current.Properties里面的在程序其他地方也可以取
                    Application.Current.Properties["OperatorId"] = op.Id;
                    DialogResult = true;
                }
                else
                {
                    new T_OperationLogDAL().Insert(op.Id, "尝试登录失败");
                    MessageBox.Show("用户名或者密码错误！");
                }
            }
        }

        public static string GetMD5(string sDataIn)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
