using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cautsalon.Models
{
    public class Clienti
    {
        public int Cod_client { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Sex { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Judet { get; set; }
        public string Adresa { get; set; }
        public IdentityUser Webuser { get; set; }

    }
}
