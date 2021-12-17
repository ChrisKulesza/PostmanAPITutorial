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

        /// <summary>
        /// Retrieves all the records in the database in the appropriate table.
        /// </summary>
        /// <returns>Returns a <see cref="IEnumerable{T}" /> that contains all data records of a database table.</returns>
        #region Action methods
        [HttpGet]
        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _repository.GetAllPersonAsync();
        }

        /// <summary>
        /// Retrieves a specific record in the database in the corresponding table.
        /// </summary>
        /// <param name="id">Identifier of the transferred object.</param>
        /// <returns>An object of the type Person.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonAsync(Guid id)
        {
            return await _repository.GetPersonByIdAsync(id);
        }

        /// <summary>
        /// Creates a new record in the database.
        /// </summary>
        /// <param name="person">The entity of the object passed.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Person>> PostPersonAsync(Person person)
        {
            var newPerson = await _repository.CreatePersonAsync(person);
            return CreatedAtAction(nameof(GetPersonAsync), new { guid = newPerson.Id }, newPerson);
        }

        /// <summary>
        /// Changes an existing data record in the database. The data record is identified via the Guid.
        /// </summary>
        /// <param name="id">Identifier of the transferred object.</param>
        /// <param name="person">The identifier of the object passed.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPersonAsync(Guid id, [FromBody] Person person)
        {
            if (id != person.Id)
            {
                // return status code 400
                return BadRequest("Ids did not match.");
            }

            await _repository.UpdatePersonAsync(person);
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Identifier of the transferred object.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonAsync(Guid id)
        {
            var personToDelete = await _repository.GetPersonByIdAsync(id);

            if (personToDelete == null)
            {
                return NotFound();
            }

            await _repository.DeletePersonAsync(id);
            return NoContent();
        }
        #endregion
    }
}
