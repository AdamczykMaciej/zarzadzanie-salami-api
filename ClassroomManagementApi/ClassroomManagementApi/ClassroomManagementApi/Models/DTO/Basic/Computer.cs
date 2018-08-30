using System.Runtime.Serialization;

namespace ClassroomManagementApi.Models
{
    [DataContract]
    public class Computer
    {
        [DataMember]
        public int IdKomputer { get; set; }
        [DataMember]
        public int IdMonitor { get; set; }
        [DataMember(Name = "Rozmiar monitora")]
        public int RozmiarMonitora { get; set; }
        [DataMember]
        public string Procesor { get; set; }
        [DataMember]
        public string RAM { get; set; }
        [DataMember(Name = "Karta graficzna")]
        public string KartaGraficzna { get; set; }
    }
}
