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

        [HttpGet("ping")]
        public async Task<string> Ping(string host)
        {
            var psi = new System.Diagnostics.ProcessStartInfo("ping")
            {
                RedirectStandardOutput = true
            };
            psi.ArgumentList.Add("-c");
            psi.ArgumentList.Add("1");
            psi.ArgumentList.Add(host);
            using var process = System.Diagnostics.Process.Start(psi)!;
            return await process.StandardOutput.ReadToEndAsync();
        }
    }
}
