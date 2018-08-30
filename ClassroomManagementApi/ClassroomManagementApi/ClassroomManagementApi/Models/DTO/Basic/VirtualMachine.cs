using System.Runtime.Serialization;

namespace ClassroomManagementApi.Models
{
    [DataContract]
    public class VirtualMachine
    {
        [DataMember]
        public int IdMaszynaWirtualna { get; set; }
        [DataMember]
        public string Nazwa { get; set; }
    }
}
