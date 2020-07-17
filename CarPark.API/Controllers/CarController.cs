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
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        public CarController(ICarService carService,IMapper mapper) {
            _carService = carService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var car = await _carService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CarDto>>(car));
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var car = await _carService.GetByIdAsync(id);
            return Ok(_mapper.Map<CarDto>(car));

        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/park")]
        public async Task<IActionResult> GetWithParkById(int id) {
            var car = await _carService.GetWithParkByIdAsync(id);
            return Ok(_mapper.Map<CarWithParkDto>(car));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(CarDto carDto) {
            var car = await _carService.AddAsync(_mapper.Map<Car>(carDto));
            return Created(string.Empty, _mapper.Map<CarDto>(car));
        }
        [HttpPut]
        public IActionResult Update(CarDto carDto) {
            var car = _carService.Update(_mapper.Map<Car>(carDto));
            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id) {
            var car = _carService.GetByIdAsync(id).Result;
            _carService.Remove(car);
            return NoContent();
        }
    }
}