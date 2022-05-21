using ABEGestionProyectos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Services.Contracts
{
   public interface IEpicService
    {
        public Task<IEnumerable<Epic>> GetAllAsync(int IdProject);
        public Task<IEnumerable<Epic>> GetAllSimpleAsync();
        public Task<Epic> GetAsync(int id);
        public Task<int> AddAsync(Epic item);
        public Task<int> EditAsync(Epic item);
        public Task<int> DeleteAsync(int id);



    }
}
