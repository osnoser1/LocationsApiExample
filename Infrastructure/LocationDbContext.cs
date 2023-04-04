using LocationsApiExample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#pragma warning disable CS8618

namespace LocationsApiExample.Infrastructure;

public class LocationDbContext : DbContext
{
    public LocationDbContext(DbContextOptions<LocationDbContext> options) : base(options)
    {
    }

    public DbSet<Location> Locations { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<TimeOnly>()
            .HaveConversion<TimeOnlyConverter>()
            .HaveColumnType("time");
    }

    /// <summary>
    ///     Converts <see cref="TimeOnly" /> to <see cref="DateTime" /> and vice versa.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Local
    private class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        /// <summary>
        ///     Creates a new instance of this converter.
        /// </summary>
        public TimeOnlyConverter() : base(
            d => d.ToTimeSpan(),
            d => TimeOnly.FromTimeSpan(d))
        {
        }
    }
}