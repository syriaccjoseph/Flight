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

        public IActionResult Index(string fromString, string toString, int NosValue, DateTime departDate, DateTime returnDate)
        {
            var flights = from m in _context.AirRoutes
                         select m;
            var flightList = flights.ToList();

            int stopmin = 0;
            int stopmax = 1;
            int seatmin = 0;
            int seatmax = 1;
            int pricemin = 0;
            int pricemax = 1;

            if (!String.IsNullOrEmpty(fromString) && !String.IsNullOrEmpty(toString) )
            {
                //Console.WriteLine("Number of seats from client side :s " + NosValue);

                var value = HttpContext.Session.GetString("pref");
                var pref = value == null ? null :
                JsonConvert.DeserializeObject<GroupIndexViewModel>(value);

                flightList = flights.Where(s => (s.From.Contains(fromString))
                                           && s.To.Contains(toString)).ToList();
                int count = flights.Count();

                //todo: Using float[] for storing both id and val should be changed.
                List<float[]> PriceList = new List<float[]>();
                List<float[]> StopList = new List<float[]>();
                List<float[]> SeatList = new List<float[]>();

                List<float[]> MinList = new List<float[]>();
                List<float[]> MaxList = new List<float[]>();


                if(pref != null) 
                {
                    foreach (Preference preference in pref.Filters[0].Prefs) 
                    {
                        if (preference.Pref == "stops") {
                            stopmin = preference.MinMax.Min;
                            stopmax = preference.MinMax.Max;
                            System.Console.WriteLine("stops :" + stopmin);
                        } else if (preference.Pref == "seats")
                        {
                            seatmin = preference.MinMax.Min;
                            seatmax = preference.MinMax.Max;
                            System.Console.WriteLine("seats :" + seatmin);
                        } else if (preference.Pref == "price")
                        {
                            pricemin = preference.MinMax.Min;
                            pricemax = preference.MinMax.Max;
                            System.Console.WriteLine("price :" + pricemin);
                        }
                    }

                    //Price Calc
                    for (int i = 0; i < flightList.Count(); i++)
                    {

                        //PriceArray[i, 0] = flightList[i].ID;
                        //PriceList calculation

                        float PriceValue = (float)(flightList[i].Price - pricemin) / (pricemax - pricemin);
                        if (PriceValue < 0)
                        {
                            PriceValue = 0;
                        } else if (PriceValue > 1)
                        {
                            PriceValue = 1;                           
                        }

                        PriceList.Add(new float[] { flightList[i].ID, PriceValue });

                        //StopArray[i, 0] = flightList[i].ID;
                        //StopList calculation

                        float StopValue = (float)((int)(flightList[i].Stops - stopmin) / (stopmax - stopmin));
                        if (StopValue < 0)
                        {
                            StopValue = 0;
                        }
                        else if (StopValue > 1)
                        {
                            StopValue = 1;
                        }

                        StopList.Add(new float[] { flightList[i].ID, StopValue });

                        //SeatList calculation

                        float SeatValue = (float.Parse(flightList[i].seatsAvailable) - seatmin) / (seatmax - seatmin);

                        if (SeatValue < 0)
                        {
                            SeatValue = 0;
                        }
                        else if (SeatValue > 1)
                        {
                            SeatValue = 1;
                        }

                        SeatList.Add(new float[] { flightList[i].ID, SeatValue });
                    }

                    for (int i = 0; i < flightList.Count(); i++)
                    {
                        //MinArray[i, 0] = PriceArray[i, 0];
                        //MaxArray[i, 0] = PriceArray[i, 0];

                        //MinArray[i, 1] = Math.Min(Math.Min(PriceArray[i, 1], StopArray[i, 1]), SeatArray[i, 1]);
                        MinList.Add(new float[] { PriceList[i][0], Math.Min(Math.Min(PriceList[i][1], StopList[i][1]), SeatList[i][1]) });

                        //Array.Sort(MinArray);
                        //MaxArray[i, 1] = Math.Max(Math.Max(PriceArray[i, 1], StopArray[i, 1]), SeatArray[i, 1]);
                        //Array.Sort(MaxArray);

                        MaxList.Add(new float[] { PriceList[i][0], Math.Max(Math.Max(PriceList[i][1], StopList[i][1]), SeatList[i][1]) });

                    }

                    MinList.Sort((row1, row2) => (int)((row1[1] * 10000.0) - (row2[1] * 10000.0)));
                    MaxList.Sort((row1, row2) => (int)((row2[1] * 10000.0) - (row1[1] * 10000.0)));

                    List<AirRoutes> airRoutes = new List<AirRoutes>();

                    if (pref.Filters[0].AndOr == "and")
                    {

                        foreach (float[] val in MinList)
                        {
                            airRoutes.Add(flightList[(int)val[0]]);
                        }
                    }
                    if (pref.Filters[0].AndOr == "or")
                    {

                        //for (int i = 0; i < MaxArray.Length; i++)
                        //{
                        //    airRoutes.Add(flightList[MaxArray[i, 1]]);
                        //}

                        foreach (float[] val in MaxList)
                        {
                            airRoutes.Add(flightList[(int)val[0]]);
                        }
                    }
                    return View(airRoutes);
                }

                return View(flightList);
            }


            return View(flightList);
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

            if (submit == "add" && pref.Filters.Count < 2) 
            {
                    Filter filter = new Filter();
                    Preference preference1 = new Preference();
                    Preference preference2 = new Preference();
                    Preference preference3 = new Preference();
                    filter.Prefs.Add(preference1);
                    filter.Prefs.Add(preference2);
                    filter.Prefs.Add(preference3);

                    pref.Filters.Add(filter);
                    System.Console.WriteLine("THE NUMBER OF FILTERS : " + pref.Filters.Count);
                    HttpContext.Session.SetString("pref", JsonConvert.SerializeObject(pref));
                
            }

            if (submit == "change")
            {
                pref = model;
                HttpContext.Session.SetString("pref", JsonConvert.SerializeObject(model));
            }
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
