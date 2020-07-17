using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarPark.API.DTOs;
using CarPark.API.Filters;
using CarPark.Core.Models;
using CarPark.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkController : ControllerBase
    {
        private readonly IParkService _parkService;
        private readonly IMapper _mapper;
        public ParkController(IParkService parkService,IMapper mapper) {
            _parkService = parkService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var park = await _parkService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ParkDto>>(park));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var park = await _parkService.GetByIdAsync(id);
            return Ok(_mapper.Map<ParkDto>(park));

        }
        [HttpGet("{id}/cars")]
        public async Task<IActionResult> GetWithCarsById(int id) {
            var park = await _parkService.GetWithCarsByIdAsync(id);
            return Ok(_mapper.Map<ParkWithCarDto>(park));

        }
       
        [HttpPost]
        public async Task<IActionResult> Save(ParkDto parkDto) {
            var park = await _parkService.AddAsync(_mapper.Map<Park>(parkDto));
            return Created(string.Empty,_mapper.Map<ParkDto>(park));
        }
        [HttpPut]
        public IActionResult Update(ParkDto parkDto) {
            var park = _parkService.Update(_mapper.Map<Park>(parkDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id) {
            var park = _parkService.GetByIdAsync(id).Result;
            _parkService.Remove(park);
            return NoContent();
        }
       
    }
   
}