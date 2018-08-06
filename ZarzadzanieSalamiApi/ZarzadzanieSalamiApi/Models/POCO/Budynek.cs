using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Models
{
    public class Budynek
    {
        public int IdBudynek { get; set; }
        public string Nazwa { get; set; }
        public int IdMiasto { get; set; }
        public string Adres_budynku { get; set; }
        public string Opis { get; set; }
        public bool Istnieje { get; set; }
        public int IdKampus { get; set; }
    }
}
