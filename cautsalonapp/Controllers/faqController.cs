using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace cautsalonapp.Controllers
{
    public class faqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}