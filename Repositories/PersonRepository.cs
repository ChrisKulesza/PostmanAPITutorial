using Microsoft.EntityFrameworkCore;
using PostmanAPI.Data;
using PostmanAPI.Models;

namespace PostmanAPI.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return person;
        }

        public async Task DeletePersonAsync(Guid id)
        {
            var personToDelete = await _context.Persons.FindAsync(id);

            if (personToDelete != null)
            {
                _context.Persons.Remove(personToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Person>> GetAllPersonAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(Guid id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<Person> UpdatePersonAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return person;
        }
    }
}
