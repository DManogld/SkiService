using SkiService.RegistrationDTO;
using System.ComponentModel.DataAnnotations;

namespace SkiService.DTO
{
    public class PriotityDTO
    {
        [Key]
        public int PriorityID { get; set; }
        public string? PriorityName { get; set; }
        public List<ClientDTO> client { get; set; } = new List<ClientDTO>();
    }
}
