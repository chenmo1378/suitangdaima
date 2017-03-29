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
    /// ReportTest1Window.xaml 的交互逻辑
    /// </summary>
    public partial class ReportTest1Window : Window
    {
        public ReportTest1Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OperatorDAL dal = new OperatorDAL();
            Operator[] operators = dal.ListAll();

            ReportOperator[] rptOperators = 
                new ReportOperator[operators.Length];
            for (int i = 0; i < rptOperators.Length; i++)
            {
                ReportOperator rptOp = new ReportOperator();
                rptOp.RealName = operators[i].RealName;
                rptOp.UserName = operators[i].UserName;
                rptOperators[i] = rptOp;
            }

            TestCrystalReport1 rpt = new TestCrystalReport1();
            rpt.SetDataSource(rptOperators);
            rpt.SetParameterValue("部门名称","产品开发部");

            crystalReportsViewer1.ViewerCore.ReportSource = rpt;
            //设计rpt报表，从BLL层取数据，扔给rpt实例，然后通过crystalReportsViewer展示
        }
    }
}
