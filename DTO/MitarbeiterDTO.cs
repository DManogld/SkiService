using SkiService.RegistrationDTO;

namespace SkiService.DTO
{
    public class MitarbeiterDTO
    {
        /// <summary>
        /// DTO CLass für Mitarbeiter
        /// </summary>
        public int MitarbeiterID { get; set; }
        public string? MitarbeiterName { get; set; }
        public string? MitarbeiterApiKey { get; set; }
    }
}
