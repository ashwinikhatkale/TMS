using Sports.Business.Repositories.Interfaces;
using Sports.Business.Repositories.Models;
using Sports.Data.Entities;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sports.Areas.TeamCoach.Controllers
{
    [Authorize]
    public class PlayersController : Controller
    {
        private readonly IUserRepository _userRepository;
        public PlayersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ActionResult> Index(long teamId)
        {
            var model = await _userRepository.GetPlayers(teamId);
            ViewBag.TeamId = teamId;
            return View(model);
        }
        public async Task<ActionResult> Add(long teamId)
        {
            var model =new UserModel { TeamId = teamId, RoleId = (long)UserRole.Player };
            return View(model);
        }

        public async Task<ActionResult> Edit(long[] id)
        {
            var model = await _userRepository.GetUser(id);
            return View("Add", model);
        }
        [HttpPost]
        public async Task<ActionResult> Add(UserModel model)
        {
            if (model.Id > 0)
            {
                await _userRepository.Update(model);
            }
            else
            {
                await _userRepository.Insert(model);
            }

            return RedirectToAction("Index", new { UserId = model.RoleId });
        }

        public async Task<ActionResult> Delete(long id)
        {
            await _userRepository.Delete(id);
            return Json(new { isSuccess = true });
        }
        public async Task<ActionResult> SetAsCaption(long teamId, long userId)
        {
            await _userRepository.SetPlayerAsCaption(teamId, userId);
            return Json(new { isSuccess = true });
        }

        public async Task<ActionResult> IsEmailExist(string Email)
        {
            var isExist = await _userRepository.IsUserWithEmailIdExists(Email);
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
    }
}