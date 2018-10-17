using System.Runtime.Serialization;

namespace ClassroomManagementApi.Models
{
    [DataContract]
    public class Software
    {
        [DataMember]
        public int IdOprogramowanie { get; set; }
        [DataMember]
        public string Nazwa { get; set; }
    }
}
