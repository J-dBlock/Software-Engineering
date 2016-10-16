using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SoftwareEngineeringP1.DataAccess;
using SoftwareEngineeringP1.Models;

namespace SoftwareEngineeringP1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            var userId = User.Identity.GetUserId();
            // Example if how to check if a User has the role of Admin.
            if (User.IsInRole("Admin"))
            {
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}