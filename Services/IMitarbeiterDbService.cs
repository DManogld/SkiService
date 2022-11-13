using SkiService.Models;


namespace SkiService.Services
{
    /// <summary>
    /// Interface für MitarbeiterService
    /// </summary>
    public interface IMitarbeiterDbService
    {    
            List<Mitarbeiter> GetAll();
    }
}
