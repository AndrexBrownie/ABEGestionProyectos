using ABEGestionProyectos.Core.Models;
using ABEGestionProyectos.Infrastructure;
using ABEGestionProyectos.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Services
{
    public class UserHistoryService : IUserHistoryService
    {
        private readonly GestionProyectosDBContext _context;

        public UserHistoryService(GestionProyectosDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserHistory>> GetAllAsync(int IdEpic, int IdSprint)
        {
            var query = _context.UserHistories.Include("Epic").Include("Sprint");
            //var query2 = _context.UserHistories.Include("Sprint");

            if (IdEpic > 0)
            {
                query = query.Where(x => x.EpicID == IdEpic) ;
            }

            if (IdSprint > 0)
            {
                query = query.Where(x => x.SprintID == IdSprint);
            }

            return await query.ToListAsync();
        }

       /* public async Task<IEnumerable<UserHistory>> GetAllAsyncs(int IdSprint)
        {
            var query = _context.UserHistories.Include("Sprint");

            if (IdSprint > 0)
            {
                query = query.Where(x => x.SprintID == IdSprint);
            }

            return await query.ToListAsync();
        }*/
        public async Task<UserHistory> GetAsync(int id)
        {
            return await _context.UserHistories.FindAsync(id);
        }

        public async Task<int> AddAsync(UserHistory item)
        {
            _context.UserHistories.Add(item);

            return await _context.SaveChangesAsync();
        }


        public async Task<int> EditAsync(UserHistory item)
        {
            _context.UserHistories.Update(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var item = await _context.UserHistories.FindAsync(id);
            _context.UserHistories.Remove(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserHistory>> GetAllSimpleAsync()
        {
            var query = _context.UserHistories.Select(k =>
           new UserHistory { UserHistoryID  = k.UserHistoryID, Title = k.Title });

            return await query.ToListAsync();
        }
    }
}
