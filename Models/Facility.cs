using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SkiService.Models
{
    public class Facility
    {
        [Key]   
        public int FacilityID { get; set; }

        public string? FacilityName { get; set; }
        public List<Client> client { get; set; } = new List<Client>();

    }
}
