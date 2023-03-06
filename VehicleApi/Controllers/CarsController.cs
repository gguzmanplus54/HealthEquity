using HealthEquity.Models;
using HealthEquity.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthEquity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            var cars = _carService.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public IActionResult AddCar([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            _carService.AddCar(car);

            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] Car car)
        {
            if (car == null || id != car.Id)
            {
                return BadRequest();
            }

            var existingCar = _carService.GetCarById(id);
            if (existingCar == null)
            {
                return NotFound();
            }

            _carService.UpdateCar(car);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            _carService.RemoveCar(car);

            return NoContent();
        }
    }
}