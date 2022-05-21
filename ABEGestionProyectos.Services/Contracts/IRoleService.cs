using ABEGestionProyectos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Services.Contracts
{
   public interface IRoleService
    {
        public Task<List<Role>> GetAllAsync();
        public Task<IEnumerable<Role>> GetAllSimpleAsync();
        public Task<Role> GetAsync(int id);
        public Task<int> AddAsync(Role item);
        public Task<int> EditAsync(Role item);
        public Task<int> DeleteAsync(int id);
    }
}
