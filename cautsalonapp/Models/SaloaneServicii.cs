using cautsalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cautsalonapp.Models
{
    public class SaloaneServicii
    {        
        public int Id { get; set; }
        public Saloane Salon { get; set; }
        public Servicii Serviciu { get; set; }
    }
}
