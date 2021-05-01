using Sports.Business.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sports.Business.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<TeamModel>> GetTeams(long playerId);
        Task<TeamModel> GetTeam(long id);
       
        Task<bool> Insert(TeamModel model);
        Task<bool> Update(TeamModel model);
        Task<bool> Delete(long id);
    }
}
