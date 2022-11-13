using ApiKeyCustomAttributes.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiService.DTO;
using SkiService.Migrations;
using SkiService.Models;
using SkiService.RegistrationDTO;
using SkiService.Services;

namespace SkiService.Controllers
{
    [ApiKey]
    [Route("[controller]")]
    [ApiController]
    public class MitarbeiterController : ControllerBase
    {
        private IMitarbeiterDbService _mitarbeiterService;
        private readonly ILogger<MitarbeiterController> _logger;

        /// <summary>
        /// Konstruktor für instanziierung von Interface und Logger
        /// </summary>
        /// <param name="mitarbeiter"></param>
        /// <param name="logger"></param>
        public MitarbeiterController(IMitarbeiterDbService mitarbeiter, ILogger<MitarbeiterController> logger)
        {
            _mitarbeiterService = mitarbeiter;
            _logger = logger;
        }

        /// <summary>
        /// GetAll Methode welche Service aufruft
        /// </summary>
        /// <returns>Mitarbeiter</returns>
        [HttpGet]
        public IEnumerable<Mitarbeiter> GetAll()
        {
            List<Mitarbeiter> mitarbeiter = _mitarbeiterService.GetAll();
            return  mitarbeiter;
        }

    }
}