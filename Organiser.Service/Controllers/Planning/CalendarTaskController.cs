using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Organiser.Models.Planning;

namespace Organiser.Service.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("planning/[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CalendarTaskController : ControllerBase
    {
        private readonly ILogger<CalendarTaskController> _logger;
        private readonly ServiceDatabaseContext _context;

        public CalendarTaskController(ILogger<CalendarTaskController> logger, ServiceDatabaseContext context)
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
