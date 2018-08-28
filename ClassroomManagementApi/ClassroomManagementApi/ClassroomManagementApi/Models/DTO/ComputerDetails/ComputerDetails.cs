using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClassroomManagementApi.Models.DTO.ComputerDetails
{
    public class ComputerDetails
    {
        public Computer ComputerInfo { get; set; }
        public IEnumerable<VirtualMachine> WirtualneMaszyny { get; set; }
    }
}
