using System.Collections.Generic;
using System.Linq;
using ClassroomManagementApi.Models;
using ClassroomManagementApi.Models.DAL;
using ClassroomManagementApi.Models.DTO.Basic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClassroomManagementApi.Controllers
{
    // TODO: After holidays - Add missing methods + insert some dummy data, and procedure for classroomDetails
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
        public IActionResult GetComputers()
        {
           List<Computer> result = _provider.GetComputers().ToList();
            if (result == null)
                return NotFound("No records found");
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("computers/{id}", Name = "GetComputer")]
        public IActionResult GetComputer(int id)
        {
            Computer result = _provider.GetComputerDetails(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        [HttpPost("computers")]
        public IActionResult AddComputer([System.Web.Http.FromUri] int? idSala, [FromBody] ComputerDetails c)
        {
            _provider.AddComputer(c, idSala);

            return CreatedAtRoute("GetComputer", new { id = c.IdKomputer }, c);
        }

        [HttpPut("computers")]
        public IActionResult EditComputer([FromBody] ComputerDetails c)
        {
            _provider.EditComputer(c);

            return CreatedAtRoute("GetComputer", new { id = c.IdKomputer }, c);
        }

        //CHECKED
        [HttpGet("virtualMachines")]
        public IActionResult GetVirtualMachines()
        {
            List<VirtualMachine> result = _provider.GetVirtualMachines().ToList();
            if (result == null)
                return NotFound("No records found");
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        [HttpGet("virtualMachines/{id}")]
        public IActionResult GetVirtualMachine(int id)
        {
           VirtualMachine result = _provider.GetVirtualMachine(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        //TODO: CHECK
        [HttpGet("virtualMachineComputers")]
        public IActionResult GetVirtualMachineComputers()
        {
            List<VirtualMachineComputer> result = _provider.GetVirtualMachineComputers().ToList();
            if (result == null)
                return NotFound("No records found");
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("monitors")]
        public IActionResult GetMonitors()
        {
            List<Monitor> result = _provider.GetMonitors().ToList();
            if (result == null)
                return NotFound("No records found");
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        [HttpGet("monitors/{id}")]
        public IActionResult GetMonitor(int id)
        {
            Monitor result = _provider.GetMonitor(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
    
        //CHECKED
        [HttpGet("software")]
        public IActionResult GetSoftware()
        {
            List<Software> result = _provider.GetSoftware().ToList();
            if (result == null)
                return NotFound("No records found");
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        [HttpGet("software/{id}")]
        public IActionResult GetSoftware(int id)
        {
            Software result = _provider.GetSoftware(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("computerSoftware")]
        public IActionResult GetComputerSoftware()
        {
            List<ComputerSoftware> result = _provider.GetComputerSoftware().ToList();
            if (result == null)
                return NotFound("No records found");
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
    }
}