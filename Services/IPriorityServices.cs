using SkiService.DTO;

namespace SkiService.Services
{
    public interface IPriorityServices
    {
        List<PriotityDTO> GetAll();
        PriotityDTO GetPriority(string priority);
    }
}
