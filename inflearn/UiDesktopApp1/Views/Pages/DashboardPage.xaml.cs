using System.Windows.Media;
using UiDesktopApp1.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;

namespace UiDesktopApp1.Views.Pages
{
    // xaml뷰와 뷰 모델은 1 대 1 DashBoard에서 출력
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }        // 데이터 바인딩을 할 수 있는 변수

        public DashboardPage(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            ViewModel.PropertyChanged += ViewModel_PropertyChanged; // property change로 변화된 값을 받아옴

            InitializeComponent();
        }

        private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // 코드 비하인드에서는 이 함수 호출 됨으로써 어떤 값들이 변경되었는지 확인 가능
            switch(e.PropertyName)  // 바인딩 이름
            {
                case "Text01": // Text01 로 바인딩 된 버튼
                    // UI 컴트롤에 대한 변경이 코드비하인드에 들어갈 수 있음
                    this.btnClickMe.Background = new SolidColorBrush(Colors.White);
                    break;
            }
        }
    }
}
