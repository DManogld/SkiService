using ApiKeyCustomAttributes.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiService.DTO;
using SkiService.RegistrationDTO;
using SkiService.Services;

namespace SkiService.Controllers
{
    [ApiKey]
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IStatusServices _statusService;
        private readonly ILogger<StatusController> _logger;

        public StatusController(IStatusServices status)
        {
            _statusService = status;
        }


        [HttpGet]
        public IEnumerable<StatusDTO> GetAllClient()
        {
            try
            {
                return _statusService.GetAll();
            }
            catch (Exception ex )
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return (IEnumerable<StatusDTO>)NotFound("Error occured");
            }
        }

        [HttpGet("{status}")]
        public ActionResult<StatusDTO> GetByStatus(string status)
        {
            try
            {
                return _statusService.GetStatus(status);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound("Error occured");
            }
           
        }

    }
}
