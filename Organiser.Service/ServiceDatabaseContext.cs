using Microsoft.EntityFrameworkCore;
using Organiser.Enumerations;
using Organiser.Service.Entities.Planning;

namespace Organiser.Service;

public class ServiceDatabaseContext : DbContext
{
    public DbSet<TaskEntity>? Tasks { get; set; }
    
    private readonly string databasePath;
    
    public ServiceDatabaseContext()
    {
        var path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location);
        databasePath = Path.Join(path?.FullName, "organiser.service.db");
    }
    
    public static void Initialise(ServiceDatabaseContext context)
    {
        if (context.Tasks?.Any() ?? false)
            return;

        var tasks = new[]
        {
            new TaskEntity
            {
                Title = "Walk Walter around the block",
                Description = "What it sounds like",
                Deadline = DateTime.Today,
                Priority = Priority.High
            }
        };
        
        context.Tasks?.AddRange(tasks);
        context.SaveChanges();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={databasePath}");
}
