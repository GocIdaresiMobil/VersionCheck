using CheckInternet.Interfaces;

namespace CheckInternet.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
