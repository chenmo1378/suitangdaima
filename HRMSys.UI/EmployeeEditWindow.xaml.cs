using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HRMSys.Model;
using HRMSys.DAL;

namespace HRMSys.UI
{
    /// <summary>
    /// EmployeeEditWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeEditWindow : Window
    {
        public EmployeeEditWindow()
        {
            InitializeComponent();
        }

        public Guid EditingId { get; set; }
        public bool IsAddNew { get; set; }

        //ref,out
        private void CheckTextboxNotEmpty(ref bool isOK, 
            params TextBox[] textboxes)
        {
            foreach (TextBox txtBox in textboxes)
            {
                if (txtBox.Text.Length <= 0)
                {
                    isOK = false;
                    txtBox.Background = Brushes.Red;
                }
                else
                {
                    txtBox.Background = null;
                }
            }
        }

        private void CheckComboBoxNotEmpty(ref bool isOK,
            params ComboBox[] cmbs)
        {
            foreach (ComboBox cmb in cmbs)
            {
                if (cmb.SelectedIndex < 0)
                {
                    isOK = false;
                    cmb.Effect = new DropShadowEffect { Color=Colors.Red};
                }
                else
                {
                    cmb.Effect = null;
                }
            }
        }

        private void txtSave_Click(object sender, RoutedEventArgs e)
        {
            bool isOK = true;//数据检验是否通过

            ////判断非空字段不能为空
            //if (txtName.Text.Length <= 0)
            //{
            //    isOK = false;//投票。只能投反对票
            //    txtName.Background = Brushes.Red;//背景变成红色
            //}
            //else
            //{
            //    //发现有问题，则投反对票isOK = false;
            //    //发现自己没问题，也不能isOK = true;
            //    txtName.Background = null;//背景变成默认颜色
            //}

            //if (txtNational.Text.Length <= 0)
            //{
            //    isOK = false;
            //    txtNational.Background = Brushes.Red;//背景变成红色
            //}
            //else
            //{
            //    txtNational.Background = null;
            //}

            ////如果SelectedIndex<0则表示没有选中任何项
            //if (cbDepatment.SelectedIndex < 0)
            //{
            //    isOK = false;
            //    //让combobox变红要这样搞
            //    cbDepatment.Effect =
            //        new DropShadowEffect() { Color = Colors.Red };

            //}
            //else
            //{
            //    cbDepatment.Effect = null;
            //}

            CheckTextboxNotEmpty(ref isOK, txtName, txtNational, txtNativeAddr, txtAddr, 
                txtBaseSalary, txtTelNum, txtIdNum, txtPosition, txtNumber);
            CheckComboBoxNotEmpty(ref isOK, cbGender, cbMarriage, 
                cbPartyStatus, cbEducation, cbDepatment);

            if (!isOK)//如果没有通过数据合法性检查，则不保存
            {
                return;
            }

            if (IsAddNew)
            {
                Employee employee = (Employee)gridEmployee.DataContext;
                new EmployeeDAL().Insert(employee);

                Guid operatorId = CommonHelper.GetOperatorId();
                    new T_OperationLogDAL().Insert(operatorId, "新增职员" + employee.Name);

                }
            else
            {
                Employee employee = (Employee)gridEmployee.DataContext;
                new EmployeeDAL().Update(employee);
                Guid operatorId = CommonHelper.GetOperatorId();
                new T_OperationLogDAL().Insert(operatorId, "修改职员" + employee.Name);
            }

            DialogResult = true;
        }
        

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            IdNameDAL idNameDAL = new IdNameDAL();
            cbGender.ItemsSource = idNameDAL.GetByCategory("性别");
            cbMarriage.ItemsSource = idNameDAL.GetByCategory("婚姻状况");
            cbPartyStatus.ItemsSource = idNameDAL.GetByCategory("政治面貌");
            cbEducation.ItemsSource = idNameDAL.GetByCategory("学历");
            cbDepatment.ItemsSource = new DepartmentDAL().ListAll();

            if (IsAddNew)
            {
                Employee employee = new Employee();
                employee.InDate = DateTime.Today;//给默认值
                employee.ContractStartDay = DateTime.Today;
                employee.ContractEndDay = DateTime.Today.AddYears(1);
                employee.Nationality = "汉族";
                employee.Email = "@itcast.cn";
                //employee.Number = "YG";
                employee.Number = new SettingDAL().GetValue("员工工号前缀");
                gridEmployee.DataContext = employee;
            }
            else
            {
                Employee employee = new EmployeeDAL().GetById(EditingId);
                gridEmployee.DataContext = employee;

                if (employee.Photo != null)
                {
                    ShowImg(employee.Photo);                    
                }                
            }
        }

        private void ShowImg(byte[] imgBytes)
        {
            MemoryStream stream = new MemoryStream(imgBytes);
            BitmapImage bmpImg = new BitmapImage();
            bmpImg.BeginInit();
            bmpImg.StreamSource = stream;
            bmpImg.EndInit();
            imgPhoto.Source = bmpImg;
        }

        private void btnChoosePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdPhoto = new OpenFileDialog();
            ofdPhoto.Filter = "jpg图片|*.jpg|png图片|*.png";
            if (ofdPhoto.ShowDialog() == true)
            {                
                string filename = ofdPhoto.FileName;

                Employee employee = (Employee)gridEmployee.DataContext;
                employee.Photo = File.ReadAllBytes(filename);//读取文件的二进制数据
                imgPhoto.Source = new BitmapImage(new Uri(filename));
            }
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            CaptureWindow win = new CaptureWindow();
            if (win.ShowDialog() == true)
            {
                byte[] data = win.CaptureData;
                ShowImg(data);
                Employee employee = (Employee)gridEmployee.DataContext;
                employee.Photo = data;
            }
        }
    }
}
