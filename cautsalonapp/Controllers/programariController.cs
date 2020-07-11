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
            var salon = await _context.Saloane.Where(s => s.Firma.Webuser.UserName == User.Identity.Name).FirstOrDefaultAsync();
            if (salon != null)
            {
                var query = await (from p in _context.Programari
                                   join s in _context.Saloane
                                   on p.Salon.Cod_salon equals s.Cod_salon
                                   join se in _context.Servicii
                                   on p.Serviciu.Cod_serviciu equals se.Cod_serviciu
                                   join cl in _context.Clienti
                                   on p.Client.Cod_client equals cl.Cod_client
                                   where s.Firma.Webuser.UserName == User.Identity.Name
                                   select new { p.Data, p.Observatii, p.Serviciu, p.Client, p.Cod_programare , p.Confirmata, p.Status, p.Motiv_anulare }).ToListAsync();
                List<Programari> programari = new List<Programari>();
                foreach (var item in query)
                {
                    var programare = new Programari
                    {
                        Cod_programare = item.Cod_programare,
                        Data = item.Data,
                        Observatii = item.Observatii,
                        Client = item.Client,
                        Serviciu = item.Serviciu,
                        Confirmata = item.Confirmata,
                        Status = item.Status,
                        Motiv_anulare = item.Motiv_anulare
                    };
                    programari.Add(programare);
                }
                return View(programari);
                
            }
            else
            {


                var query = await (from p in _context.Programari
                                   join s in _context.Saloane
                                   on p.Salon.Cod_salon equals s.Cod_salon
                                   join se in _context.Servicii
                                   on p.Serviciu.Cod_serviciu equals se.Cod_serviciu
                                   where p.Client.Webuser.UserName == User.Identity.Name
                                   select new { p.Data, p.Observatii, p.Serviciu, p.Salon, p.Cod_programare, p.Confirmata, p.Status, p.Motiv_anulare }).ToListAsync();
                List<Programari> programari = new List<Programari>();
                foreach (var item in query)
                {
                    var programare = new Programari
                    {
                        Cod_programare = item.Cod_programare,
                        Data = item.Data,
                        Observatii = item.Observatii,
                        Salon = item.Salon,
                        Serviciu = item.Serviciu,
                        Confirmata = item.Confirmata,
                        Status = item.Status,
                        Motiv_anulare = item.Motiv_anulare
                    };
                    programari.Add(programare);
                }
                return View(programari);
            }
        }

        // GET: programari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = await (from p in _context.Programari
                               join s in _context.Saloane
                               on p.Salon.Cod_salon equals s.Cod_salon
                               join se in _context.Servicii
                               on p.Serviciu.Cod_serviciu equals se.Cod_serviciu
                               where p.Client.Webuser.UserName == User.Identity.Name
                               where p.Cod_programare == id
                               select new { p.Data, p.Observatii, p.Serviciu, p.Salon, p.Cod_programare, p.Status, p.Motiv_anulare }).FirstOrDefaultAsync();


            var programare = new Programari
            {
                Cod_programare = query.Cod_programare,
                Data = query.Data,
                Observatii = query.Observatii,
                Salon = query.Salon,
                Serviciu = query.Serviciu,
                Status = query.Status,
                Motiv_anulare = query.Motiv_anulare
            };

            return View(programare);
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
        public async Task<IActionResult> Confirma(int? id)
        {
            var programari = await _context.Programari.Where(x =>  x.Cod_programare == id).FirstOrDefaultAsync();
            programari.Status = "Confirmata";
            programari.Confirmata = true;
            _context.Update(programari);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Anuleaza(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programari = await _context.Programari.Where(x => x.Cod_programare == id).FirstOrDefaultAsync();
            if (programari == null)
            {
                return NotFound();
            }
            return View(programari);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Anuleaza(int id, [Bind("Cod_programare,Motiv_anulare")] Programari programari)
        {
           
             var query = await (from p in _context.Programari
                                          join s in _context.Saloane
                                          on p.Salon.Cod_salon equals s.Cod_salon
                                          join se in _context.Servicii
                                          on p.Serviciu.Cod_serviciu equals se.Cod_serviciu                                          
                                          where p.Cod_programare == id
                                          select new { p.Data, p.Observatii, p.Serviciu, p.Salon, p.Cod_programare, p.Status, p.Motiv_anulare }).FirstOrDefaultAsync();


            var programare = new Programari
            {
                Cod_programare = query.Cod_programare,
                Data = query.Data,
                Observatii = query.Observatii,
                Salon = query.Salon,
                Serviciu = query.Serviciu,
                Status = "Anulata",
                Confirmata = false,
                Motiv_anulare = programari.Motiv_anulare
            };           
            _context.Update(programare);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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
