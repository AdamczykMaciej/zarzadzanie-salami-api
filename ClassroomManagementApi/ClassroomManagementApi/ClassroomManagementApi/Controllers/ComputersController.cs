using System.Collections.Generic;
using System.Linq;
using ClassroomManagement.Models;
using ClassroomManagementApi.Models;
using ClassroomManagementApi.Models.DAL;
using ClassroomManagementApi.Models.DTO.Basic;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomManagementApi.Controllers
{
    // TODO: After holidays - Add missing methods and add DTO model for MaszynaWirtualnaKomputer + insert some dummy data, and procedure for classroomDetails
    [Route("api")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly IClassroomManagementRepository _provider;

        public ComputersController(IClassroomManagementRepository provider)
        {
            _provider = provider;
        }

        //CHECKED
        [HttpGet("computers")]
        public ActionResult<List<Computer>> GetComputers()
        {
            return _provider.GetComputers().ToList();
        }
        //CHECKED
        [HttpGet("computers/{id}")]
        public ActionResult<Computer> GetComputer(int id)
        {
            Computer c = _provider.GetComputer(id);
            if (c == null)
                return NotFound();
            return c;
        }

        //CHECKED
        [HttpGet("virtualMachines")]
        public ActionResult<List<VirtualMachine>> GetVirtualMachines()
        {
            return _provider.GetVirtualMachines().ToList();
        }
        //TODO: CHECK
        [HttpGet("computers")]
        public ActionResult<List<VirtualMachineComputer>> GetVirtualMachineComputers()
        {
            return _provider.GetVirtualMachineComputers().ToList();
        }
        //CHECKED
        [HttpGet("monitors")]
        public ActionResult<List<Monitor>> GetMonitors()
        {
            return _provider.GetMonitors().ToList();
        }
        //CHECKED
        [HttpGet("software")]
        public ActionResult<List<Software>> GetSoftware()
        {
            return _provider.GetSoftware().ToList();
        }

        [HttpGet("software/{id}")]
        public ActionResult<Software> GetSoftware(int id)
        {
            Software s = _provider.GetSoftware(id);
            if (s == null)
                return NotFound();
            return s;
        }
        //CHECKED
        [HttpGet("computerSoftware")]
        public ActionResult<List<ComputerSoftware>> GetComputerSoftware()
        {
            return _provider.GetComputerSoftware().ToList();
        }
    }
}