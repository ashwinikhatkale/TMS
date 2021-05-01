using Sports.Data.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;
using System.Threading;
using System.Threading.Tasks;

namespace Sports.Data.EntityFramework
{
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class SportsContext : DbContext
    {
        public SportsContext() : base("SportsContext")
        {
            Database.SetInitializer<SportsContext>(new SportInitializer());
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;

            foreach (var dbEntityEntry in ChangeTracker.Entries<Entity>())
            {
                if (dbEntityEntry.State == EntityState.Added)
                {
                    dbEntityEntry.Entity.CreatedOn = now;
                    dbEntityEntry.Entity.UpdatedOn = now;
                }

                if (dbEntityEntry.State == EntityState.Modified)
                {
                    dbEntityEntry.Entity.UpdatedOn = now;
                }
            }

            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (DbEntityValidationException ex)
            {
                // Add the original exception as the innerException
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + ex.InnerException, ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException.ToString(), ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString(), ex);
            }
        }

    }

    class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            this.SetDatabaseInitializer(new DropCreateDatabaseIfModelChanges<SportsContext>());
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}
