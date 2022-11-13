using System.ComponentModel.DataAnnotations;

namespace SkiService.Models
{
    /// <summary>
    /// Mitarbeiter Klasse für Datenbankkreation/Datenbankverbindung
    /// </summary>
    public class Mitarbeiter
    {
        [Key]
        public int MitarbeiterID { get; set; }
        public string? MitarbeiterName { get; set; }
        public string? MitarbeiterApiKey { get; set; }
    }
}
