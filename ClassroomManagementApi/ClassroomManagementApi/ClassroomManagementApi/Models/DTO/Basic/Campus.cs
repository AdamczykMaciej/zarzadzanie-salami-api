using System.Runtime.Serialization;

namespace ClassroomManagementApi.Models
{
    [DataContract]
    public class Campus
    {
        [DataMember]
        public int IdKampus { get; set; }
        [DataMember(Name = "Nazwa kampusu")]
        public string Nazwa_kampusu { get; set; }
        [DataMember]
        public string Opis { get; set; }
    }
}
