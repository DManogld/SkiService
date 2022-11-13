using ApiKeyCustomAttributes.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiService.DTO;
using SkiService.Services;

namespace SkiService.Controllers
{
    [ApiKey]
    [Route("[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {

        private IPriorityServices _priotityService;
        private readonly ILogger<PriorityController> _logger;

        /// <summary>
        /// Konstruktor für instanziierung von Interface und Logger
        /// </summary>
        /// <param name="prio"></param>
        /// <param name="logger"></param>
        public PriorityController(IPriorityServices prio, ILogger<PriorityController> logger)
        {
            _priotityService = prio;
            _logger = logger;
        }

        /// <summary>
        /// GetAllClient Methode welche Service aufruft
        /// </summary>
        /// <returns>PriorityDTO</returns>
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

        /// <summary>
        /// GetByPriority Methode welche Service aufruft
        /// </summary>
        /// <param name="priority"></param>
        /// <returns>PriorityDTO</returns>
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
