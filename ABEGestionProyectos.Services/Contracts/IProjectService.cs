using ABEGestionProyectos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Services.Contracts
{
   public interface IProjectService
    {
        public Task<List<Project>> GetAllAsync();
        public Task<IEnumerable<Project>> GetAllSimpleAsync();
        public Task<Project> GetAsync(int id);
        public Task<int> AddAsync(Project item);
        public Task<int> EditAsync(Project item);
        public Task<int> DeleteAsync(int id);
    }
}
