using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Business.Repositories.Models
{
   public class TeamModel
    {
        public long CoachId { get; set; }
        public long TeamId { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
    }
}
