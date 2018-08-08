using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Models
{
    public class EducationalClassroom
    {
        // TODO: Delete one of versions eventually
        // VERSION(EducationalClassroom): Simple Version
        //public int IdSala { get; set; }
        //public int Liczba_gniazd_sieciowych { get; set; }
        //public bool TV { get; set; }
        //public bool Projektor { get; set; }
        //public int Liczba_miejsc_dydaktycznych { get; set; }

        // VERSION(EducationalClassroom): Complex Version
        public int IdSala { get; set; }
        public string Nazwa_sali { get; set; }
        public int Liczba_miejsc { get; set; }
        public double Pow_m2 { get; set; }
        public string Uwagi { get; set; }
        public int IdBudynek { get; set; }
        public bool Istnieje { get; set; }
        public int IdFunkcja_sali { get; set; }
        public string Poziom { get; set; }
        public bool Dostep_dla_niepelnosprawnych { get; set; }
        public string Uzytkownik { get; set; }
        public int Kolejnosc { get; set; }
        public int IdRozkladSali { get; set; }
        public int LiczbaKomputerow { get; set; }
        public int IdKomputer { get; set; }
        public bool Klimatyzacja { get; set; }
        public int Liczba_gniazd_sieciowych { get; set; }
        public bool TV { get; set; }
        public bool Projektor { get; set; }
        public int Liczba_miejsc_dydaktycznych { get; set; }
    }
}
