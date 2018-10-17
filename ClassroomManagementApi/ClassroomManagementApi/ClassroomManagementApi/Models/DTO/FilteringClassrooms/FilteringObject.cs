
using System.Collections.Generic;

namespace ClassroomManagementApi.Models.Filtering
{
    public class FilteringObject
    {
        public string[] ClassroomFunctions { get; set; }
        public string[] Buildings { get; set; }
        public bool TV { get; set; }
        public bool Projector { get; set; }
        public bool AccessForTheDisabled { get; set; }
        // false AirConditioning means return false and true air conditioning
        // that's because we won't be interested in finding rooms without air conditioning
        // we don't take into account a case that they'd like to see rooms just without air-conditioning.
        public bool AirConditioning { get; set; }
        public bool OnlyEducationalClassrooms { get; set; }
        public int SizeMin { get; set; } = 0;
        public int SizeMax { get; set; } = 0;
        public int PlacesMin { get; set; } = 0;
        public int PlacesMax { get; set; } = 0;
        public string SearchCategory { get; set; } = "";
        public string Search { get; set; } = "";
    }
}
