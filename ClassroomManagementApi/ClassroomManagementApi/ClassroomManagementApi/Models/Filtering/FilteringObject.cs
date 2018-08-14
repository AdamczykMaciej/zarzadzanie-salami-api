
namespace ClassroomManagementApi.Models.Filtering
{
    public class FilteringObject
    {
        public int IdClassroomFunction { get; set; }
        public int IdBuildingA { get; set; }
        public int IdBuildingC { get; set; }
        public int IdBuildingG { get; set; }
        public bool TV { get; set; }
        public bool Projector { get; set; }
        //public string ClassroomFunction { get; set; }
        // false means return (false and true air conditioning)
        // that's because we won't be interested in finding rooms without air conditioning
        // we don't take into account a case that they'd like to see rooms just without air-conditioning.
        public bool AirConditioning { get; set; }
        public bool OnlyEducationalClassrooms { get; set; }
    }
}
