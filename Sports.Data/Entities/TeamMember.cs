using System.Data.Entity.ModelConfiguration;

namespace Sports.Data.Entities
{
    public class TeamMember : Entity
    {
        public long TeamId { get; set; }
        public virtual Team Team { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public bool IsSelected { get; set; }
    }

    public class TeamMemberConfiguration : EntityTypeConfiguration<TeamMember>
    {
        public TeamMemberConfiguration()
        {
            this.HasRequired(s => s.Team)
                .WithMany(m => m.Users)
                .HasForeignKey(s => s.TeamId)
                .WillCascadeOnDelete(false);

            this.HasRequired(s => s.User)
                .WithMany(m => m.Teams)
                .HasForeignKey(s => s.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
