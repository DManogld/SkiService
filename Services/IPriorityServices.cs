using SkiService.DTO;

namespace SkiService.Services
{
    /// <summary>
    /// Interface für PriorityDbService
    /// </summary>
    public interface IPriorityServices
    {
        List<PriotityDTO> GetAll();
        PriotityDTO GetPriority(string priority);
    }
}
