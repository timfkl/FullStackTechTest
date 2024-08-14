using Models;

namespace DAL;

public interface IPersonSpecialitiesRepository
{
    Task<List<PersonSpecialities>> ListAllAsync();
    Task<PersonSpecialities> GetForPersonIdAsync(int personId);
    Task SaveAsync(PersonSpecialities personSpecialities);
}