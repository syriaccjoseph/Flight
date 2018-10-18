using System;
using System.Collections.Generic;
namespace Flight.Models
{

    public class GroupIndexViewModel
    {
        public List<Filter> Filters { get; set; }

        public GroupIndexViewModel()
        {
            Filters = new List<Filter>();
        }

    }

    public class Filter
    {
        public int Id { get; set; }
        public List<Preference> Prefs { get; set; }
        public string AndOr { get; set; }
        public string GlobalAndOr { get; set; }
        public bool Selected { get; set; }

        public Filter() {
            Prefs = new List<Preference>();
        }

    }

    public class Preference
    {
        public String Pref { get; set; }
        public MinMax MinMax { get; set; }
    }

    public class MinMax 
    {
        public int Min  { get; set; }
        public int Max { get; set; }
        
    }
}