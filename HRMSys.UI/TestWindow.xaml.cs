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
using WPFMediaKit.DirectShow.Controls;
using System.IO;
using HRMSys.Model;
using System.Transactions;
//using System.Transactions;

namespace HRMSys.UI
{
    /// <summary>
    /// TestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            //    DepartmentDAL deptDal = new DepartmentDAL();
            //    deptDal.Insert("aaa");
            //    deptDal.Insert("fffffffffffffffffffffffffff");
            //    test2();//嵌套事务
            //    throw new Exception();

            //    ts.Complete();
            //}

            using (TransactionScope ts = new TransactionScope())
            {
                DepartmentDAL dal = new DepartmentDAL();
                dal.Insert("测试1");

                //EmployeeDAL employeeDAl = new EmployeeDAL();
                //Employee emp = new Employee();
                //emp.
                //employeeDAl.Insert(emp);
                Operator op = new Operator();
                op.UserName = "hello";
                op.Password = "33333";
                op.RealName = "haha";
                new OperatorDAL().Insert(op);

                ts.Complete();
            }
        }

        private void test2()
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            //    DepartmentDAL deptDal = new DepartmentDAL();
            //    deptDal.Insert("嵌套事务");
            //    ts.Complete();
            //}
        }
    }
}
