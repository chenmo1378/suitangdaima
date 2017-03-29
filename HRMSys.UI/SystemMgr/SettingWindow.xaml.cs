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

namespace HRMSys.UI.SystemMgr
{
    /// <summary>
    /// SettingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SettingDAL dal = new SettingDAL();
            dal.SetValue("公司名称",txtCompanyName.Text);
            dal.SetValue("公司网站",txtCompanySite.Text);
            dal.SetValue("启用生日提醒",(bool)cbBirthDayPrompt.IsChecked);
            dal.SetValue("生日提醒天数",txtBirthDayDays.Text);
            dal.SetValue("员工工号前缀",txtEmployeeNumberPrefix.Text);

            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingDAL dal = new SettingDAL();
            txtCompanyName.Text = dal.GetValue("公司名称");
            txtCompanySite.Text = dal.GetValue("公司网站");
            cbBirthDayPrompt.IsChecked = dal.GetBoolValue("启用生日提醒");
            txtBirthDayDays.Text = dal.GetValue("生日提醒天数");
            txtEmployeeNumberPrefix.Text = dal.GetValue("员工工号前缀");
        }
    }
}
