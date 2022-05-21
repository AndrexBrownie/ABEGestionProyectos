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
    public class RoleService : IRoleService
    {
        private readonly GestionProyectosDBContext _context;
        public RoleService(GestionProyectosDBContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAllAsync()
        {

            return await _context.Roles.ToListAsync();
        }
        public async Task<Role> GetAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }
        public async Task<int> AddAsync(Role item)
        {
            _context.Roles.Add(item);

            return await _context.SaveChangesAsync();
        }
        public async Task<int> EditAsync(Role item)
        {
            _context.Roles.Update(item);

            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int id)
        {
            var item = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(item);
            return await _context.SaveChangesAsync();
        }

        

  

        public async Task<IEnumerable<Role>> GetAllSimpleAsync()
        {
            var query = _context.Roles.Select(k =>
           new Role { RoleID = k.RoleID, Name = k.Name });

            return await query.ToListAsync();
        }

        
    }
      
}
