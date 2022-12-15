using APIREST_.NET6_MySQL.Data.repositories;
using APIREST_.NET6_MySQL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIREST_.NET6_MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _CarRepository;

        public CarsController(ICarRepository carRepository)
        {
            _CarRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _CarRepository.GetAllCars());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDetails(int id)
        {
            return Ok(await _CarRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            if(car == null)
            {
                return BadRequest();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _CarRepository.InsertCar(car);
            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Created = await _CarRepository.InsertCar(car);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _CarRepository.DeleteCar(new Car { Id = id });
            return NoContent();
        }
    }
}
