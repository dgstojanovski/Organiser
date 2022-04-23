using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Organiser.Models.Planning;

namespace Organiser.Service.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("Planning/[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ServiceDatabaseContext _context;

        public TaskController(ILogger<TaskController> logger, ServiceDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetTasks")]
        public IEnumerable<CalendarTask> Get()
        {
            return _context.Tasks?
            .Where(entity => !entity.IsDeleted)
            .Select(entity => new CalendarTask
            {
                Title = entity.Title ?? string.Empty,
                Description = entity.Description ?? string.Empty,
                Deadline = entity.Deadline,
                Priority = entity.Priority

            }) ?? Enumerable.Empty<CalendarTask>();
        }
    }
}
