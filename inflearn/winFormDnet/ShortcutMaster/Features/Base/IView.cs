namespace ShortcutMaster.Features.Base
{
    // 모든 View는 IView를 상속받아야 함
    public interface IView    // 기본 뷰 인터페이스
    {
        void Close();   // 창 닫기 메서드
        string Text { get; set; }   // 창 제목 속성
        bool Visible { get; set; } //  창 가시성 속성 (Visible이라는 철자를 제대로 쓰지 않으면 충돌이 발생함)

        public void ShowMessage(string message) // 메시지 박스 표시 메서드
        {
            MessageBox.Show(message);
        }

        public DialogResult ShowDialog(string message, string caption, MessageBoxButtons buttons)   // 대화 상자 표시 메서드
        {
            return MessageBox.Show(message, caption, buttons);
        }
    }
}
