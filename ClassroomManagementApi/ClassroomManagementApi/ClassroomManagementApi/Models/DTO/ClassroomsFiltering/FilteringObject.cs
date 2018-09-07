
namespace ClassroomManagementApi.Models.Filtering
{
    public class FilteringObject
    {
        public string BuildingA { get; set; } // explanation why it is a string, not bool - > I didn't want to have buildings hardcoded in the
                                              // database, this way it makes it more versatile and better adjustable to changes
        public string BuildingB { get; set; }
        public string BuildingC { get; set; }
        public bool TV { get; set; }
        public bool Projector { get; set; }
        public bool AccessForTheDisabled { get; set; }
        //public string ClassroomFunction { get; set; }
        // false means return (false and true air conditioning)
        // that's because we won't be interested in finding rooms without air conditioning
        // we don't take into account a case that they'd like to see rooms just without air-conditioning.
        public bool AirConditioning { get; set; }
        public bool OnlyEducationalClassrooms { get; set; }
        public int SizeMin { get; set; }
        public int SizeMax { get; set; }
        public int PlacesMin { get; set; }
        public int PlacesMax { get; set; }
    }
}
