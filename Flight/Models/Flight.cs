using System;
namespace Flight.Models
{
    public class Flight
    {
        public Flight()
        {
        }

        public int ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Stops { get; set; }
        public int Price { get; set; }
        public DateTime departing { get; set; }
        public DateTime arrival { get; set; }
        public string seatsAvailable { get; set; }
    }
}
