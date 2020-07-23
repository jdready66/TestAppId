using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAppId.API.Data;
using TestAppId.API.Dtos;
using TestAppId.API.Models;

namespace TestAppId.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IMainRepository _repo;
        public ValuesController(IMainRepository repo)
        { _repo = repo; }

        [HttpPost]
        public async Task<IActionResult> AddValue(ValueToAddDto valueToAddDto)
        {
            var newValue = new Value()
            {
                Name = valueToAddDto.Name
            };

            _repo.Add(newValue);
            if (await _repo.SaveAll()) { return Ok(newValue); }

            return BadRequest("Error saving new Value");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _repo.GetValue(id);

            if (value == null) { return NotFound(); }
            return Ok(value);
        }
    }

}