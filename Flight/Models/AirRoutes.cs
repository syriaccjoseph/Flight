using System;
using System.ComponentModel.DataAnnotations;
namespace Flight.Models
{
    public class AirRoutes
    {
        public AirRoutes()
        {
        }

        public int ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Stops { get; set; }
        public int Price { get; set; }

        [Display(Name = "Departing Date"), DataType(DataType.Date)]
        public DateTime departing { get; set; }

        [Display(Name = "Arrival Date"), DataType(DataType.Date)]
        public DateTime arrival { get; set; }

        [Display(Name = "Seats Available"), DataType(DataType.Text)]
        public string seatsAvailable { get; set; }
    }
}