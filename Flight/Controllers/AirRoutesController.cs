using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Flight.Models;

namespace Flight.Controllers
{
    public class AirRoutesController : Controller
    {
        private readonly FlightContext _context;

        public AirRoutesController(FlightContext context)
        {
            _context = context;
        }

        // GET: AirRoutes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AirRoutes.ToListAsync());
        }

        // GET: AirRoutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airRoutes = await _context.AirRoutes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (airRoutes == null)
            {
                return NotFound();
            }

            return View(airRoutes);
        }

        // GET: AirRoutes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AirRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,From,To,Stops,Price,departing,arrival,seatsAvailable")] AirRoutes airRoutes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airRoutes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airRoutes);
        }

        // GET: AirRoutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airRoutes = await _context.AirRoutes.SingleOrDefaultAsync(m => m.ID == id);
            if (airRoutes == null)
            {
                return NotFound();
            }
            return View(airRoutes);
        }

        // POST: AirRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,From,To,Stops,Price,departing,arrival,seatsAvailable")] AirRoutes airRoutes)
        {
            if (id != airRoutes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airRoutes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirRoutesExists(airRoutes.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(airRoutes);
        }

        // GET: AirRoutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airRoutes = await _context.AirRoutes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (airRoutes == null)
            {
                return NotFound();
            }

            return View(airRoutes);
        }

        // POST: AirRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airRoutes = await _context.AirRoutes.SingleOrDefaultAsync(m => m.ID == id);
            _context.AirRoutes.Remove(airRoutes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirRoutesExists(int id)
        {
            return _context.AirRoutes.Any(e => e.ID == id);
        }
    }
}
