using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using cautsalonapp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            public DateTime Data { get; set; }
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Cautasalon/Cauta/Success");

            return LocalRedirect(returnUrl);
        }
    }
}
