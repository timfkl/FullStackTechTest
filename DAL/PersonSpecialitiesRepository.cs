using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonSpecialitiesRepository : IPersonSpecialitiesRepository
    {
        public async Task<PersonSpecialities> GetForPersonIdAsync(int personId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PersonSpecialities>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(PersonSpecialities personSpecialities)
        {
            throw new NotImplementedException();
        }
    }
}
