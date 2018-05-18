using System;
using System.Collections.Generic;
namespace Flight.Models
{

    public class GroupIndexViewModel
    {
        public List<Filter> Filters { get; set; }



        public GroupIndexViewModel() {
            Filters = new List<Filter>();
        }

    }

    public class Filter
    {
        public int Id { get; set; }
        public string Prefa { get; set; }
        public string Prefb { get; set; }
        public string Prefc { get; set; }
        public string AndOr { get; set; }
        public bool Selected { get; set; }
    }

    public class MinMax
    {
        
    }
}