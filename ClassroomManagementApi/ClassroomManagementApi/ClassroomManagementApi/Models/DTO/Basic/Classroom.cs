using System.Runtime.Serialization;

namespace ClassroomManagementApi.Models
{   
    [DataContract] // this annotation is just for JSON formatting, we could remove it, but on frontend we want tho have it in a neat format
    public class Classroom
    {
        [DataMember]
        public int IdSala { get; set; }
        [DataMember(Name = "Nazwa sali")]
        public string Nazwa_sali { get; set; }
        [DataMember(Name = "Liczba miejsc")]
        public int Liczba_miejsc { get; set; }
        [DataMember(Name = "Pow m2")]
        public double Pow_m2 { get; set; }
        [DataMember]
        public string Uwagi { get; set; }
        [DataMember]
        public int IdBudynek { get; set; }
        [DataMember(Name = "Nazwa budynku")]
        public string NazwaBudynku { get; set; }
        [DataMember]
        public bool Istnieje { get; set; }
        [DataMember(Name = "IdFunkcjaSali")]
        public int IdFunkcja_sali { get; set; }
        [DataMember(Name = "Funkcja sali")]
        public string Funkcja_sali { get; set; }
        [DataMember]
        public string Poziom { get; set; }
        [DataMember(Name = "Dostęp dla niepełnosprawnych")]
        public bool Dostep_dla_niepelnosprawnych { get; set; }
        [DataMember]
        public string Uzytkownik { get; set; }
        [DataMember]
        public int Kolejnosc { get; set; }
        [DataMember]
        public int IdRozkladSali { get; set; }
        [DataMember(Name = "Rozkład sali")]
        public string NazwaRozkladuSali { get; set; }
        [DataMember(Name = "Liczba komputerów")]
        public int LiczbaKomputerow { get; set; }
        // IdKomputer can be null
        [DataMember]
        public int? IdKomputer { get; set; }
        [DataMember]
        public bool Klimatyzacja { get; set; }
        [DataMember(Name = "Czy dydaktyczna?")]
        public bool CzyDydaktyczna { get; set; }
    }
}
