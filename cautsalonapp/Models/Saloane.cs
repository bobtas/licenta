using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cautsalon.Models
{
    public class Saloane
    {
        public int Cod_salon { get; set; }
        public string Nume { get; set; }
        public string Telefon_salon { get; set; }
        public string Telefon_sms { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Judet { get; set; }
        public string Adresa { get; set; }
        public string Descriere { get; set; }
        public int Cod_firma { get; set; }
        public string Oras { get; set; }
        public Firme Firma { get; set; }        
        

    }
}
