using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Application.Interfaces.Usecases;
using Application.Interfaces.Services;
using Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleUsecase _vehicleUsecase;
        private readonly IDateTimeService _datetimeService;

        public VehicleController(IVehicleUsecase vehicleUsecase, IDateTimeService datetimeService)
        {
            _vehicleUsecase = vehicleUsecase;
            _datetimeService = datetimeService;
        }
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _vehicleUsecase.GetVehicle(id);
            
            return Ok(new { vehicle });
        }

        // GET api/<CarController>/5
        [HttpGet("{id}/current")]
        public async Task<IActionResult> GetCurrentStatus(int id)
        {
            var result = await _vehicleUsecase.GetVehicle(id);
            return Ok(new { result });
            
        }

        // GET api/<CarController>/5
        [HttpGet("{id}/range")]
        public async Task<IActionResult> GetRangeStatus(int id, [FromQuery] string qFrom, [FromQuery] string qTo)
        {
            var from = _datetimeService.FromISO(qFrom);
            var to = _datetimeService.FromISO(qTo);
            var result = await _vehicleUsecase.GetStatus(id, from, to);
            return Ok(new { result });
        }

        // POST api/<CarController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] VehicleRegisterInputModel vehicle)
        {
            var result = await _vehicleUsecase.Register(vehicle.Name);
            return Ok(new { result });
        }

        // PUT api/<CarController>
        [HttpPut("status")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateStatus([FromBody] StatusInputModel status)
        {
            var result = await _vehicleUsecase.Update(status);
            return Ok(new { result });
        }
    }
}
