using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiService.DTO;
using SkiService.RegistrationDTO;
using SkiService.Services;

namespace SkiService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IStatusServices _statusService;

        public StatusController(IStatusServices status)
        {
            _statusService = status;
        }


        [HttpGet]
        public IEnumerable<StatusDTO> GetAllClient()
        {

            return _statusService.GetAll();

        }

        [HttpGet("{status}")]
        public ActionResult<StatusDTO> GetByStatus(string status)
        {
            return _statusService.GetStatus(status);
        }

    }
}
