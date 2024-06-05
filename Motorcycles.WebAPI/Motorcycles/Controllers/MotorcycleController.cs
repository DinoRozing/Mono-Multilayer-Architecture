using Microsoft.AspNetCore.Mvc;
using Motorcycles.Repository.Common;
using Motorcycles.Service.Common;
using Motorcycles.Model;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> AddMotorcycleAsync([FromBody] Motorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                return BadRequest("Motorcycle data is null.");
            }

            try
            {
                await _motorcycleService.AddMotorcycleAsync(motorcycle);
                return Ok("Motorcycle added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("UpdateMotorcycle")]
        public async Task<IActionResult> UpdateMotorcycleAsync([FromBody] Motorcycle motorcycle)
        {
            if (motorcycle == null || motorcycle.Id == 0)
            {
                return BadRequest("Invalid motorcycle data.");
            }

            try
            {
                await _motorcycleService.UpdateMotorcycleAsync(motorcycle);
                return Ok("Motorcycle updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeleteMotorcycle")]
        public async Task<IActionResult> DeleteMotorcycleAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid motorcycle ID.");
            }

            try
            {
                await _motorcycleService.DeleteMotorcycleAsync(id);
                return Ok($"Motorcycle with Id = {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetMotorcycle")]
        public async Task<IActionResult> GetMotorcycleAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid motorcycle ID.");
            }

            try
            {
                var motorcycle = await _motorcycleService.GetMotorcycleAsync(id);
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
        public async Task<IActionResult> GetMotorcyclesByUserNameAsync(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return BadRequest("Invalid user name.");
            }

            try
            {
                var motorcycles = await _motorcycleService.GetMotorcyclesByUserNameAsync(firstName, lastName);
                return Ok(motorcycles);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}