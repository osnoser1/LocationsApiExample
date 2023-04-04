namespace LocationsApiExample.Entities;

public class Location
{
    public string Name { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
}