using System.Threading.Tasks;
using System.Windows.Media;
using UiDesktopApp1.Interface;
using UiDesktopApp1.Models;
using Wpf.Ui.Abstractions.Controls;

namespace UiDesktopApp1.ViewModels.Pages
{
    public partial class DataViewModel : ObservableObject, INavigationAware
    {
        #region FIELDS
        private bool _isInitialized = false;

        private readonly IDatabase<GangnamguPopulation?>? _population;
        #endregion

        #region PROPERTIES
        // Atttibute를 통한 DB 맴버 자동 생성
        [ObservableProperty]
        private IEnumerable<GangnamguPopulation?>? _gangnamguPopulations;

        [ObservableProperty]
        private IEnumerable<string?>? _administrativeAgency;

        [ObservableProperty]
        private string? _selectedAdministrativeAgency;

        [ObservableProperty]
        private int? _selectedTotalPopulation;

        [ObservableProperty]
        private int? _selectedMalePopulation;

        [ObservableProperty]
        private int? _selectedFeMalePopulation;

        [ObservableProperty]
        private double? _selectedSexRatio;

        [ObservableProperty]
        private int? _selectedNumberOfHouseholds;

        [ObservableProperty]
        private double? _selectedNumberOfPeoplePerHouseholds;
        #endregion

        #region CONSTRUCTOR
        public DataViewModel(IDatabase<GangnamguPopulation?>? database)
        {
            this._population = database;
        }
        #endregion

        #region COMMANDS
        [RelayCommand]
        private void OnSelectedAdministrativeAgency()
        { // 암시적 커멘드 생성 (DataPage.xaml Selected 데이터 연결)
            var selectedData = this.SelectedAdministrativeAgency;
        }

        // CRUDE 작업은 Command에..
        [RelayCommand]
        private void CreateNewData()
        {
            // DB 객체 new 생성 
            GangnamguPopulation gangnamguPopulation = new GangnamguPopulation();

            // PostgreSQL에서 성의한 TotalPopulation에 
            gangnamguPopulation.AdministrativeAgency = this.SelectedAdministrativeAgency;
            gangnamguPopulation.TotalPopulation = this.SelectedTotalPopulation;
            gangnamguPopulation.MalePopulation = this.SelectedMalePopulation;
            gangnamguPopulation.FemalePopulation = this.SelectedFeMalePopulation;
            gangnamguPopulation.SexRatio = this.SelectedSexRatio;
            gangnamguPopulation.NumberOfHouseholds = this.SelectedNumberOfHouseholds;
            gangnamguPopulation.NumberOfPeoplePerHousehold = this.SelectedNumberOfPeoplePerHouseholds;
            this._population?.InsertDB(gangnamguPopulation);
        }

        [RelayCommand]
        private void ReadAllData()
        {
            this.GangnamguPopulations = this._population?.GetDataBaseTable();
        }
        #endregion

        #region METHODS
        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
            {
                //InitializeViewModel();
                InitializeViewModelAsync();
            }

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;
        private async Task InitializeViewModelAsync()    // async Task를 붙여 비동기 식으로 변경 
        {
            // DB 전체 데이터 베이스 테이블 데이터 호출
            //this.GangnamguPopulations = this._population?.GetDataBaseTable();

            // 제공 쿼리 select 로 AdministrativeAgency 데이터만 추출
            //this.AdministrativeAgency = this.GangnamguPopulations?.Select(c => c?.AdministrativeAgency).ToList();

            // 비동기로 데이터를 가져오기 (Thread 생성 후 비동기 실행)
            this.GangnamguPopulations = await Task.Run(() => this._population?.GetDataBaseTable());

            // 가져온 데이터를 가지고 필요한 작업을 수행
            if (this.GangnamguPopulations != null)
            {
                this.AdministrativeAgency = this.GangnamguPopulations.Select(c => c?.AdministrativeAgency).ToList();
            }

            _isInitialized = true;
        }
        #endregion
    }
}
