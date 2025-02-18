using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace OnlineStore.Infrastructure.Databases.Converters;
public class ConvertDateOnly : ValueConverter<DateOnly, DateTime>
{
    /// <summary>
    /// https://code-maze.com/csharp-map-dateonly-timeonly-types-to-sql/
    /// Create custom class to convert DateOnly to DateTime EntityFrameworkCore 7
    /// </summary>
    public ConvertDateOnly() : base(dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue), dateTime => DateOnly.FromDateTime(dateTime))
    {

    }
}