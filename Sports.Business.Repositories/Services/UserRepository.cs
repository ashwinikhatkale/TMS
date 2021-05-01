using Sports.Business.Repositories.Interfaces;
using Sports.Business.Repositories.Models;
using Sports.Data.Entities;
using Sports.Data.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sports.Business.Repositories.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly SportsContext _context;
        public UserRepository(SportsContext context)
        {
            _context = context;
        }
        public async Task<UserModel> GetUser(long[] ids)
        {
            var user = await _context.User
                                    .Where(x => ids.Contains( x.Id ))
                                    .Select(x => new UserModel { RoleId = x.Id, FirstName = x.FirstName, MiddleName = x.MiddleName, LastName = x.LastName, PhoneNumber = x.PhoneNumber, BirthDate = x.BirthDate, Email = x.Email, Height = x.Height, Weight = x.Weight }).FirstOrDefaultAsync();

            return user;
        }
        public async Task<List<UserModel>> GetUserDetails(long[] ids)
        {
            var users = await _context.User
                                    .Where(x => ids.Contains(x.Id))
                                    .Select(x => new UserModel { RoleId = x.Id, FirstName = x.FirstName, MiddleName = x.MiddleName, LastName = x.LastName, PhoneNumber = x.PhoneNumber, BirthDate = x.BirthDate, Email = x.Email, Height = x.Height, Weight = x.Weight }).ToListAsync();

            return users;
        }
        public async Task<List<UserModel>> GetPlayers(long teamId)
        {
            var users = await _context.TeamMembers.Where(x => x.TeamId == teamId && x.User.RoleId != (int)UserRole.TeamCoach)
                                    .Select(x => new UserModel { Id = x.UserId, RoleId = x.User.RoleId, FirstName = x.User.FirstName, MiddleName = x.User.MiddleName, LastName = x.User.LastName, PhoneNumber = x.User.PhoneNumber, BirthDate = x.User.BirthDate, Email = x.User.Email, Height = x.User.Height, Weight = x.User.Weight, IsSelected = x.IsSelected }).ToListAsync();


            return users;
        }
        public async Task<List<SelectListItem>> GetUserSelectList(long Id)
        {
            var user = await _context.User
                                   .Select(x => new SelectListItem { Value = x.Id.ToString() }).ToListAsync();

            return user;
        }
        public async Task<bool> Insert(UserModel model)
        {
            var user = new Data.Entities.User { FirstName = model.FirstName, MiddleName = model.MiddleName, LastName = model.LastName, BirthDate = model.BirthDate, Height = model.Height, Email = model.Email, PhoneNumber = model.PhoneNumber, RoleId = model.RoleId, Weight = model.Weight };
            _context.User.Add(user);

            var teamMember = new Data.Entities.TeamMember { TeamId = model.TeamId, User = user };
            _context.TeamMembers.Add(teamMember);

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> Update(UserModel model)
        {
            var user = await _context.User
                                    .Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.MiddleName = model.MiddleName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                user.Password = model.Password;
                user.Height = model.Height;
                user.Weight = model.Weight;
                user.RoleId = model.RoleId;
            }

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> SelectPlayers(long teamId, long[] userIds)
        {
            var teamMembers = await _context.TeamMembers
                                    .Where(x => x.TeamId == teamId).ToListAsync();

            if (teamMembers != null)
            {
                foreach (var teamMember in teamMembers)
                {
                    if (userIds.Contains(teamMember.UserId))
                        teamMember.IsSelected = true;
                    else
                    {
                        teamMember.IsSelected = false;
                    }
                }
            }

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> Delete(long id)
        {
            var teamMembers = _context.TeamMembers
                                    .Where(x => x.UserId == id);

            _context.TeamMembers.RemoveRange(teamMembers);

            var user = _context.User.Find(id);

            _context.User.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> SetPlayerAsCaption(long teamId, long userId)
        {
            var teamMembers = _context.TeamMembers
                                    .Where(x => x.TeamId == teamId && x.User.RoleId != (int)UserRole.TeamCoach);

            var teamMember = await teamMembers.Where(x => x.UserId == userId).FirstOrDefaultAsync();

            if (teamMember != null)
            {
                foreach (var member in teamMembers.Where(x => x.User.RoleId == (int)UserRole.Caption))
                {
                    member.User.RoleId = (int)UserRole.Player;
                }

                teamMember.User.RoleId = (int)UserRole.Caption;
            }

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<UserModel> CheckUserExists(string username, string password)
        {
            return await _context.User
                                    .Where(x => x.Email == username && x.Password == password)
                                    .Select(x => new UserModel { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, BirthDate = x.BirthDate, PhoneNumber = x.PhoneNumber, Email = x.Email, Password = x.Password, Height = x.Height, Weight = x.Weight, RoleId = x.RoleId, RoleName = ((UserRole)x.RoleId).ToString() }).FirstOrDefaultAsync();
        }

        public bool CheckEmailIdExists(string email)
        {
            return _context.User.Any(x => x.Email.ToLower() == email.ToLower());
        }
        public async Task<bool> IsUserWithEmailIdExists(string email)
        {
            return await _context.User.AnyAsync(x => x.Email.ToLower() == email.ToLower());
        }

        public async Task<bool> ChangePassword(string email, string password)
        {
            var user = await _context.User
                                    .Where(x => x.Email == email).FirstOrDefaultAsync();

            if (user != null)
                user.Password = password;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}

