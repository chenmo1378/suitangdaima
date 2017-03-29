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
using HRMSys.DAL;
using HRMSys.Model;
using HRMSys.UI.SystemMgr;
using HRMSys.SystemMgr;
using System.Data;

namespace HRMSys.UI
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

        private void miOperatorMgr_Click(object sender, RoutedEventArgs e)
        {
            OperatorListUI ui = new OperatorListUI();
            ui.ShowDialog();
            //string s = "123";
            //string md5 = CommonHelper.GetMD5(s + "love?P3@9");

            //Operator op = new Operator();
            //op.Password = md5;
            //op.UserName = "itcast";
            //OperatorDAL dal = new OperatorDAL();
            //dal.Insert(op);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginWindow win = new LoginWindow();
            if (win.ShowDialog() != true)
            {
                //退出程序
                Application.Current.Shutdown();
            }

            this.Title = new SettingDAL().GetValue("公司名称")+"人事管理系统";

            EmployeeDAL employeeDAL = new EmployeeDAL();
            Employee[] birthdayEmployees =
                employeeDAL.Search3DaysBirthDay();

            if (new SettingDAL().GetBoolValue("启用生日提醒"))
            {
                //检测一个月之内合同到期的员工
                if (birthdayEmployees.Length > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < birthdayEmployees.Length; i++)
                    {
                        sb.Append(birthdayEmployees[0].Name).Append(",");
                    }
                    sb.Append("三天之内过生日");
                    //MessageBox.Show(sb.ToString());
                    PopupWindow popupWin = new PopupWindow();
                    popupWin.Left = SystemParameters.WorkArea.Width - popupWin.Width;
                    popupWin.Top = SystemParameters.WorkArea.Height - popupWin.Height;
                    popupWin.Message = sb.ToString();
                    popupWin.Show();
                }
            }            
        }

        private void miDeptMgr_Click(object sender, RoutedEventArgs e)
        {
            DeptMgrWindow win = new DeptMgrWindow();
            win.ShowDialog();
        }

        private void miEmployeeMgr_Click(object sender, RoutedEventArgs e)
        {
            EmployeeListWindow win = new EmployeeListWindow();
            win.ShowDialog();
        }

        private void miViewOperationLog_Click(object sender, RoutedEventArgs e)
        {
            OperationLogWindow win = new OperationLogWindow();
            win.ShowDialog();
        }

        private void miSetting_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow win = new SettingWindow();
            win.ShowDialog();
        }

        private void miBuildSalarySheet_Click(object sender, RoutedEventArgs e)
        {
            BuildSalarySheetWindow win = new BuildSalarySheetWindow();
            win.ShowDialog();
        }

        private void miPrintSalarySheet_Click(object sender, RoutedEventArgs e)
        {
            PrintSalarySheet win = new PrintSalarySheet();
            win.ShowDialog();
        }
    }
}
