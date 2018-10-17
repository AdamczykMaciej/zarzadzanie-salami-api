using System.Runtime.Serialization;

namespace ClassroomManagementApi.Models
{
    [DataContract]
    public class Monitor
    {
        [DataMember]
        public int IdMonitor { get; set; }
        [DataMember(Name ="Rozmiar monitora")]
        public int RozmiarMonitora { get; set; }
    }
}
