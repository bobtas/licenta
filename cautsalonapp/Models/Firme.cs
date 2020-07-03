using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cautsalon.Models
{
    public class Firme
    {
        public int Cod_firma { get; set; }
        public string Denumire { get; set; }
        public string Cui { get; set; }
        public string Registrul_comertului { get; set; }
        public IdentityUser Webuser { get; set; }
    }
}
