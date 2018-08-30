using System.Runtime.Serialization;

namespace ClassroomManagementApi.Models
{
    [DataContract]
    public class ClassroomStructure
    {
        [DataMember]
        public int IdRozkladSali { get; set; }
        [DataMember(Name ="Rozklad sali")]
        public string NazwaRozkladuSali { get; set; }
    }
}
