using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;


namespace ClassroomManagementApi.Models
{
    [DataContract]
    public class ComputerDetails : Computer
    {
        [DataMember(Name = "Wirtualne maszyny")]
        public IEnumerable<VirtualMachine> VirtualMachines{ get; set; }
        [DataMember(Name = "Oprogramowanie")]
        public IEnumerable<Software> Software { get; set; }
    }
}
