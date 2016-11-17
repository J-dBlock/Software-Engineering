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
       public ActionResult Index()
        {
            //if (form.flightResults == null)
            //{
            //    form.flightResults=new List<Flight>();
            //}
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

        [HttpPost]
        public ActionResult AddFlights(AddFlightForm form)
        {
            FlightDataAccess fda = new FlightDataAccess();
            fda.addFlight(form.startingIdNumber, form.endingIdNumber, form.time, form.price);
            return RedirectToAction("Index", "Home");
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


        #region |  Reserved for AJAX Method for inserting data.  |

        [HttpPost]
        public ActionResult SearchFlights(SearchPageForm form)
        {
            FlightDataAccess fda = new FlightDataAccess();

            var flights = fda.SearchFlights(form.StartCity, form.DestinationCity, form.Country);

            return PartialView("_Partial/Flights", flights);
        }


        [HttpGet]
        public ActionResult Flight(int id)
        {
            FlightDataAccess fda = new FlightDataAccess();
            var flight = fda.GetFlight(id);
            return View(flight);
        }

        [HttpPost]
        public ActionResult GetFlightViewer(int flightId)
        {
            FlightDataAccess fda = new FlightDataAccess();
            var flight = fda.GetFlight(flightId);

           
            if (flight != null)
            {
                var pageForm = new FlightUserPageForm()
                {
                    Flight = flight,
                    IsAdmin = User.IsInRole("Admin")
                };

                return PartialView("_Partial/FlightViewer", pageForm);
            }
            return null;
        }

        [HttpPost]
        public ActionResult GetEditFlightViewer(int flightId)
        {
            FlightDataAccess fda = new FlightDataAccess();

            var flight = fda.GetFlight(flightId);
            if (flight != null)
            {
                return PartialView("_Partial/EditFlightViewer", flight);
            }
            return null;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void EditFlight(Flight flight)
        {
            FlightDataAccess fda = new FlightDataAccess();

            fda.AddOrUpdateFlight(flight);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public void DeleteFlights(int flightID)
        {
            FlightDataAccess fda = new FlightDataAccess();
            fda.DeleteFlights(flightID);
        }

        #endregion
    }
}