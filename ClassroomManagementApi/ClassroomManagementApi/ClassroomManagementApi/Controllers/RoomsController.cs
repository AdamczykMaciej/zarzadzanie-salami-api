using System.Collections.Generic;
using System.Linq;
using ClassroomManagement.Models;
using ClassroomManagementApi.Models.DAL;
using ClassroomManagementApi.Models.Filtering;
using ClassroomManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public ActionResult<List<Building>> GetBuildings()
        {
            return _provider.GetBuildings().ToList();
        }
        //CHECKED
        [HttpGet("buildings/{id}", Name ="GetBuilding")]
        public ActionResult<Building> GetBuilding(int id)
        {
            Building b = _provider.GetBuilding(id);
            if (b == null)
                return NotFound();
            return b;
        }
        //CHECKED
        [HttpGet("classroomFunctions")]
        public ActionResult<List<ClassroomFunction>> GeClassroomFunctions()
        {
            return _provider.GetClassroomFunctions().ToList();
        }
        //CHECKED
        [HttpGet("classroomFunctions/{id}")]
        public ActionResult<ClassroomFunction> GetClassroomFunction(int id)
        {
            ClassroomFunction fs = _provider.GetClassroomFunction(id);
            if (fs == null)
                return NotFound();
            return fs;
        }
        //CHECKED
        [HttpGet("campus")]
        public ActionResult<List<Campus>> GetCampus()
        {
            return _provider.GetCampus().ToList();
        }
        //CHECKED
        [HttpGet("campus/{id}")]
        public ActionResult<Campus> GetCampus(int id)
        {
            Campus k = _provider.GetCampus(id);
            // to give some information to the browser
            if (k == null)
                return NotFound();
            return k;
        }
        //CHECKED
        [HttpGet("classroomStructures")]
        public ActionResult<List<ClassroomStructure>> GetClassroomStructures()
        {
            return _provider.GetClassroomStructures().ToList();
        }
        //CHECKED
        [HttpGet("classroomStructures/{id}")]
        public ActionResult<ClassroomStructure> GetClassroomStructure(int id)
        {
            ClassroomStructure rs = _provider.GetClassroomStructure(id);
            if (rs == null)
                return NotFound();
            return rs;
        }
        //CHECKED
        //TODO: refactor GetClassroom, GetClassrooms, FilterClassrooms into a single classroom
        [HttpGet("classrooms", Name = "GetClassrooms")]
        public ActionResult<List<Classroom>> GetClassrooms([FromQuery] FilteringObject f)
        {
            List<Classroom> result = _provider.FilterClassrooms(f).ToList();
            return result;
        }

        [HttpGet("classrooms/{id}", Name = "GetClassroom")]
        public ActionResult<Classroom> GetClassroom(int id)
        {
                return _provider.GetClassroom(id);
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
        public ActionResult<List<EducationalClassroom>> GetEducationaClassrooms()
        {
            return _provider.GetEducationalClassrooms().ToList();
        }
        //CHECKED
        [HttpGet("educationalClassrooms/{id}")]
        public ActionResult<EducationalClassroom> GetEducationalClassroom(int id)
        {
            EducationalClassroom sd = _provider.GetEducationalClassroom(id);
            if (sd == null)
                return NotFound();
            return sd;
        }
    }
}