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

        public MitarbeiterController(IMitarbeiterDbService mitarbeiter)
        {
            _mitarbeiterService = mitarbeiter;
        }

        [HttpGet]
        public IEnumerable<Mitarbeiter> GetAll()
        {
            List<Mitarbeiter> mitarbeiter = _mitarbeiterService.GetAll();

            ////List<MitarbeiterDTO> result = new List<MitarbeiterDTO>();
            //mitarbeiter.ForEach(e => result.Add(new Mitarbeiter()
            //{
            //    MitarbeiterID = e.MitarbeiterID,
            //    MitarbeiterName = e.MitarbeiterName,
            //    MitarbeiterApiKey = e.MitarbeiterApiKey,

            //}));
            return  mitarbeiter;
        }

    }
}
