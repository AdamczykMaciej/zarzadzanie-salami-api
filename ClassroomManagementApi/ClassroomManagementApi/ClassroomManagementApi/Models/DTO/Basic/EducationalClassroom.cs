using System.Runtime.Serialization;

namespace ClassroomManagementApi.Models
{
    [DataContract] // for JSON formatting
    public class EducationalClassroom : Classroom
    {
        [DataMember(Name = "Liczba gniazd sieciowych")]
        public int Liczba_gniazd_sieciowych { get; set; }
        [DataMember]
        public bool TV { get; set; }
        [DataMember]
        public bool Projektor { get; set; }
        [DataMember(Name = "Liczba miejsc dydaktycznych")]
        public int Liczba_miejsc_dydaktycznych { get; set; }
    }
}
