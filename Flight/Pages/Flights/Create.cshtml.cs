using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Flight.Models;

namespace Flight.Pages.Flights
{
    public class CreateModel : PageModel
    {
        private readonly Flight.Models.FlightContext _context;

        public CreateModel(Flight.Models.FlightContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Flight.Models.Flight Flight { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Flight.Add(Flight);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}