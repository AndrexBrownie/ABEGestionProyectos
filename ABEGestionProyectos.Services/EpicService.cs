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
    public class EpicService : IEpicService
    {
        private readonly GestionProyectosDBContext _context;
        public EpicService(GestionProyectosDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Epic>> GetAllAsync(int IdProject)
        {
            var query = _context.Epics.Include("Project");

            if (IdProject > 0)
            {
                query = query.Where(x => x.ProjectID == IdProject);
            }

            return await query.ToListAsync();
        }

        public async Task<Epic> GetAsync(int id)
        {
            return await _context.Epics.FindAsync(id);
        }
        public async Task<int> AddAsync(Epic item)
        {
            _context.Epics.Add(item);

            return await _context.SaveChangesAsync();
        }
        public async Task<int> EditAsync(Epic item)
        {
            _context.Epics.Update(item);

            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int id)
        {
            var item = await _context.Epics.FindAsync(id);
            _context.Epics.Remove(item);
            return await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Epic>> GetAllSimpleAsync()
        {
            var query = _context.Epics.Select(k =>
           new Epic { EpicID = k.EpicID, Name = k.Name });

            return await query.ToListAsync();
        }
    }
}
