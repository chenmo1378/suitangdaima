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

namespace HRMSys.UI
{
    /// <summary>
    /// PopupWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PopupWindow : Window
    {
        public PopupWindow()
        {
            InitializeComponent();
        }

        public string Message { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtMsg.Text = Message;
        }
    }
}
