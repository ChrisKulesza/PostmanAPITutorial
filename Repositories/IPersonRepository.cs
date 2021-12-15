using PostmanAPI.Models;

namespace PostmanAPI.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonAsync();
        Task<Person> GetPerson(Guid id);
        Task<Person> Create(Person person);
        Task<Person> Update(Person person);
        Task Delete(Guid id);
    }
}
