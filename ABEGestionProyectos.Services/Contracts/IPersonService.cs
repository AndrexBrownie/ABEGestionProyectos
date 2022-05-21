using ABEGestionProyectos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Services.Contracts
{
   public interface IPersonService
    {
        public Task<IEnumerable<Person>> GetAllAsync(int IdRole);
        public Task<IEnumerable<Person>> GetAllSimpleAsync();
        public Task<Person> GetAsync(int id);
        public Task<int> AddAsync(Person item);
        public Task<int> EditAsync(Person item);
        public Task<int> DeleteAsync(int id);
    }
}
