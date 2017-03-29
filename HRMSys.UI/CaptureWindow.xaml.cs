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
using WPFMediaKit.DirectShow.Controls;
using System.IO;

namespace HRMSys.UI
{
    /// <summary>
    /// CaptureWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CaptureWindow : Window
    {
        public CaptureWindow()
        {
            InitializeComponent();
        }

        public byte[] CaptureData { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbCameras.ItemsSource = MultimediaUtil.VideoInputNames;
            if (MultimediaUtil.VideoInputNames.Length > 0)
            {
                cbCameras.SelectedIndex = 0;//第0个摄像头为默认摄像头
            }
            else
            {
                MessageBox.Show("电脑没有安装任何可用摄像头");
            }
        }


        private void cbCameras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            captureElement.VideoCaptureSource = (string)cbCameras.SelectedItem;
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {

            //captureElement. 怎么抓取高清的原始图像
            //能不能抓视频。
            //todo：怎么只抓取一部分
            RenderTargetBitmap bmp = new RenderTargetBitmap(
                (int)captureElement.ActualWidth,
                (int)captureElement.ActualHeight,
                96, 96, PixelFormats.Default);

            //为避免抓不全的情况，需要在Render之前调用Measure、Arrange
            //为避免VideoCaptureElement显示不全，需要把
            //VideoCaptureElement的Stretch="Fill"
            captureElement.Measure(captureElement.RenderSize);
            captureElement.Arrange(new Rect(captureElement.RenderSize));
            bmp.Render(captureElement);

            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                CaptureData = ms.ToArray();                
            }
            //captureElement.Pause();
            //todo:自己完成重拍的代码
            DialogResult = true;
        }
    }
}
