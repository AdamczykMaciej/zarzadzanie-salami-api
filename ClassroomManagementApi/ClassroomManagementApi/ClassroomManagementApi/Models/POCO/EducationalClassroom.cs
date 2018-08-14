namespace ClassroomManagementApi.Models
{
    public class EducationalClassroom : Classroom
    {
        public int Liczba_gniazd_sieciowych { get; set; }
        public bool TV { get; set; }
        public bool Projektor { get; set; }
        public int Liczba_miejsc_dydaktycznych { get; set; }
    }
}
