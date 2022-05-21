using ABEGestionProyectos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Services.Contracts
{
   public interface IChoreService
    {
        public Task<IEnumerable<Chore>> GetAllAsync(int IdUserHistory, int IdPerson);
        public Task<IEnumerable<Chore>> GetAllSimpleAsync();
        public Task<Chore> GetAsync(int id);
        public Task<int> AddAsync(Chore item);
        public Task<int> EditAsync(Chore item);
        public Task<int> DeleteAsync(int id);
    }
}
