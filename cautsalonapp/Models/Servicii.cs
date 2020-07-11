using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace cautsalon.Models
{
    public class Servicii
    {
        public int Cod_serviciu { get; set; }
        [Display(Name = "Serviciu ales")]
        public string Denumire { get; set; }       
        public double Pret { get; set; }
    }
}
