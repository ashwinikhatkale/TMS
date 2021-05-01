using System.Collections.Generic;

namespace Sports.Data.Entities
{
    public  class Team : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TeamMember> Users { get; set; }
    }
}
