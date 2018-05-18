using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flight.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

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

                var value = HttpContext.Session.GetString("pref");
                var pref = value == null ? null :
                JsonConvert.DeserializeObject<GroupIndexViewModel>(value);

                if(pref != null) 
                {
                    if (pref.Filters[0].Prefa == "stops" && pref.Filters[0].Prefb == "price")
                    {
                        flights = flights.Where(s => (s.From.Contains(fromString))
                                                && s.To.Contains(toString)
                                                && s.Stops == 0
                                                && s.Price < 500);
                    }
                }
                else 
                {
                    flights = flights.Where(s => (s.From.Contains(fromString))
                        && s.To.Contains(toString));
                    /*
                    && Int32.Parse(s.seatsAvailable) > NosValue
                    && DateTime.Compare(s.departing, departDate) < 0
                    && DateTime.Compare(s.arrival, returnDate) > 0);
                    */
                }

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

        public IActionResult Preferences(GroupIndexViewModel model, String submit, int minseats, int maxseats)
        {
            var value = HttpContext.Session.GetString("pref");
            var pref = value == null ? new GroupIndexViewModel() :
                JsonConvert.DeserializeObject<GroupIndexViewModel>(value);

            System.Console.WriteLine("min seats and max seats " + minseats + maxseats);
            
            if(submit == "add" && pref.Filters.Count <= 2) 
            {
     
                pref.Filters.Add(new Filter());
                System.Console.WriteLine("THE NUMBER OF FILTERS : " + pref.Filters.Count);
                HttpContext.Session.SetString("pref", JsonConvert.SerializeObject(pref));
                
            }

            if (submit == "change")
            {
                pref = model;
                HttpContext.Session.SetString("pref", JsonConvert.SerializeObject(model));
            }
            HttpContext.Session.SetString("pref", JsonConvert.SerializeObject(pref));
            return View(pref);
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

        public ActionResult PartiaView() {


            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
