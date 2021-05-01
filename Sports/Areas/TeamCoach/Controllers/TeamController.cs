using Sports.Business.Repositories.Interfaces;
using Sports.Business.Repositories.Models;
using Sports.Controllers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sports.Areas.TeamCoach.Controllers
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
        public ActionResult Add()
        {
            var model = new TeamModel();
            return View(model);
        }
        public async Task<ActionResult> Edit(long id)
        {
            var model = await _teamRepository.GetTeam(id);
            return View("Add", model);
        }
        [HttpPost]
        public async Task<ActionResult> Add(TeamModel model)
        {
            model.CoachId = LoggedInUserId;

            if (model.TeamId > 0)
            {
                await _teamRepository.Update(model);
            }
            else
            {
                await _teamRepository.Insert(model);
            }

            return RedirectToAction("Index", new { TeamId = model.TeamId });
        }
        [HttpPost]
        public async Task<ActionResult> Delete(long id)
        {
            await _teamRepository.Delete(id);
            return Json(new { isSuccess = true });
        }
    }
}