using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Entities;
using Application.Interfaces.Usecases;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleUsecase _vehicleUsecase;
        private readonly IDatetimeService _datetimeService;

        public VehicleController(IVehicleUsecase vehicleUsecase, IDatetimeService datetimeService)
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
        public async Task<IActionResult> GetCurrentStatus(string id)
        {
            var vehicle = await _vehicleUsecase.GetVehicle(id);
            var currentStatus = await _vehicleUsecase.GetStatus(id);
            var result = VehicleDTO.FromVehicle(vehicle, currentStatus);
            return Ok(new { result });
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
        public async Task<IActionResult> Register([FromBody] string name)
        {
            Console.WriteLine(name);
            var result = await _vehicleUsecase.Register(name);
            return Ok(new { result });
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Status status)
        {
            var result = await _vehicleUsecase.Update(status);
            return Ok(new { result });
        }
    }
}
