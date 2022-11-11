using Microsoft.EntityFrameworkCore;
using SkiService.DTO;
using SkiService.Models;
using SkiService.RegistrationDTO;

namespace SkiService.Services
{
    public class MitarbeiterService : IMitarbeiterDbService
    {
        private readonly RegistrationContext _dbcontext;
        public List<Mitarbeiter> mitarbeiters;

        public MitarbeiterService(RegistrationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Mitarbeiter> GetAll()
        {
           mitarbeiters = _dbcontext.Mitarbeiters.ToList();
            return mitarbeiters;

        }
    }
}
