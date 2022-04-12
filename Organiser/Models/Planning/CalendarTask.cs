using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organiser.Enumerations;

namespace Organiser.Models.Planning
{
    public class CalendarTask
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime? Deadline { get; set; }

        public Priority Priority { get; set; }
    }
}
