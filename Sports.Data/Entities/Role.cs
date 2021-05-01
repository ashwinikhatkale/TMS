
namespace Sports.Data.Entities
{
    public  class Role : Entity
    {
        public string Name { get; set; }
    }

    public enum UserRole
    {
        TeamCoach = 1,
        Caption,
        Player
    
}
}
 