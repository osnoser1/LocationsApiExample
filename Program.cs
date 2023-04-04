using LocationsApiExample.Core.Startup;
using LocationsApiExample.Core.Transformers;
using LocationsApiExample.Infrastructure;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(
        new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    c.MapType<TimeOnly>(() => new()
    {
        Type = "string",
        Format = "string",
        Example = new OpenApiString(new TimeOnly(8, 0).ToString("r"))
    })
);

builder.Services.AddSqlServer<LocationDbContext>(builder.Configuration.GetConnectionString("LocationDatabase"));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LocationDbContext>();
    context.Database.Migrate();
    LocationSeeder.Seed(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();