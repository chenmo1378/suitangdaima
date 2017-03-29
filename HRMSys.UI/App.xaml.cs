using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace HRMSys.UI
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //在Application_DispatcherUnhandledException中集中处理异常
            MessageBox.Show("程序中出现了严重错误，请联系系统开发商！"+e.Exception.Message);
            e.Handled = true;
        }
    }
}
