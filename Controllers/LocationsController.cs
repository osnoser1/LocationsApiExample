using LocationsApiExample.Entities;
using LocationsApiExample.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocationsApiExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly LocationDbContext _context;

    public LocationsController(LocationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Location>>> Get()
    {
        var startTime = new TimeOnly(10, 0);
        var endTime = new TimeOnly(13, 0);
        return await _context.Locations
            .Where(l => l.OpenTime <= startTime && l.CloseTime >= endTime)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Location>> Create(Location locationDto)
    {
        // Map LocationDto to Location entity
        var location = new Location
        {
            Name = locationDto.Name,
            OpenTime = locationDto.OpenTime,
            CloseTime = locationDto.CloseTime
        };

        // Add new location to database
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();

        locationDto.Id = location.Id;

        return locationDto;
    }
}