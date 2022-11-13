using ApiKeyCustomAttributes.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiService.DTO;
using SkiService.RegistrationDTO;
using SkiService.Services;

namespace SkiService.Controllers
{
    /// <summary>
    /// Controller für Status
    /// </summary>
    [ApiKey]
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IStatusServices _statusService;
        private readonly ILogger<StatusController> _logger;

        /// <summary>
        /// Konstruktor für instanziierung von Interface und Logger
        /// </summary>
        /// <param name="status"></param>
        /// <param name="logger"></param>
        public StatusController(IStatusServices status, ILogger<StatusController> logger)
        {
            _statusService = status;
            _logger = logger;
        }


        /// <summary>
        /// GetAllClient Methode welche Service aufruft
        /// </summary>
        /// <returns>Liste von StatusDTO</returns>
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

        /// <summary>
        /// GetByStatus Methode welche Service aufruft
        /// </summary>
        /// <param name="status">status</param>
        /// <returns>StatusDTO</returns>
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
