using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using cautsalon.Models;
using cautsalonapp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace cautsalonapp.Areas.Cautasalon.Pages.Cauta
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _ctx;


        public IndexModel(
           UserManager<IdentityUser> userManager,
           ILogger<IndexModel> logger,
           ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _logger = logger;
            _ctx = ctx;
        }
        public void OnGet()
        {
        }
       
        public class SaloaneViewModel
        {
            [Display(Name ="Salon")]
            public int SelectedSalonId { get; set; }
            public IEnumerable<SelectListItem> Saloane { get => Saloane; }
            
            public int SelectedServiciuId { get; set; }
            public IEnumerable<SelectListItem> Servicii { get => Servicii; }
        }

        public IEnumerable<SelectListItem> Servicii
        {
            get
            {
                
                return new SelectList(null, "SelectedSalonId", "Text");
            }
        }
        public IEnumerable<SelectListItem> Saloane
        {
            get
            {                
                var saloane = (from s in _ctx.Saloane
                               select s).Select(x =>
                               new SelectListItem
                               {
                                   Value = x.Cod_salon.ToString(),
                                   Text = x.Nume + ", " + x.Adresa
                               }).ToList();
                saloane.Insert(0, new SelectListItem { Value = "", Text = "Selecteaza salon" });

                return new SelectList(saloane, "Value", "Text");
            }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Display(Name = "Alege orasul")]
            public string Oras { get; set; }

            [Display(Name = "Alege salon")]
            public string NumeSalon { get; set; }

            [Display(Name = "Alege serviciu")]
            public string Serviciu { get; set; }

            [Display(Name = "Selecteaza data/ora")]
            [Required(ErrorMessage = "Data este obligatorie")]
            public DateTime Data { get; set; }
            [Display(Name = "Observatii legate de programare")]
            public string Observatii { get; set; }
        }
       
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = Url.Content("~/Cautasalon/Cauta/Success");
            var selectedSalon = int.Parse(Request.Form["saloane"][0]);
            var selectedServiciu = int.Parse(Request.Form["servicii"][0]);
            if (!string.IsNullOrEmpty(selectedSalon.ToString()) && !string.IsNullOrEmpty(selectedServiciu.ToString()) && !string.IsNullOrEmpty(Input.Data.ToString()))
            {
                using (var context = _ctx)
                {
                    var client = await context.Clienti.Where(x => x.Webuser.UserName == User.Identity.Name).FirstOrDefaultAsync();
                    var salon = await context.Saloane.Where(x => x.Cod_salon == selectedSalon).FirstOrDefaultAsync();
                    var serviciu = await context.Servicii.Where(x => x.Cod_serviciu == selectedServiciu).FirstOrDefaultAsync();
                    var programari = new Programari()
                    {
                        Client = client,
                        Data = Input.Data,
                        Observatii = Input.Observatii,
                        Salon = salon,
                        Serviciu = serviciu                        
                    };
                    context.Programari.Add(programari);
                    await context.SaveChangesAsync();
                    
                    
                }
            }

            return LocalRedirect(returnUrl);
        }
    }
}
