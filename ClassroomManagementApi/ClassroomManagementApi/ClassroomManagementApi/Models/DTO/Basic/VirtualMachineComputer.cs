using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomManagementApi.Models.DTO.Basic
{
    // an associative resource
    public class VirtualMachineComputer
    {
        public int IdMaszynaWirtualna { get; set; }
        public int IdKomputer { get; set; }
    }
}
