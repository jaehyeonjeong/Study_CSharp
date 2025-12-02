using UiDesktopApp1.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;

namespace UiDesktopApp1.Views.Pages
{
    // xaml뷰와 뷰 모델은 1 대 1 매칭
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }        // 데이터 바인딩을 할 수 있는 변수

        public DashboardPage(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
