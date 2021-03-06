﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cautsalon.Models;
using cautsalonapp.Data;
using Microsoft.AspNetCore.Identity;

namespace cautsalonapp.Controllers
{
    
    public class saloaneController : Controller
    {
        private readonly ApplicationDbContext _context;

        public saloaneController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Saloanes
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Saloanes/Details/5
        public async Task<IActionResult> salonul_meu()
        {
            var salon = await _context.Saloane.Where(x => x.Firma.Webuser.UserName == User.Identity.Name).FirstOrDefaultAsync();

            var salonVm = new saloaneViewModel { };

            salonVm.Salon = salon;
            var servicii = new List<Servicii>();
            servicii.Add(new Servicii { Denumire = "Tuns barbat", Pret = 25 });
            servicii.Add(new Servicii { Denumire = "Tuns femei", Pret = 50 });
            salonVm.Servicii = servicii;


            return View(salonVm);
        }

        // GET: Saloanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Saloanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cod_salon,Nume,Telefon_salon,Telefon_sms,Website,Facebook,Judet,Adresa,Descriere,Cod_firma")] Saloane saloane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saloane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saloane);
        }

        // GET: Saloanes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saloane = await _context.Saloane.FindAsync(id);
            if (saloane == null)
            {
                return NotFound();
            }
            return View(saloane);
        }

        // POST: Saloanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cod_salon,Nume,Telefon_salon,Telefon_sms,Website,Facebook,Judet,Adresa,Descriere,Cod_firma")] Saloane saloane)
        {
            if (id != saloane.Cod_salon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saloane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaloaneExists(saloane.Cod_salon))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(salonul_meu));
            }
            return View(saloane);
        }

        // GET: Saloanes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saloane = await _context.Saloane
                .FirstOrDefaultAsync(m => m.Cod_salon == id);
            if (saloane == null)
            {
                return NotFound();
            }

            return View(saloane);
        }

        // POST: Saloanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saloane = await _context.Saloane.FindAsync(id);
            _context.Saloane.Remove(saloane);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaloaneExists(int id)
        {
            return _context.Saloane.Any(e => e.Cod_salon == id);
        }
    }
}
