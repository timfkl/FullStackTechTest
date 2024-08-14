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
        public Task<PersonSpecialities> GetForPersonIdAsync(int personId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonSpecialities>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(PersonSpecialities personSpecialities)
        {
            throw new NotImplementedException();
        }
    }
}
