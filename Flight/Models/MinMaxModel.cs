using System;
using System.Collections.Generic;
namespace Flight.Models
{

    public class MinMaxModel
    {
        public List<Filter> Filters { get; set; }



        public MinMaxModel()
        {
            Filters = new List<Filter>();
        }

    }

}