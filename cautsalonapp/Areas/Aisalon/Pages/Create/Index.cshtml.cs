using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cautsalonapp.Areas.Aisalon.Pages.Create
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

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
            public int RegistruComert { get; set; }

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
    }
}
