using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cautsalon.Models;
using cautsalonapp.Data;

namespace cautsalonapp.Controllers
{
    public class serviciiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public serviciiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: servicii
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servicii.ToListAsync());
        }

        // GET: servicii/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicii = await _context.Servicii
                .FirstOrDefaultAsync(m => m.Cod_serviciu == id);
            if (servicii == null)
            {
                return NotFound();
            }

            return View(servicii);
        }

        // GET: servicii/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: servicii/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cod_serviciu,Denumire,Pret")] Servicii servicii)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicii);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicii);
        }

        // GET: servicii/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicii = await _context.Servicii.FindAsync(id);
            if (servicii == null)
            {
                return NotFound();
            }
            return View(servicii);
        }

        // POST: servicii/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cod_serviciu,Denumire,Pret")] Servicii servicii)
        {
            if (id != servicii.Cod_serviciu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicii);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiciiExists(servicii.Cod_serviciu))
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
            return View(servicii);
        }

        // GET: servicii/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicii = await _context.Servicii
                .FirstOrDefaultAsync(m => m.Cod_serviciu == id);
            if (servicii == null)
            {
                return NotFound();
            }

            return View(servicii);
        }

        // POST: servicii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicii = await _context.Servicii.FindAsync(id);
            _context.Servicii.Remove(servicii);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiciiExists(int id)
        {
            return _context.Servicii.Any(e => e.Cod_serviciu == id);
        }
    }
}
