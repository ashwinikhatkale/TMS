using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Business.Repositories.Models
{
  public class TeamMemberModel
    {
        public long TeamId { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public long IsCaption { get; set; }
    }
}
