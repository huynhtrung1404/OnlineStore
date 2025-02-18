using OnlineStore.Application.Commons.Interfaces;

namespace OnlineStore.Infrastructure.Services;
public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;

    public DateTime UtcNow => DateTime.UtcNow;
}