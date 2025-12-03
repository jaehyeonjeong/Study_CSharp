using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;
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

        [ObservableProperty]
        private int? _selectedId;
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

            // Id 값은 넣지 않아도 되는 이유는 Service에서 Id 값 자동 증가로 처리
            this._population?.InsertDB(gangnamguPopulation);
        }

        [RelayCommand]
        private void ReadAllData()      // 전체 데이터 읽어오기
        {
            this.GangnamguPopulations = this._population?.GetDataBaseTable();
        }

        [RelayCommand]
        private void ReadDetailData()
        {
            // 데이터를 찾을 때 1칸씩 밀리기 때문에 PostgreSQL 표기에 맞게 처리
            var targetData = this._population?.GetDetail(this.SelectedId);

            this.SelectedAdministrativeAgency = targetData?.AdministrativeAgency;
            this.SelectedTotalPopulation = targetData?.TotalPopulation;
            this.SelectedMalePopulation = targetData?.MalePopulation;
            this.SelectedFeMalePopulation = targetData?.FemalePopulation;
            this.SelectedSexRatio = targetData?.SexRatio;
            this.SelectedNumberOfHouseholds = targetData?.NumberOfHouseholds;
            this.SelectedNumberOfPeoplePerHouseholds = targetData?.NumberOfPeoplePerHousehold;

        }

        [RelayCommand]
        private void UpdateData() // 데이터 업데이트
        {
            var targetData = this._population?.GetDetail(this.SelectedId);

            // PostgreSQL에서 성의한 TotalPopulation에 
            targetData.AdministrativeAgency = this.SelectedAdministrativeAgency;
            targetData.TotalPopulation = this.SelectedTotalPopulation;
            targetData.MalePopulation = this.SelectedMalePopulation;
            targetData.FemalePopulation = this.SelectedFeMalePopulation;
            targetData.SexRatio = this.SelectedSexRatio;
            targetData.NumberOfHouseholds = this.SelectedNumberOfHouseholds;
            targetData.NumberOfPeoplePerHousehold = this.SelectedNumberOfPeoplePerHouseholds;

            this._population?.UpdateDB(targetData);
        }

        [RelayCommand]
        public void DeleteData()
        {
            this._population?.DeleteDB(this.SelectedId);
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
