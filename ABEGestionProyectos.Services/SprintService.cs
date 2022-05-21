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
    public class SprintService : ISprintService
    {
        private readonly GestionProyectosDBContext _context;
        public SprintService(GestionProyectosDBContext context)
        {
            _context = context;
        }


        public async Task<List<Sprint>> GetAllAsync()
        {
            return await _context.Sprints.ToListAsync();
        }
        public async Task<Sprint> GetAsync(int id)
        {
            return await _context.Sprints.FindAsync(id);
        }

        public async Task<int> AddAsync(Sprint item)
        {
            _context.Sprints.Add(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> EditAsync(Sprint item)
        {
            _context.Sprints.Update(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var item = await _context.Sprints.FindAsync(id);
            _context.Sprints.Remove(item);
            return await _context.SaveChangesAsync();
        }



        public async Task<IEnumerable<Sprint>> GetAllSimpleAsync()
        {
            var query = _context.Sprints.Select(k =>
           new Sprint { SprintID = k.SprintID, Name = k.Name });

            return await query.ToListAsync();
        }

        
    }
}
