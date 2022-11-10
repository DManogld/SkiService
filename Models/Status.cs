using System.ComponentModel.DataAnnotations;

namespace SkiService.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string? StatusName { get; set; }
        public List<Client> client { get; set; } = new List<Client>();
    }
}
