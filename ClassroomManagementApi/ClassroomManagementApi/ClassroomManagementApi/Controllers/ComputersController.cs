using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomManagement.Models;
using DapperExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZarzadzanieSalamiApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly ClassroomManagementRepository _provider;

        public ComputersController()
        {
            _provider = new ClassroomManagementRepository();
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