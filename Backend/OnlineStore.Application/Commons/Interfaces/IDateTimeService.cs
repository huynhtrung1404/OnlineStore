namespace OnlineStore.Application.Commons.Interfaces;
public interface IDateTimeService
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}