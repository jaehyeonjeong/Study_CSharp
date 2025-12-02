namespace UiDesktopApp1.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {
        //기존 C# 변수는 내부에서 찍어야 함
        private string? text;

        public string MyProperty 
        { 
            get
            {
                return text;
            }
            set
            {
                this.text = value;
                // 해당 변수가 changed 됨
                // RaisePropertyChanged();
            }
        }

        // 새로 생성한 Observalble Property
        [ObservableProperty]
        private string? _text01 = string.Empty;      // 이러면 제너릭이 자동으로 생성됨
        // ?를 붙이는 이유는 null을 허용

        // Integer 속성의 Observable Property 파라미터
        [ObservableProperty]
        private int _counter = 0; // 파라미터 대로 변수를 선언하면

        [RelayCommand]
        private void OnCounterIncrement()
        {
            //Counter++;  // 카운터 속성을 통해 변수에 접근(어디에?)
            // 속성코드가 자동으로 제너레이션 된다.
            //this.Text01 = "test";        // 자동 생성된 변수를 이런 방법으로 사용할 수 있음
            this.Text01 = "Clicked";
        }
        // 이렇게하면 속성을 일일히 생성할 필요는 없어진다.

        // 로직 클래스를 내부적으로만 사용하는 경우
        [RelayCommand]  // 외부적으로 사용하는 경우 자동으로 제네레이트 시킴
        private void OnTextChanged()        // 뷰에서 커멘드로 자동 제네레이션
        {
            this.Text01 = "Changed Text";
        }
    }
}
