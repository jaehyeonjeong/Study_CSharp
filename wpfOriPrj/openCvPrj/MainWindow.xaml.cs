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
using System;
using Microsoft.Win32;
using linkOpenCvLib;
using openCvPrj.bitmap;

namespace openCvPrj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 파일 선택
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.png;*.bmp";

            if (dlg.ShowDialog() == true)
            {
                string path = dlg.FileName;

                // 원본 이미지 출력
                OriginalImage.Source = new BitmapImage(new Uri(path));

                // DLL 호출
                int w = 0, h = 0;   // width, height 초기값
                byte[] grayData = CV.LoadGrayImage(path, ref w, ref h);

                if (grayData == null)
                {
                    MessageBox.Show("이미지를 불러올 수 없습니다.");
                    return;
                }

                // 변환된 이미지 출력
                ProcessedImage.Source = byteArray.ByteArrayToBitmapSource(grayData, w, h);
            }
        }
    }
}