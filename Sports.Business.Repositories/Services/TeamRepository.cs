using Sports.Business.Repositories.Interfaces;
using Sports.Business.Repositories.Models;
using Sports.Data.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sports.Business.Repositories.Services
{
    public class TeamRepository : ITeamRepository
    {
        private readonly SportsContext _context;
        public TeamRepository(SportsContext context)
        {
            _context = context;
        }
        public async Task<TeamModel> GetTeam(long id)
        {
            var team = await _context.Teams
                                    .Where(x => x.Id == id)
                                    .Select(x => new TeamModel { TeamId = x.Id, TeamName = x.Name, Description = x.Description }).FirstOrDefaultAsync();

            return team;
        }
        public async Task<List<TeamModel>> GetTeams(long playerId)
        {
           return await _context.TeamMembers.Where(x => x.UserId == playerId)
                                    .Select(x => new TeamModel { TeamId = x.Team.Id, TeamName = x.Team.Name, Description = x.Team.Description }).ToListAsync();
        }
        public async Task<List<SelectListItem>> GetTeamSelectList(long Id)
        {
            var team = await _context.Teams
                                   .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToListAsync();

            return team;
        }
        public async Task<bool> Insert(TeamModel model)
        {
            var team = new Data.Entities.Team { Id = model.TeamId, Name = model.TeamName, Description = model.Description };
            _context.Teams.Add(team);

            var teamMember = new Data.Entities.TeamMember { Team = team, UserId = model.CoachId };
            _context.TeamMembers.Add(teamMember);

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> Update(TeamModel model)
        {
            var team = await _context.Teams
                                    .Where(x => x.Id == model.TeamId).FirstOrDefaultAsync();

            if (team != null)
            {
                team.Name = model.TeamName;
                team.Description = model.Description;
            }

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> Delete(long id)
        {
            var teamMembers = _context.TeamMembers
                                    .Where(x => x.TeamId == id);

            _context.TeamMembers.RemoveRange(teamMembers);

            var team = _context.Teams.Find(id);

            _context.Teams.Remove(team);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
