using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Microsoft.AspNet.Identity;
using SoftwareEngineeringP1.DataAccess;
using SoftwareEngineeringP1.Models;

namespace SoftwareEngineeringP1.Controllers
{
    public class HomeController : Controller
    {
       public ActionResult Index(SearchPageForm form)
        {
            if (form.flightResults == null)
            {
                form.flightResults=new List<Flight>();
            }
            return View(form);
        }

        public ActionResult FlightManager()
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

        public ActionResult AllFlights()
        {
            FlightDataAccess fda = new FlightDataAccess();
            return View(fda.GetAllFlights());
        }

        public ActionResult Flights(List<Flight> flights)
        {
            FlightDataAccess fda = new FlightDataAccess();
            var model = fda.GetAllFlights();
            return View(flights);
        }

        [HttpPost]
        public ActionResult SearchFlights(SearchPageForm form)
        {
            FlightDataAccess fda = new FlightDataAccess();

            var flights = fda.SearchFlights(form.StartCity, form.DestinationCity, form.Country);

            return  PartialView("_Partial/Flights", flights);
        }

        [HttpGet]
        public ActionResult Flight(int id)
        {
            FlightDataAccess fda = new FlightDataAccess();
            var flight = fda.GetFlight(id);
            return View(flight);
        }
    }
}