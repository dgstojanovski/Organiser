using Organiser.Enumerations;

namespace Organiser.Service.Entities.Planning;

public class CalenderTask
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime? Deadline { get; set; }

    public Priority Priority { get; set; }
}
