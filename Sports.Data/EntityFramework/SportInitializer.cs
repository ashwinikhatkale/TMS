using Sports.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Transactions;

namespace Sports.Data.EntityFramework
{
    public class SportInitializer : IDatabaseInitializer<SportsContext>
    {
        public void InitializeDatabase(SportsContext context)
        {
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                if (context.Database.Exists())
                {
                    if (context.Database.CompatibleWithModel(true))
                        return;

                    context.Database.Delete();
                }
                context.Database.Create();

                //Calling the Seed method
                Seed(context);
            }

        }
        public void Seed(SportsContext _context)
        {
            var roles = new List<Role>
            {
                new Role{ Id = 1, Name = UserRole.TeamCoach.ToString()  },
                new Role{Id = 2, Name = UserRole.Caption.ToString() },
                new Role{Id = 3, Name = UserRole.Player.ToString() }
            };
            _context.Roles.AddRange(roles);

            _context.SaveChanges();
            var teams = new List<Team>
            {
                new Team{ Name = "Mumbai Indians", Description = "Team Description"  },
                new Team{ Name = "Chennai Super Kings", Description = "Team Description"  },
                new Team{ Name = "Royal Challengers Bangalore", Description = "Team Description"  }
            };
            _context.Teams.AddRange(teams);

            _context.SaveChanges();


            var users = new List<User>
            {
                new User{FirstName = "Sachin", MiddleName="", LastName = "Jadhav", Password="passw0rd", Email = "sachinjadha12@gmail.com", PhoneNumber = "8545231289", BirthDate =DateTime.Now.AddYears(-40), Height = "", Weight = "", RoleId = 1 },
                new User{FirstName = "Swara",  LastName = "Patil", Password="passw0rd", Email = "swarapatil@gmail.com", PhoneNumber = "8545331289",  BirthDate = DateTime.Now.AddYears(-22), Height = "", Weight = "", RoleId = 2 },
                new User{FirstName = "Akash",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = "", Weight = "", RoleId = 3 }
            };
            _context.User.AddRange(users);

            _context.SaveChanges();


            var teamMember = new List<TeamMember>
            {
                new TeamMember{ TeamId = 1, UserId = 1 },
                new TeamMember{ TeamId = 1, UserId = 2 },
                new TeamMember{ TeamId = 1, UserId = 3 }

            };
            _context.TeamMembers.AddRange(teamMember);

            _context.SaveChanges();
        }
    }
}