using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using viLinkOpencvClr;
using viWPFOpencv.Enum;

namespace viWPFOpencv
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        // 전역 변수 (예: Threshold 모드)
        private string _thresholdMode = "THRESH_BINARY";
        int _thresholdValue = 0;
        bool _isOtsu = false;
        static int _nOstuValue;

        private Bitmap _originalBitmap;

        public MainWindow()
        {
            InitializeComponent();
        }

        // 이미지 선택 버튼
        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() == true)
            {
                _originalBitmap = new Bitmap(dlg.FileName);
                ImgOriginal.Source = ConvertToBitmapImage(_originalBitmap);
                try
                {
                    ApplyThreshold((int)SliderThreshold.Value);
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SliderThreshold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                TxtValue.Text = ((int)SliderThreshold.Value).ToString();
                if (_originalBitmap != null)
                {
                    ApplyThreshold((int)SliderThreshold.Value);
                }
            }
            catch (NullReferenceException ex)
            {
                Debug.Print(ex.Message);
            }
        }

        // Threshold 적용
        private void ApplyThreshold(int threshValue)
        {
            Bitmap result = ImageProcessor.ThresholdImage(_originalBitmap, threshValue, _thresholdValue, _isOtsu, ref _nOstuValue);
            ImgThreshold.Source = ConvertToBitmapImage(result);
        }

        // Bitmap → BitmapImage 변환
        private BitmapImage ConvertToBitmapImage(Bitmap bmp)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Position = 0;
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.EndInit();
                return bi;
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var rb = sender as System.Windows.Controls.RadioButton;
            try
            {
                if (rb != null)
                {
                    // 전역 변수 값 변경
                    _thresholdMode = rb.Content.ToString();     // 컨텐트에 있는 문자열 반환

                    Threshold th = (Threshold)Enum.Threshold.Parse(typeof(Threshold), _thresholdMode);   // 문자열을 Enum으로 변경

                    _thresholdValue = (int)th;  // Enum을 int로 변경

                    ApplyThreshold(int.Parse(TxtValue.Text));    // 라디오 버튼 선택 시 이미지 변환
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOtsu_Click(object sender, RoutedEventArgs e)
        {
            _isOtsu = true;
            ApplyThreshold(int.Parse(TxtValue.Text));    // 버튼 클릭시 이미지 전환
            SliderThreshold.Value = _nOstuValue;
            TxtValue.Text = _nOstuValue.ToString();
            _isOtsu = false;
        }
    }
}
