using System.Collections.Generic;
using System.Linq;
using ClassroomManagement.Models;
using ClassroomManagementApi.Models.DAL;
using ClassroomManagementApi.Models.Filtering;
using ClassroomManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;

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
        public ActionResult GetBuildings()
        {
            List<Building> result = _provider.GetBuildings().ToList();
            if (result == null)
                return NotFound("No records here");
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("buildings/{id}", Name ="GetBuilding")]
        public IActionResult GetBuilding(int id)
        {
            Building result = _provider.GetBuilding(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("classroomFunctions")]
        public IActionResult GeClassroomFunctions()
        {
            List<ClassroomFunction> result = _provider.GetClassroomFunctions().ToList();
            if (result == null)
                return NotFound("No records here");
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("classroomFunctions/{id}")]
        public IActionResult GetClassroomFunction(int id)
        {
            ClassroomFunction result = _provider.GetClassroomFunction(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("campus")]
        public IActionResult GetCampus()
        {
            List<Campus> result = _provider.GetCampus().ToList();
            if (result == null)
                return NotFound("No records here");
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("campus/{id}")]
        public IActionResult GetCampus(int id)
        {
            Campus result = _provider.GetCampus(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("classroomStructures")]
        public IActionResult GetClassroomStructures()
        {
            List<ClassroomStructure> result = _provider.GetClassroomStructures().ToList();
            if (result == null)
                return NotFound("No records here");
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("classroomStructures/{id}")]
        public IActionResult GetClassroomStructure(int id)
        {
            ClassroomStructure result = _provider.GetClassroomStructure(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("classrooms", Name = "GetClassrooms")]
        public IActionResult GetClassrooms([FromQuery] FilteringObject f)
        {
            List<Classroom> result = _provider.FilterClassrooms(f).ToList();
            if (result == null)
                return NotFound("No records here.");
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }

        [HttpGet("classrooms/{id}", Name = "GetClassroom")]
        public IActionResult GetClassroom(int id)
        {
            Classroom result = _provider.GetClassroom(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpPost("classrooms")]
        public IActionResult AddClassroom([FromBody] Classroom c)
        {
            _provider.AddClassroom(c);

            return CreatedAtRoute("GetClassroom", new { id = c.IdSala }, c);
        }
        //CHECKED
        [HttpGet("educationalClassrooms", Name = "GetEducationalClassrooms")]
        public IActionResult GetEducationaClassrooms()
        {
            List<EducationalClassroom> result = _provider.GetEducationalClassrooms().ToList();
            if (result == null)
                return NotFound("No records here");
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
        //CHECKED
        [HttpGet("educationalClassrooms/{id}")]
        public IActionResult GetEducationalClassroom(int id)
        {
            EducationalClassroom result = _provider.GetEducationalClassroom(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
    }
}