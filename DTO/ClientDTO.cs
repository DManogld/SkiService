using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SkiService.RegistrationDTO
{
    /// <summary>
    /// DTO Class für Client
    /// </summary>
    public class ClientDTO
    {
        [Key]
        public int ClientID { get; set; }     
        public string? Name { get; set; }
        public string? EMail { get; set; }
        public string? Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PickupDate { get; set; }
        public string? FacilityName { get; set; }
        public string? PriorityName { get; set; }
        public string? StatusName { get; set; }
        public string? Kommentar { get; set; }
    }
}
