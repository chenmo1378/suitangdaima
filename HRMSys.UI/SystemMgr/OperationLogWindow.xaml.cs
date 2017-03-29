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
using System.Data.SqlClient;
using HRMSys.DAL;
using HRMSys.Model;

namespace HRMSys.UI.SystemMgr
{
    /// <summary>
    /// OperationLogWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OperationLogWindow : Window
    {
        public OperationLogWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<string> whereList = new List<string>();
            List<SqlParameter> paramsList = new List<SqlParameter>();
            if (cbSearchByOperator.IsChecked==true)
            {
                if (cmbOperator.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择操作员！");
                    return;
                }
                whereList.Add("OperatorId=@OperatorId");
                paramsList.Add(new SqlParameter("@OperatorId",
                    cmbOperator.SelectedValue));
            }
            if (cbSearchByMakeDate.IsChecked == true)
            {
                //todo:非空检查
                whereList.Add("MakeDate Between @BeginDate and @EndDate");
                paramsList.Add(new SqlParameter("@BeginDate",dpBeginDate.SelectedDate));
                paramsList.Add(new SqlParameter("@EndDate", dpEndDate.SelectedDate));
            }
            if (cbSearchByAction.IsChecked == true)
            {

                //todo：全文检索：lucene.net

                whereList.Add("ActionDesc like @ActionDesc");
                paramsList.Add(new SqlParameter("@ActionDesc",
                    "%" + txtAcionDesc.Text + "%"));

                //下面写法是错误的
                //whereList.Add("ActionDesc like '%@ActionDesc%'");
                //paramsList.Add(new SqlParameter("@ActionDesc", txtAcionDesc.Text));
            }
            if (whereList.Count <= 0)
            {
                MessageBox.Show("至少选择一个查询条件");//防止查询出的结果过多
                return;
            }
            string sql = "select * from T_OperationLog where "
                + string.Join(" and ",whereList);
            T_OperationLog[] logs =
                new T_OperationLogDAL().Search(sql, paramsList.ToArray());
            datagrid.ItemsSource = logs;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Operator[] operators = new OperatorDAL().ListAll();
            cmbOperator.ItemsSource = operators;
            colOperator.ItemsSource = operators;
        }
    }
}
