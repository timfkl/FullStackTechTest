using Models;

namespace DAL;

public interface IPersonSpecialitiesRepository
{
    Task<List<PersonSpecialities>> ListForPersonIdAsync(int personId);
    Task SaveAsync(PersonSpecialities personSpecialities);
}