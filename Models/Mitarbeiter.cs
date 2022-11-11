using System.ComponentModel.DataAnnotations;

namespace SkiService.Models
{
    public class Mitarbeiter
    {
        [Key]
        public int MitarbeiterID { get; set; }
        public string? MitarbeiterName { get; set; }
        public string? MitarbeiterApiKey { get; set; }
    }
}
