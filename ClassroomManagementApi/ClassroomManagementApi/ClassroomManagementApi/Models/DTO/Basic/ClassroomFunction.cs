using System.Runtime.Serialization;

namespace ClassroomManagementApi.Models
{
    // a POCO class. Doesn't have to have the same name as the name of an entity being mapped
    // the most important is the name of fields we extract. It has to be the same. It ignores the case of letters.
    [DataContract]
    public class ClassroomFunction
    {
        [DataMember(Name = "IdFunkcjaSali")]
        public int IdFunkcja_sali { get; set; }
        [DataMember(Name = "Funkcja sali")]
        public string Funkcja_sali { get; set; }
        [DataMember(Name ="Opis funkcji")]
        public string Opis_funkcji { get; set; }
        [DataMember]
        public string FunkcjaSaliAng { get; set; }
    }
}
