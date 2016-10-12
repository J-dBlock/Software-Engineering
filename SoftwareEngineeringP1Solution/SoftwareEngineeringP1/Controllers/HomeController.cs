using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoftwareEngineeringP1.DataAccess;
using SoftwareEngineeringP1.Models;
using SoftwareEngineeringP1.State;

namespace SoftwareEngineeringP1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StateContainer.UserId = 34;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.StateUser = StateContainer.UserId;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}