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
                new User{FirstName = "Sachin", MiddleName="", LastName = "Jadhav", Password="passw0rd", Email = "sachinjadha12@gmail.com", PhoneNumber = "8545231289", BirthDate =DateTime.Now.AddYears(-40), Height = 5.8M, Weight = 75, RoleId = 1 },
                new User{FirstName = "Swara",  LastName = "Patil", Password="passw0rd", Email = "swarapatil@gmail.com", PhoneNumber = "8545331289",  BirthDate = DateTime.Now.AddYears(-22), Height = 6M, Weight = 67, RoleId = 2 },
                new User{FirstName = "Akash1",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Akash2",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Akash3",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Akash4",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Akash5",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Akash6",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Akash7",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Akash8",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Akash9",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Akash10",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Akash11",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Akash12",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Akash13",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 }
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