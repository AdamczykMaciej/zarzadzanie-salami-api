
namespace ClassroomManagementApi.Models.Filtering
{
    public class FilteringObject
    {
        public int IdClassroomFunction { get; set; }
        public string BuildingA { get; set; }
        public string BuildingB { get; set; }
        public string BuildingC { get; set; }
        public bool TV { get; set; }
        public bool Projector { get; set; }
        //public string ClassroomFunction { get; set; }
        // false means return (false and true air conditioning)
        // that's because we won't be interested in finding rooms without air conditioning
        // we don't take into account a case that they'd like to see rooms just without air-conditioning.
        public bool AirConditioning { get; set; }
        public bool OnlyEducationalClassrooms { get; set; }
        public int sizeMin { get; set; }
        public int sizeMax { get; set; }
        public int placesMin { get; set; }
        public int placesMax { get; set; }
    }
}
