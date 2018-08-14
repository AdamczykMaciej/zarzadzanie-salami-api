namespace ClassroomManagementApi.Models
{
    // a POCO class. Doesn't have to have the same name as the name of an entity being mapped
    // the most important is the name of fields we extract. It has to be the same. It ignores the case of letters.
    public class ClassroomFunction
    {
        public int IdFunkcja_sali { get; set; }
        public string Funkcja_sali { get; set; }
        public string Opis_funkcji { get; set; }
        public string FunkcjaSaliAng { get; set; }
    }
}
