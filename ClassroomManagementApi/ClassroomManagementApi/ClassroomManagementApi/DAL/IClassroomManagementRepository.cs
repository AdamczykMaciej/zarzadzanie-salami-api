using ClassroomManagementApi.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomManagementApi.Models.DTO.Basic;

namespace ClassroomManagementApi.Models.DAL
{
    public interface IClassroomManagementRepository
    {
        //TODO: Remove unnecessary methods
        Task<IEnumerable<Building>> GetBuildingsAsync();
        Task<Building> GetBuildingAsync(int id);
        Task<IEnumerable<ClassroomFunction>> GetClassroomFunctionsAsync();
        Task<ClassroomFunction> GetClassroomFunctionAsync(int id);
        Task<IEnumerable<Campus>> GetCampusAsync();
        Task<Campus> GetCampusAsync(int id);
        Task<IEnumerable<VirtualMachine>> GetVirtualMachinesAsync();
        Task<VirtualMachine> GetVirtualMachineAsync(int id);
        Task<IEnumerable<Monitor>> GetMonitorsAsync();
        Task<Monitor> GetMonitorAsync(int id);
        Task<IEnumerable<Software>> GetSoftwareAsync();
        Task<Software> GetSoftwareAsync(int id);
        Task<IEnumerable<ComputerSoftware>> GetComputerSoftwareAsync();
        Task<IEnumerable<Computer>> GetComputersAsync();
        Task<Computer> GetComputerAsync(int id);
        void AddComputer(ComputerDetails c);
        void EditComputer(ComputerDetails c);
        Task<IEnumerable<ClassroomStructure>> GetClassroomStructuresAsync();
        Task<ClassroomStructure> GetClassroomStructureAsync(int id);
        Task<IEnumerable<Classroom>> GetClassroomsAsync();
        Task<IEnumerable<Classroom>> FilterClassroomsAsync(FilteringObject f);
        Task<Classroom> GetClassroomAsync(int id);
        void AddClassroom(EducationalClassroom c);
        void EditClassroom(EducationalClassroom c);
        Task<IEnumerable<EducationalClassroom>> GetEducationalClassroomsAsync();
        Task<EducationalClassroom> GetEducationalClassroomAsync(int id);
        Task<IEnumerable<VirtualMachineComputer>> GetVirtualMachineComputersAsync();
        Task<ComputerDetails> GetComputerDetailsAsync(int id);
        Task<IEnumerable<Floor>> GetFloorsAsync();
        void AddComputerToClassroom(int idClassroom, int idComputer);
    }
}
