using MotorcycleWebShop.Domain.Interfaces;

namespace MotorcycleWebShop.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
