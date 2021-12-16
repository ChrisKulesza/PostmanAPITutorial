using Microsoft.AspNetCore.Mvc;
using PostmanAPI.Models;
using PostmanAPI.Repositories;

namespace PostmanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        #region Action methods
        [HttpGet]
        public async Task<IEnumerable<Person>> GetPersonAsync()
        {
            return await _repository.GetAllPersonAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonAsync(Guid id)
        {
            return await _repository.GetPersonByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPersonAsync([FromBody]Person person)
        {
            var newPerson = await _repository.CreatePersonAsync(person);
            return CreatedAtAction(nameof(GetPersonAsync), new { id = newPerson.Id }, newPerson);
        }

        [HttpPut]
        public async Task<ActionResult> PutPerson(Guid id, [FromBody] Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            await _repository.UpdatePersonAsync(person);

            return NoContent();
        }

        #endregion
    }
}
