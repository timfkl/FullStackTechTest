using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SpecialityRepository : ISpecialityRepository
    {
        public Task<Speciality> GetByIdAsync(int specialityId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Speciality>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Speciality speciality)
        {
            throw new NotImplementedException();
        }
    }
}
