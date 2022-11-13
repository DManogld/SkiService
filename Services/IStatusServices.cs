using SkiService.DTO;
using SkiService.RegistrationDTO;

namespace SkiService.Services
{
    /// <summary>
    /// Interface für StatusDbService
    /// </summary>
    public interface IStatusServices
    {
        List<StatusDTO> GetAll();
        StatusDTO GetStatus(string status);
    }
}
