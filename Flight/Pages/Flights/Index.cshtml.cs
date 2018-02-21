using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Flight.Models;

namespace Flight.Pages.Flights
{
    public class IndexModel : PageModel
    {
        private readonly Flight.Models.FlightContext _context;

        public IndexModel(Flight.Models.FlightContext context)
        {
            _context = context;
        }

        public IList<Flight.Models.Flight> Flight { get;set; }

        public async Task OnGetAsync()
        {
            Flight = await _context.Flight.ToListAsync();
        }
    }
}
