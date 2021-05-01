using Sports.Business.Repositories.Interfaces;
using Sports.Controllers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sports.Areas.Player.Controllers
{
    [Authorize]
    public class TeamController : BaseController
    {
        private readonly ITeamRepository _teamRepository;
        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public async Task<ActionResult> Index()
        {
            var model = await _teamRepository.GetTeams(LoggedInUserId);
            
            return View(model);
        }

    }
}