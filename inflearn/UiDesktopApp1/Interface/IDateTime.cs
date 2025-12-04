namespace UiDesktopApp1.Interface
{
    public interface IDateTime  // 클래스 명에 "I"를 붙이는 이유는 Interface라는 뜻
    {
        DateTime? GetCurrentTime(); // 현재 시간을 가져오는 메서드
    }
}
