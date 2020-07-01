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
    public class firmeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public firmeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: firme
        public async Task<IActionResult> Index()
        {
            return View(await _context.Firme.ToListAsync());
        }

        // GET: firme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firme = await _context.Firme
                .FirstOrDefaultAsync(m => m.Cod_firma == id);
            if (firme == null)
            {
                return NotFound();
            }

            return View(firme);
        }

        // GET: firme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: firme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cod_firma,Denumire,Cui,Registrul_comertului")] Firme firme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(firme);
        }

        // GET: firme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firme = await _context.Firme.FindAsync(id);
            if (firme == null)
            {
                return NotFound();
            }
            return View(firme);
        }

        // POST: firme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cod_firma,Denumire,Cui,Registrul_comertului")] Firme firme)
        {
            if (id != firme.Cod_firma)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirmeExists(firme.Cod_firma))
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
            return View(firme);
        }

        // GET: firme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firme = await _context.Firme
                .FirstOrDefaultAsync(m => m.Cod_firma == id);
            if (firme == null)
            {
                return NotFound();
            }

            return View(firme);
        }

        // POST: firme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firme = await _context.Firme.FindAsync(id);
            _context.Firme.Remove(firme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FirmeExists(int id)
        {
            return _context.Firme.Any(e => e.Cod_firma == id);
        }
    }
}
