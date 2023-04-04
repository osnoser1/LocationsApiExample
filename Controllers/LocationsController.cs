using LocationsApiExample.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LocationsApiExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly List<Location> _locations = new()
    {
        new() { Name = "Pharmacy A", OpenTime = new(8, 0), CloseTime = new(16, 0) },
        new() { Name = "Bakery B", OpenTime = new(9, 0), CloseTime = new(13, 0) },
        new() { Name = "Barber Shop C", OpenTime = new(10, 0), CloseTime = new(18, 0) },
        new() { Name = "Supermarket D", OpenTime = new(7, 0), CloseTime = new(23, 0) },
        new() { Name = "Candy Store E", OpenTime = new(11, 0), CloseTime = new(20, 0) },
        new() { Name = "Cinema Complex F", OpenTime = new(11, 0), CloseTime = new(22, 0) },
        new() { Name = "Hardware Store G", OpenTime = new(8, 0), CloseTime = new(17, 0) },
        new() { Name = "Restaurant H", OpenTime = new(12, 0), CloseTime = new(22, 0) },
        new() { Name = "Fitness Center I", OpenTime = new(5, 0), CloseTime = new(23, 0) },
        new() { Name = "Pet Store J", OpenTime = new(10, 0), CloseTime = new(19, 0) },
        new() { Name = "Bookstore K", OpenTime = new(9, 0), CloseTime = new(20, 0) },
        new() { Name = "Jewelry Store L", OpenTime = new(10, 30), CloseTime = new(18, 30) },
        new() { Name = "Gym M", OpenTime = new(6, 0), CloseTime = new(21, 0) },
        new() { Name = "Toy Store N", OpenTime = new(11, 0), CloseTime = new(19, 0) },
        new() { Name = "Coffee Shop O", OpenTime = new(7, 0), CloseTime = new(18, 0) },
        new() { Name = "Clothing Store P", OpenTime = new(10, 0), CloseTime = new(20, 0) },
        new() { Name = "Grocery Store Q", OpenTime = new(8, 0), CloseTime = new(22, 0) },
        new() { Name = "Pharmacy R", OpenTime = new(9, 0), CloseTime = new(17, 0) },
        new() { Name = "Pet Supply Store S", OpenTime = new(11, 0), CloseTime = new(19, 0) },
        new() { Name = "Home Improvement Store T", OpenTime = new(7, 30), CloseTime = new(20, 0) }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Location>> Get()
    {
        var startTime = new TimeOnly(10, 0);
        var endTime = new TimeOnly(13, 0);
        return _locations
            .Where(l => l.OpenTime <= startTime && l.CloseTime >= endTime)
            .ToList();
    }
}