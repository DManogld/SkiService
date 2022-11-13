using SkiService.RegistrationDTO;
using System.ComponentModel.DataAnnotations;

namespace SkiService.DTO
{
    public class PriotityDTO
    {
        /// <summary>
        /// DTO Class für Priority
        /// </summary>
        [Key]
        public int PriorityID { get; set; }
        public string? PriorityName { get; set; }
        public List<ClientDTO> client { get; set; } = new List<ClientDTO>();
    }
}
