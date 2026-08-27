using LearnAws.Dtos;
using LearnAws.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAws.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> GetByIdAsync([FromServices] IPeopleRepository peopleRepository, int id)
        {
            var person = await peopleRepository.FindByIdAsync(id);
            return Ok(person);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll([FromServices] IPeopleRepository peopleRepository)
        {
            var people = await peopleRepository.FindAllAsync();
            return Ok(people);
        }
    }
}
