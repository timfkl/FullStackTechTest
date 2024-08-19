using DAL;
using Models;

namespace FullStackTechTest.Models.Home;

public class DetailsViewModel
{
    public Person Person { get; set; }
    public Address Address { get; set; }
    public List<PersonSpecialities> PersonSpecialitiesList { get; set; }
    public List<Speciality> SpecialityList { get; set; }
    public bool IsEditing { get; set; }

    public static async Task<DetailsViewModel> CreateAsync(int personId, bool isEditing, IPersonRepository personRepository, IAddressRepository addressRepository, 
        IPersonSpecialitiesRepository personSpecialitiesRepository, ISpecialityRepository specialityRepository)
    {
        var model = new DetailsViewModel
        {
            Person = await personRepository.GetByIdAsync(personId),
            Address = await addressRepository.GetForPersonIdAsync(personId),
            PersonSpecialitiesList = await personSpecialitiesRepository.ListForPersonIdAsync(personId),
            SpecialityList = await specialityRepository.ListAllAsync(),
            IsEditing = isEditing
        };
        return model;
    }

    public bool PersonHasSpeciality(Speciality speciality)
    {
        return this.PersonSpecialitiesList.Any(x => x.SpecialityId == speciality.Id);
    }
}