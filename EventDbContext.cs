using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Configuration.Json;

public class EventDbContext : DbContext
{
public DbSet<Event> Events { get; set; }
public DbSet<Location> Locations { get; set; }
public void AddEvents(List<Event> events)
{
    this.Events.AddRange(events);
    this.SaveChanges();
}
public void AddLocations(List<Location> locations)
{
    this.Locations.AddRange(locations);
    this.SaveChanges();
}
public void AddEvent(Event evt)
{
    this.Events.Add(evt);
    this.SaveChanges();
}
public void AddLocation(Location loc)
{
    this.Locations.Add(loc);
    this.SaveChanges();
}
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    var configuration =  new ConfigurationBuilder()
        .AddJsonFile($"appsettings.json");

    var config = configuration.Build();
    optionsBuilder.UseSqlServer(@config["EventDbContext:ConnectionString"]);
}
}
