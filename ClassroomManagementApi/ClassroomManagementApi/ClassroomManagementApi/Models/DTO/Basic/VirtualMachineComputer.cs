using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ClassroomManagementApi.Models.DTO.Basic
{
    // an associative resource
    [DataContract]
    public class VirtualMachineComputer
    {
        [DataMember]
        public int IdMaszynaWirtualna { get; set; }
        [DataMember]
        public int IdKomputer { get; set; }
    }
}
