using Microsoft.EntityFrameworkCore;
using SkiService.DTO;
using SkiService.Models;
using SkiService.RegistrationDTO;

namespace SkiService.Services
{
    /// <summary>
    /// Mitarbeiter Service für abrufen von Registrationen nach Mitarbeiter
    /// </summary>
    public class MitarbeiterService : IMitarbeiterDbService
    {
        private readonly RegistrationContext _dbcontext;
        public List<Mitarbeiter> mitarbeiters;

        /// <summary>
        /// Konstruktor für instanziierung von DB verbindung
        /// </summary>
        /// <param name="dbcontext"></param>
        public MitarbeiterService(RegistrationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        /// <summary>
        ///GetAll Methode welche alle Mitarbeiter zurückgibt
        /// </summary>
        /// <returns>Mitarbeiter</returns>
        public List<Mitarbeiter> GetAll()
        {
           mitarbeiters = _dbcontext.Mitarbeiters.ToList();
            return mitarbeiters;
        }
    }
}
