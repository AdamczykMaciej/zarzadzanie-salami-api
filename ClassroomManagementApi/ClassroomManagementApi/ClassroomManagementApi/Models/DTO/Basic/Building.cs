using System.Runtime.Serialization;

namespace ClassroomManagementApi.Models
{
    [DataContract]
    public class Building
    {
        [DataMember]
        public int IdBudynek { get; set; }
        [DataMember]
        public string Nazwa { get; set; }
        [DataMember]
        public int IdMiasto { get; set; }
        [DataMember(Name = "Adres budynku")]
        public string Adres_budynku { get; set; }
        [DataMember]
        public string Opis { get; set; }
        [DataMember]
        public bool Istnieje { get; set; }
        [DataMember]
        public int IdKampus { get; set; }
    }
}
