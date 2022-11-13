namespace SkiService.Models
{
    /// <summary>
    /// Client Klasse für Datenbankkreation/Datenbankverbindung
    /// </summary>
    public class Client
    {
        public int ClientID { get; set; }

        public string? Name { get; set; }

        public string? EMail { get; set; }

        public string? Phone { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime PickupDate { get; set; }

        public string Kommentar { get; set; } 

        public int? StatusID { get; set; }
        public Status? Status { get; set; }

        public int PriorityID { get; set; }
        public Priority? Priority { get; set; }

        public int FacilityID { get; set; }
        public Facility? Facility { get; set; }

    }
}
