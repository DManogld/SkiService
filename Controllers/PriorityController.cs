using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiService.DTO;
using SkiService.Services;

namespace SkiService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {

        private IPriorityServices _priotityService;
        private readonly ILogger<StatusController> _logger;

        public PriorityController(IPriorityServices prio)
        {
            _priotityService = prio;
        }

        [HttpGet]
        public IEnumerable<PriotityDTO> GetAllClient()
        {
            try
            {
                return _priotityService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return (IEnumerable<PriotityDTO>)NotFound("Error occured");

            }

        }

        [HttpGet("{priority}")]
        public ActionResult<PriotityDTO> GetByPriority(string priority)
        {
            try
            {
                return _priotityService.GetPriority(priority);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound("Error occured");

            }
     
        }
    }
}
