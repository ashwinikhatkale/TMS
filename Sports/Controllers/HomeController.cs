using Sports.Models;
using System;
using System.Web.Mvc;

namespace Sports.Controllers
{
    [LogCustomExceptionFilter]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            throw new Exception("Something went wrong");
        }
        public ActionResult About()
        {
            throw new NullReferenceException();
        }
        public ActionResult Contact()
        {
            throw new DivideByZeroException();
        }
    }
}