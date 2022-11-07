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

        public PriorityController(IPriorityServices prio)
        {
            _priotityService = prio;
        }

        [HttpGet]
        public IEnumerable<PriotityDTO> GetAllClient()
        {
            return _priotityService.GetAll();

        }

        [HttpGet("{priority}")]
        public ActionResult<PriotityDTO> GetByPriority(string priority)
        {
            return _priotityService.GetPriority(priority);
        }
    }
}
