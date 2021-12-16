using PostmanAPI.Models;

namespace PostmanAPI.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonAsync();
        Task<Person> GetPersonByIdAsync(Guid id);
        Task<Person> CreatePersonAsync(Person person);
        Task<Person> UpdatePersonAsync(Person person);
        Task DeletePersonAsync(Guid id);
    }
}
