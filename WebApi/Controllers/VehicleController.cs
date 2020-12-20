using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Application.Interfaces.Usecases;
using Application.Interfaces.Services;
using Application.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleUsecase _vehicleUsecase;
        private readonly IDateTimeService _datetimeService;

        public VehicleController(IVehicleUsecase vehicleUsecase, IDateTimeService datetimeService)
        {
            _vehicleUsecase = vehicleUsecase;
            _datetimeService = datetimeService;
        }
        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(string id)
        {
            var vehicle = await _vehicleUsecase.GetVehicle(id);
            
            return Ok(new { vehicle });
        }

        // GET api/<CarController>/5
        [HttpGet("{id}/current")]
        public Task<IActionResult> GetCurrentStatus(string id)
        {
            //var vehicle = await _vehicleUsecase.GetVehicle(id);
            //var currentStatus = await _vehicleUsecase.GetStatus(id);
            //var result = VehicleOutputModel.FromVehicle(vehicle, currentStatus);
            //return Ok(new { result });
            throw new NotImplementedException();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}/range")]
        public async Task<IActionResult> GetRangeStatus(string id, [FromQuery] string qFrom, [FromQuery] string qTo)
        {
            var from = _datetimeService.FromISO(qFrom);
            var to = _datetimeService.FromISO(qTo);
            var result = await _vehicleUsecase.GetStatus(id, from, to);
            return Ok(new { result });
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] VehicleRegisterInputModel vehicle)
        {
            var result = await _vehicleUsecase.Register(vehicle.Name);
            return Ok(new { result });
        }

        // PUT api/<CarController>
        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus([FromBody] StatusInputModel status)
        {
            var result = await _vehicleUsecase.Update(status);
            return Ok(new { result });
        }
    }
}
