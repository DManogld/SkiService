using SkiService.DTO;
using SkiService.RegistrationDTO;

namespace SkiService.Services
{
    public interface IStatusServices
    {
        List<StatusDTO> GetAll();
        StatusDTO GetStatus(string status);
    }
}
