using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Models
{
    public class Komputer
    {
        public int IdKomputer { get; set; }
        public int IdMonitor { get; set; }
        public string Procesor { get; set; }
        public string RAM { get; set; }
        public string KartaGraficzna { get; set; }
        public int IdMaszynaWirtualna { get; set; }
    }
}
