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
using Flight.Antlr;
using Antlr4.Runtime;

using System.Net.Http;

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

            float stopmin = 0, stopmax = 1, seatmin = 0, seatmax = 1, pricemin = 0, pricemax = 1;

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
                List<float[]> CompromiseList = new List<float[]>();


                List<float[]> PriceList2 = new List<float[]>();
                List<float[]> StopList2 = new List<float[]>();
                List<float[]> SeatList2 = new List<float[]>();

                List<float[]> MinList2 = new List<float[]>();
                List<float[]> MaxList2 = new List<float[]>();
                List<float[]> CompromiseList2 = new List<float[]>();

                List<float[]> FinalList1 = new List<float[]>();
                List<float[]> FinalList2 = new List<float[]>();

                List<float[]> GlobalList= new List<float[]>();


                if (pref != null)
                {
                    System.Console.WriteLine("filter count :" + pref.Filters.Count());
                    foreach (Preference preference in pref.Filters[0].Prefs)
                    {
                        // TODO : change it to check more filters. Now just 1.

                        if (preference.Pref == "stops")
                        {
                            stopmin = preference.MinMax.Min;
                            stopmax = preference.MinMax.Max;
                            System.Console.WriteLine("stops :" + stopmin);
                        }
                        else if (preference.Pref == "seats")
                        {
                            seatmin = preference.MinMax.Min;
                            seatmax = preference.MinMax.Max;
                            System.Console.WriteLine("seats :" + seatmin);
                        }
                        else if (preference.Pref == "price")
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
                        }
                        else if (PriceValue > 1)
                        {
                            PriceValue = 1;
                        }

                        PriceList.Add(new float[] { i, PriceValue });

                        //StopArray[i, 0] = flightList[i].ID;
                        //StopList calculation

                        float StopValue = (float)(flightList[i].Stops - stopmin) / (stopmax - stopmin);
                        if (StopValue < 0)
                        {
                            StopValue = 0;
                        }
                        else if (StopValue > 1)
                        {
                            StopValue = 1;
                        }

                        StopList.Add(new float[] { i, StopValue });

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

                        SeatList.Add(new float[] { i, SeatValue });
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

                        CompromiseList.Add(new float[] { PriceList[i][0], (float)(PriceList[i][1] + StopList[i][1] + SeatList[i][1]) / 3 });

                    }

                    MinList.Sort((row1, row2) => (int)((row2[1] * 10000.0) - (row1[1] * 10000.0)));

                    MaxList.Sort((row1, row2) => (int)((row2[1] * 10000.0) - (row1[1] * 10000.0)));

                    CompromiseList.Sort((row1, row2) => (int)((row2[1] * 10000.0) - (row1[1] * 10000.0)));




                    List<AirRoutes> airRoutes = new List<AirRoutes>();

                    if (pref.Filters[0].AndOr == "and")
                    {
                        FinalList1 = MinList;
                        foreach (var val in MinList)
                        {
                            //var a = (int)val[0];
                            airRoutes.Add(flightList[(int)val[0]]);
                            //airRoutes.
                        }
                    }
                    if (pref.Filters[0].AndOr == "or")
                    {
                        FinalList1 = MaxList;

                        //for (int i = 0; i < MaxArray.Length; i++)
                        //{
                        //    airRoutes.Add(flightList[MaxArray[i, 1]]);
                        //}

                        foreach (float[] val in MaxList)
                        {
                            airRoutes.Add(flightList[(int)val[0]]);
                        }
                    }

                    if (pref.Filters[0].AndOr == "compromise")
                    {
                        FinalList1 = CompromiseList;

                        //for (int i = 0; i < MaxArray.Length; i++)
                        //{
                        //    airRoutes.Add(flightList[MaxArray[i, 1]]);
                        //}

                        foreach (float[] val in CompromiseList)
                        {
                            airRoutes.Add(flightList[(int)val[0]]);
                        }
                    }




                    if(pref.Filters.Count() > 1) {

                        System.Console.WriteLine("filter count :" + pref.Filters.Count());

                        foreach (Preference preference in pref.Filters[1].Prefs)
                        {
                            // TODO : change it to check more filters. Now just 1.

                            if (preference.Pref == "stops")
                            {
                                stopmin = preference.MinMax.Min;
                                stopmax = preference.MinMax.Max;
                                System.Console.WriteLine("stops :" + stopmin);
                            }
                            else if (preference.Pref == "seats")
                            {
                                seatmin = preference.MinMax.Min;
                                seatmax = preference.MinMax.Max;
                                System.Console.WriteLine("seats :" + seatmin);
                            }
                            else if (preference.Pref == "price")
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
                            }
                            else if (PriceValue > 1)
                            {
                                PriceValue = 1;
                            }

                            PriceList2.Add(new float[] { i, PriceValue });

                            //StopArray[i, 0] = flightList[i].ID;
                            //StopList calculation

                            float StopValue = (float)(flightList[i].Stops - stopmin) / (stopmax - stopmin);
                            if (StopValue < 0)
                            {
                                StopValue = 0;
                            }
                            else if (StopValue > 1)
                            {
                                StopValue = 1;
                            }

                            StopList2.Add(new float[] { i, StopValue });

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

                            SeatList2.Add(new float[] { i, SeatValue });
                        }

                        for (int i = 0; i < flightList.Count(); i++)
                        {
                            //MinArray[i, 0] = PriceArray[i, 0];
                            //MaxArray[i, 0] = PriceArray[i, 0];

                            //MinArray[i, 1] = Math.Min(Math.Min(PriceArray[i, 1], StopArray[i, 1]), SeatArray[i, 1]);
                            MinList2.Add(new float[] { PriceList2[i][0], Math.Min(Math.Min(PriceList2[i][1], StopList2[i][1]), SeatList2[i][1]) });

                            //Array.Sort(MinArray);
                            //MaxArray[i, 1] = Math.Max(Math.Max(PriceArray[i, 1], StopArray[i, 1]), SeatArray[i, 1]);
                            //Array.Sort(MaxArray);

                            MaxList2.Add(new float[] { PriceList2[i][0], Math.Max(Math.Max(PriceList2[i][1], StopList2[i][1]), SeatList2[i][1]) });

                            CompromiseList2.Add(new float[] { PriceList2[i][0], (float)(PriceList2[i][1] + StopList2[i][1] + SeatList2[i][1]) / 3 });

                        }

                        MinList2.Sort((row1, row2) => (int)((row2[1] * 10000.0) - (row1[1] * 10000.0)));

                        MaxList2.Sort((row1, row2) => (int)((row2[1] * 10000.0) - (row1[1] * 10000.0)));

                        CompromiseList2.Sort((row1, row2) => (int)((row2[1] * 10000.0) - (row1[1] * 10000.0)));


                        for (int i = 0; i < flightList.Count(); i++)
                        {

                            System.Console.WriteLine("min list 2  :" + MinList2[i][0] + "  " + MinList2[i][1]);

                        }


                        System.Console.WriteLine("global and/or :" + pref.Filters[0].GlobalAndOr);

                        airRoutes = new List<AirRoutes>();

                        if (pref.Filters[1].AndOr == "and")
                        {
                            FinalList2 = MinList2;

                            //foreach (var val in MinList)
                            //{
                            //    //var a = (int)val[0];
                            //    airRoutes.Add(flightList[(int)val[0]]);
                            //    //airRoutes.
                            //}
                        }
                        if (pref.Filters[1].AndOr == "or")
                        {
                            FinalList2 = MaxList2;

                            //for (int i = 0; i < MaxArray.Length; i++)
                            //{
                            //    airRoutes.Add(flightList[MaxArray[i, 1]]);
                            //}

                            //foreach (float[] val in MaxList)
                            //{
                            //    airRoutes.Add(flightList[(int)val[0]]);
                            //}
                        }

                        if (pref.Filters[1].AndOr == "compromise")
                        {

                            FinalList2 = CompromiseList2;

                            //for (int i = 0; i < MaxArray.Length; i++)
                            //{
                            //    airRoutes.Add(flightList[MaxArray[i, 1]]);
                            //}

                            //foreach (float[] val in CompromiseList)
                            //{
                            //    airRoutes.Add(flightList[(int)val[0]]);
                            //}
                        }


                        FinalList1.Sort((row1, row2) => (int)((row2[0]) - (row1[0])));
                        FinalList2.Sort((row1, row2) => (int)((row2[0]) - (row1[0])));



                        if (pref.Filters[0].GlobalAndOr == "and")
                        {
                            GlobalList = new List<float[]>();

                            for (int i = 0; i < flightList.Count(); i++)
                            {
                                GlobalList.Add(new float[] { FinalList1[i][0], Math.Min(FinalList1[i][1], FinalList2[i][1]) });

                            }

                            foreach (float[] val in GlobalList)
                            {
                                airRoutes.Add(flightList[(int)val[0]]);
                            }
                        }

                        if (pref.Filters[0].GlobalAndOr == "or")
                        {

                            GlobalList = new List<float[]>();

                            for (int i = 0; i < flightList.Count(); i++)
                            {
                                GlobalList.Add(new float[] { FinalList1[i][0], Math.Max(FinalList1[i][1], FinalList2[i][1]) });

                            }

                            foreach (float[] val in GlobalList)
                            {
                                airRoutes.Add(flightList[(int)val[0]]);
                            }
                        }

                        for (int i = 0; i < flightList.Count(); i++)
                        {
                            
                            System.Console.WriteLine("global list :" + GlobalList[i][0] + "  " + GlobalList[i][1]);


                        }

                        for (int i = 0; i < flightList.Count(); i++)
                        {

                            System.Console.WriteLine("final 1 list :" + FinalList1[i][0] + "  " + FinalList1[i][1]);

                        }

                        for (int i = 0; i < flightList.Count(); i++)
                        {

                            System.Console.WriteLine("final 2 list :" + FinalList2[i][0] + "  " +  FinalList2[i][1]);

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

        //[HttpGet("[action]/{city}")]
        //public async Task<IActionResult> City(string city)


        public async Task<IActionResult> TimeTable(string airport)
        {
            using (var client = new HttpClient())
            {
                try
                {

                    client.BaseAddress = new Uri("http://aviation-edge.com");

                    //var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);

                    //return Ok(new
                    //{
                    //    //Temp = rawWeather.Main.Temp,
                    //    //Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)),
                    //    //City = rawWeather.Name
                    //});

                    if (!String.IsNullOrEmpty(airport))
                    {

                        var response = await client.GetAsync($"/api/public/flights?key=fecfc5-f01ae4-a0a018-c4e442-1279f7&iataCode={airport}&type=departure");
                        response.EnsureSuccessStatusCode();

                        var stringResult = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("Server result " + stringResult);

                        ViewData["Message"] = stringResult;

                    }
                        return View();

                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
        }

        public ActionResult NewDesign(String preference)
        {

            if (!String.IsNullOrEmpty(preference) )
            {

                AntlrInputStream inputStream = new AntlrInputStream(preference);
                PreferenceLanguageLexer lexer = new PreferenceLanguageLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);

                PreferenceLanguageParser parser = new PreferenceLanguageParser(commonTokenStream);
                PreferenceLanguageParser.PreferenceContext preferencContext = parser.preference();

                PreferenceVisitor visitor = new PreferenceVisitor();
                visitor.Visit(preferencContext);

                foreach (var pref in visitor.Preferences)
                {
                    Console.WriteLine("pref", pref.PreferenceParsedText);
                }
            }


            

            //Prefe
            //SpeakParser.LineContext context
            //Pre SpeakLexer.NameContext name = context.name();
            //OpinionContext opinion = context.opinion();

            //SpeakLine line = new SpeakLine() { Person = name.GetText(), Text = opinion.GetText().Trim('"') };
            //Lines.Add(line);

            //line;
            //Prefere

            //Console.WriteLine("preferences" + preference);

            return View();

        }

    }

}
