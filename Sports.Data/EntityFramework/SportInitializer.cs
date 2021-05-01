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
                new User{FirstName = "Sachin",  LastName = "Patil", Password="passw0rd", Email = "sachinpatil@gmail.com", PhoneNumber = "8545331289",  BirthDate = DateTime.Now.AddYears(-22), Height = 6M, Weight = 67, RoleId = 2 },
                new User{FirstName = "Akash",  LastName = "Jadhav", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Amit",  LastName = "Mahajan", Password="passw0rd", Email = "akashjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Rahul",  LastName = "Mane", Password="passw0rd", Email = "rahulmane20@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Sandip",  LastName = "Kale", Password="passw0rd", Email = "sandip10kale@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Suresh",  LastName = "Nirwal", Password="passw0rd", Email = "sureshnirwal34@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Nitin",  LastName = "Khare", Password="passw0rd", Email = "nitinkhare@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Nilesh",  LastName = "Shelke", Password="passw0rd", Email = "shelkenilesh@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Sanjay",  LastName = "Bhosale", Password="passw0rd", Email = "sanjay1234@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Vishal",  LastName = "Shinde", Password="passw0rd", Email = "vishalshinde10@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Vijay",  LastName = "Gayakwad", Password="passw0rd", Email = "vijay0304@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Samadhan",  LastName = "Narale", Password="passw0rd", Email = "samdhan123@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Manish",  LastName = "Jadhav", Password="passw0rd", Email = "manishjadhav@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 },
                new User{FirstName = "Manoj",  LastName = "Jagdale", Password="passw0rd", Email = "manojjagdale@gmail.com", PhoneNumber = "8545223289",  BirthDate =DateTime.Now.AddYears(-23), Height = 5.9M, Weight = 65, RoleId = 3 }
            };
            _context.Users.AddRange(users);

            _context.SaveChanges();


            var teamMember = new List<TeamMember>
            {
                new TeamMember{ TeamId = 1, UserId = 1, IsSelected = true },
                new TeamMember{ TeamId = 1, UserId = 2, IsSelected = true },
                new TeamMember{ TeamId = 1, UserId = 3 ,IsSelected = true },
                new TeamMember{ TeamId = 1, UserId = 4 ,IsSelected = true },
                new TeamMember{ TeamId = 1, UserId = 5 ,IsSelected = true },
                new TeamMember{ TeamId = 1, UserId = 6 ,IsSelected = true },
                new TeamMember{ TeamId = 1, UserId = 7 ,IsSelected = true },
                new TeamMember{ TeamId = 1, UserId = 8 ,IsSelected = true },
                 new TeamMember{ TeamId = 1, UserId = 9 ,IsSelected = true },
                new TeamMember{ TeamId = 1, UserId = 10 ,IsSelected = true },
                new TeamMember{ TeamId = 1, UserId = 11,IsSelected = true },               
                new TeamMember{ TeamId = 1, UserId = 12 ,IsSelected = true },
                new TeamMember{ TeamId = 1, UserId = 13 ,IsSelected = true },
                new TeamMember{ TeamId = 1, UserId = 14 ,IsSelected = true },
                new TeamMember{ TeamId = 1, UserId = 15 ,IsSelected = true },
            };
            _context.TeamMembers.AddRange(teamMember);

            _context.SaveChanges();
        }
    }
}