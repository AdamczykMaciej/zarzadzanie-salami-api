namespace ClassroomManagementApi.Models
{
    public class Building
    {
        public int IdBudynek { get; set; }
        public string Nazwa { get; set; }
        public int IdMiasto { get; set; }
        public string Adres_budynku { get; set; }
        public string Opis { get; set; }
        public bool Istnieje { get; set; }
        public int IdKampus { get; set; }
    }
}
