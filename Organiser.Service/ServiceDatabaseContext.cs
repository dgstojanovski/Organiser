using Microsoft.EntityFrameworkCore;
using Organiser.Enumerations;
using Organiser.Service.Entities.Planning;

namespace Organiser.Service;

public class ServiceDatabaseContext : DbContext
{
    public DbSet<CalenderTask> Tasks { get; set; }
    
    private string databasePath;
    
    public ServiceDatabaseContext()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        databasePath = Path.Join(path, "blogging.db");
    }
    
    public static void Initialise(ServiceDatabaseContext context)
    {
        if (context.Tasks.Any())
            return;

        var tasks = new[]
        {
            new CalenderTask
            {
                Title = "Walk Walter around the block",
                Description = "What it sounds like",
                Deadline = DateTime.Today,
                Priority = Priority.High
            }
        };
        
        context.Tasks.AddRange(tasks);
        context.SaveChanges();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={databasePath}");
}


