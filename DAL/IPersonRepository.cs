using Models;

namespace DAL;

public interface IPersonRepository
{
    Task<List<Person>> ListAllAsync();
    Task<Person> GetByIdAsync(int personId);
    Task SaveAsync(Person person);
    Task CreateAsync(Person person);
    Task ImportAsync(List<Person> people);
    Task<bool> CheckGMCAsync(int gmc);


}