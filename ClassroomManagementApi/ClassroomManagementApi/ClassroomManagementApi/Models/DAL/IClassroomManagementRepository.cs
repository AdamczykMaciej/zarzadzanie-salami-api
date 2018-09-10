using ClassroomManagementApi.Models.Filtering;
using ClassroomManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomManagementApi.Models.DTO.Basic;


namespace ClassroomManagementApi.Models.DAL
{
    public interface IClassroomManagementRepository
    {
        //TODO: Remove unnecessary methods
        Task<IEnumerable<Building>> GetBuildings();
        Building GetBuilding(int id);
        IEnumerable<ClassroomFunction> GetClassroomFunctions();
        ClassroomFunction GetClassroomFunction(int id);
        IEnumerable<Campus> GetCampus();
        Campus GetCampus(int id);
        IEnumerable<VirtualMachine> GetVirtualMachines();
        VirtualMachine GetVirtualMachine(int id);
        IEnumerable<Monitor> GetMonitors();
        Monitor GetMonitor(int id);
        IEnumerable<Software> GetSoftware();
        Software GetSoftware(int id);
        IEnumerable<ComputerSoftware> GetComputerSoftware();
        IEnumerable<ComputerSoftware> GetSoftwareForComputer(int id);
        IEnumerable<ComputerSoftware> GetComputersForSoftware(int id);
        IEnumerable<Computer> GetComputers();
        Computer GetComputer(int id);
        void AddComputer(ComputerDetails c);
        void EditComputer(ComputerDetails c);
        IEnumerable<ClassroomStructure> GetClassroomStructures();
        ClassroomStructure GetClassroomStructure(int id);
        IEnumerable<Classroom> GetClassrooms();
        IEnumerable<Classroom> FilterClassrooms(FilteringObject f);
        Classroom GetClassroom(int id);
        void AddClassroom(EducationalClassroom s);
        IEnumerable<EducationalClassroom> GetEducationalClassrooms();
        EducationalClassroom GetEducationalClassroom(int id);
        IEnumerable<VirtualMachineComputer> GetVirtualMachineComputers();
        ComputerDetails GetComputerDetails(int id);
        IEnumerable<Floor> GetFloors();
    }
}
