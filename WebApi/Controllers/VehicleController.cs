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
        public async Task<IActionResult> Get([FromQuery] int offset = 0, [FromQuery] int limit = 20)
        {
            var vehicles = await _vehicleUsecase.GetVehicles(offset, limit);
            return Ok(new { vehicles });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _vehicleUsecase.GetVehicle(id);
            return Ok(new { vehicle });
        }

        
        [HttpGet("{id}/current")]
        public async Task<IActionResult> GetCurrentStatus(int id)
        {
            var result = await _vehicleUsecase.GetVehicle(id);
            return Ok(new { result });
            
        }

        
        [HttpGet("{id}/range")]
        public async Task<IActionResult> GetRangeStatus(int id, [FromQuery] long from, [FromQuery] long to)
        {
            var fromTime = _datetimeService.FromUnixMilliSecond(from);
            var toTime = _datetimeService.FromUnixMilliSecond(to);
            var result = await _vehicleUsecase.GetStatus(id, fromTime, toTime);
            return Ok(new { result });
        }

        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] VehicleRegisterInputModel vehicle)
        {
            var result = await _vehicleUsecase.Register(vehicle.Name);
            return Ok(new { result });
        }

        
        [HttpPut("status")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateStatus([FromBody] StatusInputModel status)
        {
            var result = await _vehicleUsecase.Update(status);
            return Ok(new { result });
        }
    }
}
