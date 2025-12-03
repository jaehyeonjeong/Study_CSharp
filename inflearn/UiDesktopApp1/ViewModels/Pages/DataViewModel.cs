using System.Windows.Media;
using UiDesktopApp1.Interface;
using UiDesktopApp1.Models;
using Wpf.Ui.Abstractions.Controls;

namespace UiDesktopApp1.ViewModels.Pages
{
    public partial class DataViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private readonly IDatabase<GangnamguPopulation?>? _population;

        public DataViewModel(IDatabase<GangnamguPopulation?>? database)
        {
            this._population = database;
        }

        [ObservableProperty]
        private IEnumerable<DataColor> _colors;

        // Atttibute를 통한 DB 맴버 자동 생성
        [ObservableProperty]
        private IEnumerable<GangnamguPopulation?>? _gangnamguPopulations;


        [ObservableProperty]
        private IEnumerable<string?>? _administrativeAgency;

        [ObservableProperty]
        private string? _selectedAdministrativeAgency;

        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        [RelayCommand]
        private void OnSelectedAdministrativeAgency()
        { // 암시적 커멘드 생성 (DataPage.xaml Selected 데이터 연결)
            var selectedData = this.SelectedAdministrativeAgency;
        }

        private void InitializeViewModel()
        {
            // DB 전체 데이터 베이스 테이블 데이터 호출
            this.GangnamguPopulations = this._population?.GetDataBaseTable();

            // 제공 쿼리 select 로 AdministrativeAgency 데이터만 추출
            this.AdministrativeAgency = this.GangnamguPopulations?.Select(c => c?.AdministrativeAgency).ToList();

            _isInitialized = true;
        }
    }
}
