using ABEGestionProyectos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Services.Contracts
{
   public interface ISprintService
    {
        public Task<List<Sprint>> GetAllAsync();
        public Task<IEnumerable<Sprint>> GetAllSimpleAsync();
        public Task<Sprint> GetAsync(int id);
        public Task<int> AddAsync(Sprint item);
        public Task<int> EditAsync(Sprint item);
        public Task<int> DeleteAsync(int id);
    }
}
