using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using LocationsApiExample.Entities;
using LocationsApiExample.Infrastructure;

namespace LocationsApiExample.Core.Startup;

public static class LocationSeeder
{
    public static void Seed(LocationDbContext context)
    {
        if (context.Locations.Any()) return;

        using var reader = new StreamReader("locations.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<LocationMap>();
        var records = csv.GetRecords<Location>().ToList();
        context.Locations.AddRange(records);
        context.SaveChanges();
    }

    private class LocationMap : ClassMap<Location>
    {
        public LocationMap()
        {
            Map(m => m.Id).Optional();
            Map(m => m.Name);
            Map(m => m.OpenTime);
            Map(m => m.CloseTime);
        }
    }
}