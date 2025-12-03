using System.ComponentModel;
using UiDesktopApp1.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;

namespace UiDesktopApp1.Views.Pages
{
    public partial class DataPage : INavigableView<DataViewModel>
    {
        public DataViewModel ViewModel { get; }

        public DataPage(DataViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            // 뷰 모델에서 프로퍼티 체인지 이벤트 처리
            ViewModel.PropertyChanging += ViewModel_PropertyChanged;
            InitializeComponent();
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangingEventArgs e)
        {
            switch (e.PropertyName) // DataViewModel에서 정의한 멤버
            {
                case "AdministrativeAgency":    // 콤보박스 데이터
                    this.searchGridLoadingControl.Visibility = Visibility.Collapsed; // 로딩 컨트롤 속성 이름
                    this.searchGrid.Visibility = Visibility.Visible;  // 가시성은 visible
                    break;
                case "GangnamguPopulations":    // 테이블 데이터
                    this.dgGridLoadingControl.Visibility = Visibility.Collapsed;
                    this.dgGrid.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void cbxAdminAgency_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
