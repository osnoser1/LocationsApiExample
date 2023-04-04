namespace LocationsApiExample.Entities;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
}