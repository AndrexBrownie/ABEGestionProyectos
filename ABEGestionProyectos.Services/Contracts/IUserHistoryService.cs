using ABEGestionProyectos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Services.Contracts
{
   public interface IUserHistoryService
    {
        public Task<IEnumerable<UserHistory>> GetAllAsync(int IdEpic, int IdSprint);
        //  public Task<IEnumerable<UserHistory>> GetAllAsyncs(int IdSprint);
        public Task<IEnumerable<UserHistory>> GetAllSimpleAsync();
        public Task<UserHistory> GetAsync(int id);
        public Task<int> AddAsync(UserHistory item);
        public Task<int> EditAsync(UserHistory item);
        public Task<int> DeleteAsync(int id);
    }
}
