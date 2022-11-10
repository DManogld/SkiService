using Microsoft.AspNetCore.Mvc;
using SkiService.Models;
using SkiService.Services;
using SkiService.RegistrationDTO;
using System;
using Serilog.Core;

namespace SkiService.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistrationController : ControllerBase
{

    private IRegistrationServices _registrationService;
    private readonly ILogger<RegistrationController> _logger;
    public RegistrationController(IRegistrationServices registration, ILogger<RegistrationController> logger)
	{		
		_registrationService = registration;
        _logger = logger;
    }

	// GET all action
	[HttpGet]
	public IEnumerable<ClientDTO> GetAllClient()
	{
        try
        {
            return _registrationService.GetAll();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error occured, {ex.Message}");
            return (IEnumerable<ClientDTO>)NotFound($"Error occured, {ex.Message}");
        }
	
	}

	// GET by ClientID action
	[HttpGet("{id}")]
	public ActionResult<ClientDTO> Get(int id)
	{
		try
		{
            return _registrationService.Get(id);

        }
		catch (Exception ex)
		{
            _logger.LogError($"Error occured, {ex.Message}");
            return NotFound($"Error occured, {ex.Message}");
        }	

	}


	// POST action
	[HttpPost]
	public ActionResult<Client> PostClent(ClientDTO registration)
	{
        try
        {
            _registrationService.Add(registration);
            return CreatedAtAction(nameof(PostClent), new { id = registration.ClientID }, registration);

        }
        catch (Exception ex)
        {
            _logger.LogError($"Error occured, {ex.Message}");
            return NotFound($"Error occured, {ex.Message}");
        }
     
	}


    // PUT action
    [HttpPut("{id}")] // Geht noch nicht 
	public IActionResult Update(ClientDTO registration)
	{

        try
        {
            _registrationService.Update(registration);
            return NoContent();

        }
        catch (Exception ex)
        {
            _logger.LogError($"Error occured, {ex.Message}");
            return NotFound($"Error occured, {ex.Message}");
        }       

		
	}


	// DELETE action
	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
	{
        try
        {
            var registration = _registrationService.Get(id);

            if (registration is null)
                return NotFound();

            _registrationService.Delete(id);
            return Content($"Item in row {id} is deleted.");

        }
        catch (Exception ex)
        {
            _logger.LogError($"Error occured, {ex.Message}");
            return NotFound($"Error occured, {ex.Message}");
        }
		
	}
}