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
using Microsoft.Extensions.Logging;

namespace cautsalonapp.Areas.Aisalon.Pages.Create
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<IndexModel> _logger;        
        private readonly ApplicationDbContext _ctx;

        
        public IndexModel(
           UserManager<IdentityUser> userManager,
           SignInManager<IdentityUser> signInManager,
           ILogger<IndexModel> logger,
           ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _ctx = ctx;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [StringLength(100, ErrorMessage = "{0} trebuie sa contina minimum {2} si maximum {1} caractere.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Parola")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirma parola")]
            [Compare("Password", ErrorMessage = "Parola si Confirmarea parolei nu corespund.")]
            public string ConfirmPassword { get; set; }


            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [Display(Name = "Denumire firma")]
            public string DenumireFirma { get; set; }
            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [Display(Name = "Cod Unic de Identificare (CUI)")]
            public string Cui { get; set; }
            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [Display(Name = "Registrul Comertului")]
            public string RegistruComert { get; set; }

            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [Display(Name = "Denumire salon")]
            public string NumeSalon { get; set; }
            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [Display(Name = "Telefon salon")]
            public string Telefon_salon { get; set; }
            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [Display(Name = "Telefon pentru alerte SMS")]
            public string Telefon_sms { get; set; }
            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [Display(Name = "Website")]
            public string Website { get; set; }
            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [Display(Name = "Facebook")]
            public string Facebook { get; set; }
            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [Display(Name = "Judet")]
            public string Judet { get; set; }
            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [Display(Name = "Oras")]
            public string Oras { get; set; }
            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [Display(Name = "Adresa")]
            public string Adresa { get; set; }
            [Required(ErrorMessage = "Acest camp este obligatoriu.")]
            [Display(Name = "Descrierea salonului")]
            public string Descriere { get; set; }

        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "salonowner");
                    _logger.LogInformation("webuser a fost adaugat cu rol de salonowner");
                    _logger.LogInformation("Webuser a fost creat.");

                    _logger.LogInformation("Se creaza firma");

                    var firma = new Firme
                    {
                        Cui = Input.Cui,
                        Denumire = Input.DenumireFirma,
                        Registrul_comertului = Input.RegistruComert
                    };

                    _logger.LogInformation("Se creaza salonul");
                    var salon = new Saloane
                    {
                        Adresa = Input.Adresa,
                        Firma = firma,
                        Descriere = Input.Descriere,
                        Facebook = Input.Facebook,
                        Judet = Input.Judet,
                        Oras = Input.Oras,
                        Nume = Input.NumeSalon,
                        Telefon_salon = Input.Telefon_salon,
                        Telefon_sms = Input.Telefon_sms,
                        Website = Input.Website
                    };


                    _ctx.Saloane.Add(salon);
                    _ctx.Firme.Add(firma);
                    await _ctx.SaveChangesAsync();

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                   
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
