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

            };
            foreach (AirRoutes c in flights)
            {
                context.AirRoutes.Add(c);
            }
            context.SaveChanges();
        }
    }
}



