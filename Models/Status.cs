using System.ComponentModel.DataAnnotations;

namespace SkiService.Models
{
    /// <summary>
    /// Status Klasse für Datenbankkreation/Datenbankverbindung
    /// </summary>
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string? StatusName { get; set; }
        public List<Client> client { get; set; } = new List<Client>();
    }
}
