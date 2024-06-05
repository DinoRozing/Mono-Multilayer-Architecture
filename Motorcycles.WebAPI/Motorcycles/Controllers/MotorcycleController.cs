using Microsoft.AspNetCore.Mvc;
using Motorcycles.Repository.Common;
using Motorcycles.Service.Common;
using Motorcycles.Model;
using System;

namespace Motorcycles.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMotorcycleService _motorcycleService;

        public MotorcycleController(IMotorcycleService motorcycleService)
        {
            _motorcycleService = motorcycleService;
        }

        [HttpPost]
        [Route("AddMotorcycle")]
        public IActionResult AddMotorcycle([FromBody] Motorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                return BadRequest("Motorcycle data is null.");
            }

            try
            {
                _motorcycleService.AddMotorcycle(motorcycle);
                return Ok("Motorcycle added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("UpdateMotorcycle")]
        public IActionResult UpdateMotorcycle([FromBody] Motorcycle motorcycle)
        {
            if (motorcycle == null || motorcycle.Id == 0)
            {
                return BadRequest("Invalid motorcycle data.");
            }

            try
            {
                _motorcycleService.UpdateMotorcycle(motorcycle);
                return Ok("Motorcycle updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeleteMotorcycle")]
        public IActionResult DeleteMotorcycle(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid motorcycle ID.");
            }

            try
            {
                _motorcycleService.DeleteMotorcycle(id);
                return Ok($"Motorcycle with Id = {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetMotorcycle")]
        public IActionResult GetMotorcycle(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid motorcycle ID.");
            }

            try
            {
                var motorcycle = _motorcycleService.GetMotorcycle(id);
                if (motorcycle != null)
                {
                    return Ok(motorcycle);
                }
                else
                {
                    return NotFound($"Motorcycle with Id = {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetMotorcycleByName")]
        public IActionResult GetMotorcyclesByUserName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return BadRequest("Invalid user name.");
            }

            try
            {
                var motorcycles = _motorcycleService.GetMotorcyclesByUserName(firstName, lastName);
                return Ok(motorcycles);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
