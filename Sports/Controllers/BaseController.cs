using Sports.Business.Repositories.Models;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Sports.Controllers
{
    public class BaseController : Controller
    {
        public UserModel LoggedInUser => HttpContext.User.Identity.IsAuthenticated ? (UserModel)new JavaScriptSerializer().Deserialize(((FormsIdentity)(HttpContext.User.Identity)).Ticket.UserData, typeof(UserModel)) : null;
        public long LoggedInUserId => (LoggedInUser?.Id ?? 0);
    }
}