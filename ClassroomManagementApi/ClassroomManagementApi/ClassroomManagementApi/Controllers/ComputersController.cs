using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetComputersAsync()
        {
            var result = await _provider.GetComputersAsync();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("computers/{id}", Name = "GetComputer")]
        public async Task<IActionResult> GetComputerAsync(int id)
        {
            var result = await _provider.GetComputerDetailsAsync(id);
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
        public async Task<IActionResult> GetVirtualMachinesAsync()
        {
            var result = await _provider.GetVirtualMachinesAsync();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        [HttpGet("virtualMachines/{id}")]
        public async Task<IActionResult> GetVirtualMachineAsync(int id)
        {
           var result = await _provider.GetVirtualMachineAsync(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        //TODO: CHECK
        [HttpGet("virtualMachineComputers")]
        public async Task<IActionResult> GetVirtualMachineComputersAsync()
        {
            var result = await _provider.GetVirtualMachineComputersAsync();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("monitors")]
        public async Task<IActionResult> GetMonitorsAsync()
        {
            var result = await _provider.GetMonitorsAsync();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        [HttpGet("monitors/{id}")]
        public async Task<IActionResult> GetMonitorAsync(int id)
        {
           var result = await _provider.GetMonitorAsync(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
    
        //CHECKED
        [HttpGet("software")]
        public async Task<IActionResult> GetSoftwareAsync()
        {
            var result = await _provider.GetSoftwareAsync();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        [HttpGet("software/{id}")]
        public async Task<IActionResult> GetSoftwareAsync(int id)
        {
            var result = await _provider.GetSoftwareAsync(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("computerSoftware")]
        public async Task<IActionResult> GetComputerSoftwareAsync()
        {
            var result = await _provider.GetComputerSoftwareAsync();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
    }
}