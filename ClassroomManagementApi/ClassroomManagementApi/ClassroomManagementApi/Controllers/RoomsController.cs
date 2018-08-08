using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class RoomsController : ControllerBase
    {
        private readonly ClassroomManagementRepository _provider;
        
        public RoomsController()
        {
            //TODO: change the conenctionString to appsettings.json
            //string connectionString = "Data Source=sql-ag1-listen.pjwstk.edu.pl;Initial Catalog=dziekanat_hash;Integrated Security=True";
            //_provider = new ClassroomManagementRepository(connectionString);
            _provider = new ClassroomManagementRepository();
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
        //TODO: DELETE, not needed unless requirements change
        [HttpPost("buildings")]
        public IActionResult AddBuilding([FromBody] Building b)
        {
            _provider.AddBuilding(b);
            return CreatedAtRoute("GetBuilding", new { id = b.IdBudynek }, b);
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
        [HttpGet("classrooms", Name = "GetClassrooms")]
        public ActionResult<List<Classroom>> GetClassrooms()
        {
            return _provider.GetClassrooms().ToList();
        }
        //CHECKED
        [HttpGet("classrooms/filter/{idBudynek}/{idFunkcjaSali}")]
        public ActionResult<List<Classroom>> FilterClassrooms(int idBudynek, int idFunkcjaSali)
        {
            return _provider.FilterClassrooms( idBudynek, idFunkcjaSali).ToList();
        }
        //CHECKED
        [HttpPost("classrooms")]
        public IActionResult AddClassroom([FromBody] Classroom c)
        {
            _provider.AddClassroom(c);

            return CreatedAtRoute("GetClassroom", new { id = c.IdSala }, c);
        }
        //TODO: resolve URL clash: GetClassrooms, GetClassroom - querySTring
        //CHECKED
        [HttpGet("classrooms/{id}", Name = "GetClassroom")]
        public ActionResult<Classroom> GetClassroom(int id)
        {
            Classroom s = _provider.GetClassroom(id);
            if (s == null)
                return NotFound();
            return s;
        }
        //CHECKED
        [HttpGet("educationalClassrooms")]
        public ActionResult<List<EducationalClassroom>> GetEducationalClassrooms()
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