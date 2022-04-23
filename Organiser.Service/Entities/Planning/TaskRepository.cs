using Microsoft.EntityFrameworkCore;

namespace Organiser.Service.Entities.Planning;

public class TaskRepository
{
    private readonly ServiceDatabaseContext _context;
    
    public TaskRepository(ServiceDatabaseContext context)
    {
        _context = context;
    }
    
    public TaskEntity[] GetAll()
    {
        return _context.Tasks.ToArray();
    }
}