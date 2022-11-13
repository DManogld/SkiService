using System.ComponentModel.DataAnnotations;

namespace SkiService.Models
{
    /// <summary>
    /// Facility Klasse für Datenbankkreation/Datenbankverbindung
    /// </summary>
    public class Facility
    {
        [Key]
        public int FacilityID { get; set; }
        public string? FacilityName { get; set; }
        public List<Client> client { get; set; } = new List<Client>();
    }
}
