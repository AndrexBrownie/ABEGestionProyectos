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
    public class ProjectService : IProjectService
    {
        private readonly GestionProyectosDBContext _context;
        public ProjectService(GestionProyectosDBContext context)
        {
            _context = context; 
        }

        public async Task<List<Project>> GetAllAsync()
        {
            /*var query = from e in _context.Projects select e;
            return await query.ToListAsync();*/

            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }
        public async Task<int> AddAsync(Project item)
        {
            _context.Projects.Add(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> EditAsync(Project item)
        {
            _context.Projects.Update(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var item =  await _context.Projects.FindAsync(id);
            _context.Projects.Remove(item);
            return await _context.SaveChangesAsync();


        }

        public async Task<IEnumerable<Project>> GetAllSimpleAsync()
        {
            var query = _context.Projects.Select(k =>
           new Project { ProjectID = k.ProjectID, Name = k.Name });

            return await query.ToListAsync();
        }
    }
}
