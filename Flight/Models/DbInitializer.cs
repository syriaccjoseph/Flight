using System;
using System.Linq;
namespace Flight.Models
{
    public class DbInitializer
    {
 
        public static void Initialize(FlightContext context)
        {
            context.Database.EnsureCreated();
            if (context.AirRoutes.Any())
            {
                return;
            }
            // Look for any course.

            var flights = new AirRoutes[]
            {
                new AirRoutes{ID=1050,From="Boston",To="San Fransisco", Stops=2, Price=566, arrival = new DateTime(), departing = new DateTime(), seatsAvailable = "10" },
                new AirRoutes{ID=1051,From="Boston",To="New York City", Stops=1, Price=966, arrival = new DateTime(), departing = new DateTime(), seatsAvailable = "10"},
                new AirRoutes{ID=1052,From="Chennai",To="Bangalore", Stops=5, Price=66, arrival = new DateTime(), departing = new DateTime(), seatsAvailable = "10"},
                new AirRoutes{ID=1053,From="Cochin",To="Boston", Stops=23, Price=25, arrival = new DateTime(), departing = new DateTime(), seatsAvailable = "10"},
                new AirRoutes{ID=1054,From="Boston",To="New York City", Stops=3, Price=1055, arrival = new DateTime(), departing = new DateTime(), seatsAvailable = "10"},
                new AirRoutes{ID=1055,From="Cochin",To="Boston", Stops=0, Price=500, arrival = new DateTime(), departing = new DateTime(), seatsAvailable = "5"},
                new AirRoutes{ID=1056,From="Cochin",To="Boston", Stops=0, Price=150, arrival = new DateTime(), departing = new DateTime(), seatsAvailable = "4"},
                new AirRoutes{ID=1057,From="Cochin",To="Boston", Stops=5, Price=1000, arrival = new DateTime(), departing = new DateTime(), seatsAvailable = "23"},
                new AirRoutes{ID=1058,From="Cochin",To="Boston", Stops=23, Price=245, arrival = new DateTime(), departing = new DateTime(), seatsAvailable = "453"},
                new AirRoutes{ID=1059,From="Cochin",To="Boston", Stops=234, Price=2342, arrival = new DateTime(), departing = new DateTime(), seatsAvailable = "445"},
                new AirRoutes{ID=1060,From="Cochin",To="Boston", Stops=453, Price=23, arrival = new DateTime(), departing = new DateTime(), seatsAvailable = "2"},

            };
            foreach (AirRoutes c in flights)
            {
                context.AirRoutes.Add(c);
            }
            context.SaveChanges();
        }
    }
}



