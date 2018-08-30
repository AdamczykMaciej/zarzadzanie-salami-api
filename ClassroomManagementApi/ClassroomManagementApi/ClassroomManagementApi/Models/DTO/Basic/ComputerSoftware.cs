using System.Runtime.Serialization;

namespace ClassroomManagementApi.Models
{
    [DataContract]
    public class ComputerSoftware
    {
        [DataMember]
        public int IdKomputer{ get; set; }
        [DataMember]
        public int IdOprogramowanie { get; set; }
    }
}
