using UiDesktopApp1.Interface;

namespace UiDesktopApp1.Services
{
    class DateTimeService : IDateTime
    {
        public DateTime? GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
