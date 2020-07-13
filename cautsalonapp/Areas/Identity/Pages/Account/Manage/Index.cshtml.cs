using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using cautsalonapp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace cautsalonapp.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _ctx;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _ctx = ctx;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Telefon")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Nume")]
            public string Nume { get; set; }
            
            [Display(Name = "Prenume")]
            public string Prenume { get; set; }
            
            [Display(Name = "Sex")]
            public int Sex { get; set; }
            
            [Display(Name = "Telefon")]
            public string Telefon { get; set; }
            
            [Display(Name = "Judet")]
            public string Judet { get; set; }
            
            [Display(Name = "Adresa")]
            public string Adresa { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            var client = await (from c in _ctx.Clienti
                         where c.Webuser.Id == user.Id
                         select c).FirstOrDefaultAsync();

            Username = userName;

           
            if (client == null) { 
            Input = new InputModel
            {                
                Adresa =  "",
                Judet = "",
                Nume =  "" ,
                Prenume = "" ,
                Sex = 1,
                Telefon = "" 
            };
            } else
            {
                Input = new InputModel
                {
                    Adresa = client.Adresa,
                    Judet = client.Judet,
                    Nume = client.Nume,
                    Prenume = client.Prenume,
                    Sex = client.Sex,
                    Telefon = client.Telefon
                };
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
