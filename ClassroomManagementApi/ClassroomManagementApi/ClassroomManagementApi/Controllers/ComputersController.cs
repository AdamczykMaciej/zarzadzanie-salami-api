﻿using System.Collections.Generic;
using System.Linq;
using ClassroomManagement.Models;
using ClassroomManagementApi.Models;
using ClassroomManagementApi.Models.DAL;
using ClassroomManagementApi.Models.DTO.Basic;
using ClassroomManagementApi.Models.DTO.ComputerDetails;
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
        [HttpGet("computers/{id}")]
        public IActionResult GetComputer(int id)
        {
            Computer result = _provider.GetComputer(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
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

        [HttpGet("computerDetails/{id}")]
        public IActionResult GetComputerDetails(int id)
        {
            ComputerDetails result = _provider.GetComputerDetails(id);
            if (result == null)
                return NotFound("Not found. There isn't any record with such an id: " + id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Ok(json);
        }
    }
}