using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace cautsalon.Models
{
    public class Programari
    {
        public int Cod_programare { get; set; }
        public IdentityUser Webuser { get; set; }
        public Clienti Client { get; set; }
        public DateTime Data { get; set; }
        public string Observatii { get; set; }        
        public Servicii Serviciu { get; set; }
        public Saloane Salon { get; set; }
    }
}
