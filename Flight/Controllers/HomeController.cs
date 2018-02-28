using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flight.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight.Controllers
{
    public class HomeController : Controller
    {

        private readonly FlightContext _context;

        public HomeController(FlightContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string fromString, string toString, int NosValue, DateTime departDate, DateTime returnDate)
        {
            var flights = from m in _context.AirRoutes
                         select m;

            if (!String.IsNullOrEmpty(fromString) && !String.IsNullOrEmpty(toString) )
            {
                //Console.WriteLine("Number of seats from client side :s " + NosValue);
                flights = flights.Where(s => (s.From.Contains(fromString))
                                        && s.To.Contains(toString)
                                        && Int32.Parse(s.seatsAvailable) > NosValue
                                        && DateTime.Compare(s.departing, departDate) < 0
                                        && DateTime.Compare(s.arrival, returnDate) > 0);
            }

            return View(await flights.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Search()
        {
            
            return View();
        }

        public IActionResult Combined()
        {

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public PartialViewResult List() {
            var flights = from m in _context.AirRoutes
                          select m;
            /*
            if (!String.IsNullOrEmpty(searchString))
            {
                flights = flights.Where(s => s.From.Contains(searchString));
            }
            */

            return PartialView("List", flights.ToListAsync());
        }
        public PartialViewResult SearchBar()
        {
            return PartialView();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
