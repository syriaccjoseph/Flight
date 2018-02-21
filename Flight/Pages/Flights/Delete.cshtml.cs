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
    public class DeleteModel : PageModel
    {
        private readonly Flight.Models.FlightContext _context;

        public DeleteModel(Flight.Models.FlightContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Flight.Models.Flight Flight { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flight = await _context.Flight.SingleOrDefaultAsync(m => m.ID == id);

            if (Flight == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flight = await _context.Flight.FindAsync(id);

            if (Flight != null)
            {
                _context.Flight.Remove(Flight);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
