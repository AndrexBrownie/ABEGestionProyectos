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
    public class ChoreService : IChoreService
    {
        private readonly GestionProyectosDBContext _context;

        public ChoreService(GestionProyectosDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Chore>> GetAllAsync(int IdUserHistory, int IdPerson)
        {
            var query = _context.Chores.Include("UserHistory").Include("Person");

            if (IdUserHistory > 0)
            {
                query = query.Where(x => x.UserHistoryID == IdUserHistory);
            }

            if (IdPerson > 0)
            {
                query = query.Where(x => x.PersonID == IdPerson);
            }

            return await query.ToListAsync();
        }

        public async Task<Chore> GetAsync(int id)
        {
            return await _context.Chores.FindAsync(id);
        }

        public async Task<int> AddAsync(Chore item)
        {
            _context.Chores.Add(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> EditAsync(Chore item)
        {
            _context.Chores.Update(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var item = await _context.Chores.FindAsync(id);
            _context.Chores.Remove(item);
            return await _context.SaveChangesAsync();
        }



        public Task<IEnumerable<Chore>> GetAllSimpleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
