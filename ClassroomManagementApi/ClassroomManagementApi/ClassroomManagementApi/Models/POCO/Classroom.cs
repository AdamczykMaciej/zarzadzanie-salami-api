namespace ClassroomManagementApi.Models
{
    public class Classroom
    {
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
    }
}
