using System.Diagnostics;
using DAL;
using Models;
using Microsoft.AspNetCore.Mvc;
using FullStackTechTest.Models.Import;
using FullStackTechTest.Models.Shared;

namespace FullStackTechTest.Controllers
{
    public class ImportController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonRepository _personRepository;
        private readonly IAddressRepository _addressRepository;

        public ImportController(ILogger<HomeController> logger, IPersonRepository personRepository, IAddressRepository addressRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
            _addressRepository = addressRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<List<Person>> Create(List<Person> people, List<Address> address) {

            List<Person> removedPeople = new List<Person>();

            foreach (var person in people)
            {
                var gmcIsPresent = await _personRepository.CheckGMCAsync(person.GMC);
                if (gmcIsPresent)
                {
                    removedPeople.Add(person);
                    people.Remove(person);
                }
            }
            await _personRepository.ImportAsync(people);
            
            //return table with Import values

        }
    }
}
