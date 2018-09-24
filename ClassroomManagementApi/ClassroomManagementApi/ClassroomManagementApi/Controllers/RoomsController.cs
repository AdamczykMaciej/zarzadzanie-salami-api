using System.Collections.Generic;
using System.Linq;
using ClassroomManagementApi.Models.DAL;
using ClassroomManagementApi.Models.Filtering;
using ClassroomManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ClassroomManagementApi.Models.DTO.Basic;

namespace ClassroomManagementApi.Controllers
{
    [Route("api")]
    [ApiController] 
    public class RoomsController : ControllerBase
    {
        private readonly IClassroomManagementRepository _provider;

        public RoomsController(IClassroomManagementRepository provider)
        {
            _provider = provider;
        }

        //CHECKED
        [HttpGet("buildings")]
        public async Task<IActionResult> GetBuildings()
        {
            var result = await _provider.GetBuildingsAsync();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("buildings/{id}", Name ="GetBuilding")]
        public async Task<IActionResult> GetBuilding(int id)
        {
            var result = await _provider.GetBuildingAsync(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("classroomFunctions")]
        public async Task<IActionResult> GeClassroomFunctions()
        {
            var result = await _provider.GetClassroomFunctionsAsync();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("classroomFunctions/{id}")]
        public async Task<IActionResult> GetClassroomFunction(int id)
        {
            var result = await _provider.GetClassroomFunctionAsync(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("campus")]
        public async Task<IActionResult> GetCampusAsync()
        {
            var result = await _provider.GetCampusAsync();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("campus/{id}")]
        public async Task<IActionResult> GetCampusAsync(int id)
        {
            var result = await  _provider.GetCampusAsync(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("classroomStructures")]
        public async Task<IActionResult> GetClassroomStructuresAsync()
        {
            var result = await _provider.GetClassroomStructuresAsync();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("classroomStructures/{id}")]
        public async Task<IActionResult> GetClassroomStructureAsync(int id)
        {
            var result = await _provider.GetClassroomStructureAsync(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("classrooms", Name = "GetClassrooms")]
        public async Task<IActionResult> GetClassroomsAsync([FromQuery] FilteringObject f)
        {
            var result = await _provider.FilterClassroomsAsync(f);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        [HttpGet("classrooms/{id}", Name = "GetClassroom")]
        public async Task<IActionResult> GetClassroomAsync(int id)
        {
            var result = await _provider.GetClassroomAsync(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        [HttpPut("classrooms/{idClassroom}")]
        public void AddComputerToClassroom(int idClassroom, [FromBody] int idComputer)
        {
            _provider.AddComputerToClassroom(idClassroom, idComputer);
        }
        //CHECKED
        [HttpPost("classrooms")]
        public IActionResult AddClassroom([FromBody] EducationalClassroom c)
        {
            _provider.AddClassroom(c);

            return CreatedAtRoute("GetClassroom", new { id = c.IdSala }, c);
        }

        [HttpPut("classrooms")]
        public IActionResult EditClassroom([FromBody] EducationalClassroom c)
        {
            _provider.EditClassroom(c);

            return CreatedAtRoute("GetClassroom", new { id = c.IdSala }, c);
        }
        //CHECKED
        [HttpGet("educationalClassrooms", Name = "GetEducationalClassrooms")]
        public async Task<IActionResult> GetEducationaClassroomsAsync()
        {
            var result = await _provider.GetEducationalClassroomsAsync();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("educationalClassrooms/{id}")]
        public async Task<IActionResult> GetEducationalClassroomAsync(int id)
        {
            var result = await _provider.GetEducationalClassroomAsync(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        [HttpGet("floors")]
        public async Task<IActionResult> GetFloorsAsync()
        {
            var result = await _provider.GetFloorsAsync();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

    }
}