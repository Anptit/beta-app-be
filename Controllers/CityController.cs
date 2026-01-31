using BetaTheaterBE.Services;
using Microsoft.AspNetCore.Mvc;
using BetaTheaterBE.Model;

namespace BetaTheaterBE.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<List<City>> Get() => await _cityService.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] City newCity)
        {
            var existing = await _cityService.CheckCityCodeExistsAsync(newCity.CityCode);
            if (existing)
            {
                return Conflict("City code already exists.");
            }

            await _cityService.CreateAsync(newCity);
            return CreatedAtAction(nameof(Get), new { id = newCity.Id }, newCity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> Get(string id)
        {
            var city = await _cityService.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // [HttpPut("{id}")]
        // public async Task
    }
}