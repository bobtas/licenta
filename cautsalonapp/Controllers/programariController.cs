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
    public class programariController : Controller
    {
        private readonly ApplicationDbContext _context;

        public programariController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: programari
        public async Task<IActionResult> Index()
        {
            return View(await _context.Programari.ToListAsync());
        }

        // GET: programari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programari = await _context.Programari
                .FirstOrDefaultAsync(m => m.Cod_programare == id);
            if (programari == null)
            {
                return NotFound();
            }

            return View(programari);
        }

        // GET: programari/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: programari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cod_programare,Data,Observatii")] Programari programari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programari);
        }

        // GET: programari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programari = await _context.Programari.FindAsync(id);
            if (programari == null)
            {
                return NotFound();
            }
            return View(programari);
        }

        // POST: programari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cod_programare,Data,Observatii")] Programari programari)
        {
            if (id != programari.Cod_programare)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramariExists(programari.Cod_programare))
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
            return View(programari);
        }

        // GET: programari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programari = await _context.Programari
                .FirstOrDefaultAsync(m => m.Cod_programare == id);
            if (programari == null)
            {
                return NotFound();
            }

            return View(programari);
        }

        // POST: programari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programari = await _context.Programari.FindAsync(id);
            _context.Programari.Remove(programari);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramariExists(int id)
        {
            return _context.Programari.Any(e => e.Cod_programare == id);
        }
    }
}
