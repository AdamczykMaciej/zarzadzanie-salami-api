using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Models
{
    // a POCO class. Doesn't have to have the same name as the name of an entity being mapped
    // the most important is the name of fields we extract. It has to be the same. It ignores the case of letters.
    public class FunkcjaSali
    {
        public int IdFunkcja_sali { get; set; }
        public string Funkcja_sali { get; set; }
        public string Opis_funkcji { get; set; }
        public string FunkcjaSaliAng { get; set; }
    }
}
