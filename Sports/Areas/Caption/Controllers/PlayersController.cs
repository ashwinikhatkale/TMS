using Sports.Business.Repositories.Interfaces;
using Sports.Helper;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sports.Areas.Caption.Controllers
{
    [Authorize(Roles = "Caption")]
    public class PlayersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        public PlayersController(IUserRepository userRepository, ITeamRepository teamRepository )
        {
            _userRepository = userRepository;
            _teamRepository = teamRepository;
        }
        public async Task<ActionResult> Index(long teamId)
        {
            var model = await _userRepository.GetPlayers(teamId);
            ViewBag.TeamId = teamId;
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> SelectPlayers(long teamId, long[] playerIds)
        {            
            await _userRepository.SelectPlayers(teamId, playerIds);
            var team = await _teamRepository.GetTeam(teamId);
            var players = await _userRepository.GetUserDetails(playerIds);

            foreach(var player in players)
            {
                var subject = $"Selection in the team {team.TeamName}";
                var body = $"Dear {(player.FirstName + " " + player.LastName)},<br/> We are delighted to inform you that you are selected in team { team.TeamName }. <br/>Congratulation for the selection!,<br/><br/><b>Sports Team</b>";

                EmailHelper.SendEmail(player.Email, subject, body);
            }
            
            return Json(new { isSuccess = true });
        }
    }
}