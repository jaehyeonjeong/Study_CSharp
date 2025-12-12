using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
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
        private string _adaptiveThreshold = "ADAPTIVE_THRESH_MEAN_C";
        int _thresholdValue = 0;
        int _adaptiveThresholdValue = 0;
        private string _bitwiseMethod = "bitwiseOR";
        bool _isOtsu = false;
        static int _nOstuValue;

        private Bitmap _originalBitmap;
        private Bitmap _secondOriBitmap;
        private Bitmap _resultBitmap;

        public MainWindow()
        {
            InitializeComponent();

            // ImgResult.Source 속성 변경 감지
            var dpd = DependencyPropertyDescriptor.FromProperty(
                System.Windows.Controls.Image.SourceProperty, typeof(System.Windows.Controls.Image));

            if (dpd != null)
            {
                dpd.AddValueChanged(ImgResult, ImgResult_SourceChanged);
            }
        }

        private void ImgResult_SourceChanged(object sender, EventArgs e)
        {
            // WPF Image.Source 가져오기
            BitmapSource bmpSource = ImgResult.Source as BitmapSource;

            using (MemoryStream ms = new MemoryStream())
            {
                BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmpSource));
                encoder.Save(ms);

                using (var bmp = new Bitmap(ms))
                {
                    // 복사본 생성 후 넘기기
                    Bitmap bmpCopy = new Bitmap(bmp);
                    _resultBitmap = ImageProcessor.GrayColorBitmap(bmpCopy);
                } // 원본 bmp는 Dispose되어도 문제 없음
            }

            ImgRstGray.Source = ConvertToBitmapImage(_resultBitmap);
            ImgHistogram.Source = ImageProcessor.CreateHistogram(_resultBitmap);
        }


        // 이미지 선택 버튼 1
        private void BtnSelectOneImage_Click(object sender, RoutedEventArgs e)
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

        private void BtnSelectTwoImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() == true)
            {
                _secondOriBitmap = new Bitmap(dlg.FileName);
                ImgSecondOri.Source = ConvertToBitmapImage(_secondOriBitmap);
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
            ImgResult.Source = ConvertToBitmapImage(result);
        }

        private void ApplyThreshold(int threshType, int nAdaptiveThresholdType, int nBlockSize, double dC)
        {
            try
            {
                Bitmap result = ImageProcessor.ThresholdImage(_originalBitmap, nAdaptiveThresholdType, threshType, nBlockSize, dC);
                ImgResult.Source = ConvertToBitmapImage(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 이미지 합성
        private void BlendingImage(double dAlpha, double dBeta, double dGamma)
        {
            // alpha : 지정할 가중치, beta : 지정할 역가중치, gamma : 연산 결과에 가감할 상수(흔히 0으로 적용)
            Bitmap result = ImageProcessor.BlendImage(_originalBitmap, _secondOriBitmap, dAlpha, dBeta, dGamma);
            ImgResult.Source = ConvertToBitmapImage(result);
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


        private void RadioButton_Adative_Click(object sender, RoutedEventArgs e)
        {
            var rb = sender as System.Windows.Controls.RadioButton;
            try
            {
                if (rb != null)
                {
                    // 전역 변수 값 변경
                    _adaptiveThreshold = rb.Content.ToString();     // 컨텐트에 있는 문자열 반환

                    AdaptiveThreshold th = (AdaptiveThreshold)Enum.AdaptiveThreshold.Parse(typeof(AdaptiveThreshold), _adaptiveThreshold);   // 문자열을 Enum으로 변경

                    _adaptiveThresholdValue = (int)th;  // Enum을 int로 변경
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdative_Click(object sender, RoutedEventArgs e)
        {
            //private void ApplyThreshold(int threshValue, int nAdaptiveThresholdType, int nBlockSize, double dC)
            ApplyThreshold(_thresholdValue, _adaptiveThresholdValue,
                int.Parse(txtBlockSize.Text), double.Parse(txtCValue.Text));
        }

        private void SliderAlphaBeta_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                double alpha = ((double)SliderAlphaBeta.Value);
                double beta = (1.0 - (double)SliderAlphaBeta.Value);

                txtAlpha.Text = alpha.ToString();
                txtBeta.Text = beta.ToString();

                if (chkApply.IsChecked.Value)
                {
                    if (_originalBitmap != null && _secondOriBitmap != null)
                    {
                        BlendingImage(alpha, beta, double.Parse(txtGamma.Text));
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void BitWiseCalc(int type)
        {
            Bitmap result = ImageProcessor.BitWiseCalc(_originalBitmap, _secondOriBitmap, type);
            ImgResult.Source = ConvertToBitmapImage(result);
        }


        private void RadioButton_Bitwise_Click(object sender, RoutedEventArgs e)
        {
            var rb = sender as System.Windows.Controls.RadioButton;

            if (rb != null)
            {
                _bitwiseMethod = rb.Content.ToString();     // 컨텐트에 있는 문자열 반환

                Bitwise bitwise = (Bitwise)Enum.Bitwise.Parse(typeof(Bitwise), _bitwiseMethod);   // 문자열을 Enum으로 변경

                BitWiseCalc((int)bitwise);
            }
        }
    }
}
