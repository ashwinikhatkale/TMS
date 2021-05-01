using Sports.Business.Repositories.Interfaces;
using Sports.Data.Entities;
using Sports.Helper;
using Sports.Models;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Sports.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(Request.Form["ReturnUrl"]))
                {
                    return RedirectToAction(Request.Form["ReturnUrl"].Split('/')[2]);
                }
                else
                {
                    if (LoggedInUser.RoleId == (int)UserRole.TeamCoach)
                    {
                        return RedirectToAction("Index", "Team", new { area = "TeamCoach" });
                    }
                    else if (LoggedInUser.RoleId == (int)UserRole.Caption)
                    {
                        return RedirectToAction("Index", "Team", new { area = "Caption" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Team", new { area = "Player" });
                    }
                }
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginModel model)
        {
            var user = await _userRepository.CheckUserExists(model.UserName, model.Password);

            if (user != null)
            {
                var serializer = new JavaScriptSerializer();
                string userData = serializer.Serialize(user);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.FirstName + " " + user.LastName, DateTime.Now, DateTime.Now.AddMinutes(2880), true, userData, FormsAuthentication.FormsCookiePath);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                if (!string.IsNullOrEmpty(Request.Form["ReturnUrl"]))
                {
                    return RedirectToAction(Request.Form["ReturnUrl"].Split('/')[2]);
                }
                else
                {
                    if (user.RoleId == (int)UserRole.TeamCoach)
                    {
                        return RedirectToAction("Index", "Team", new { area = "TeamCoach" });
                    }
                    else if (user.RoleId == (int)UserRole.Caption)
                    {
                        return RedirectToAction("Index", "Team", new { area = "Caption" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Team", new { area = "Player" });
                    }
                }
            }

            ModelState.AddModelError("", "Invalid Username or Password.");
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        public ActionResult ForgotPassword()
        {
            var model = new ForgotPasswordModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            try
            {
                var isUserExists = await _userRepository.IsUserWithEmailIdExists(model.EmailAddress, 0);

                if(!isUserExists)
                {
                    ModelState.AddModelError("EmailAddress", "User with entered email address does not exists.");
                    return View(model);
                }

                string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
                Random random = new Random();

                // Select one random character at a time from the string  
                // and create an array of chars  
                char[] chars = new char[6];
                for (int i = 0; i < 6; i++)
                {
                    chars[i] = validChars[random.Next(0, validChars.Length)];
                }

                var password = new string(chars);
                await _userRepository.ChangePassword(model.EmailAddress, password);

                var subject = "Password for Sports Application";
                var body = "Dear Student, <br/><br/>Password for <b>Sports Application</b> is <b>" + password + "</b>.<br/><br/>Regards,<br/><b>Sports Team</b>";

                EmailHelper.SendEmail(model.EmailAddress, subject,body);

                model.Message = "Temparary password has been sent on your email address.";
            }
            catch (Exception ex)
            {
                model.Message = "Error occurred while sending email. Please try again.";
            }

            return View(model);
        }
    }
}