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
    public class PersonService : IPersonService
    {
        private readonly GestionProyectosDBContext _context;
        public PersonService(GestionProyectosDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllAsync(int IdRole)
        {
            var query = _context.People.Include("Role");

            if (IdRole > 0)
            {
                query = query.Where(x => x.RoleID == IdRole);
            }

            return await query.ToListAsync();
        }


        public async Task<Person> GetAsync(int id)
        {
            return await _context.People.FindAsync(id);
        }
        public async Task<int> AddAsync(Person item)
        {
            _context.People.Add(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> EditAsync(Person item)
        {
            _context.People.Update(item);

            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int id)
        {
            var item = await _context.People.FindAsync(id);
            _context.People.Remove(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAllSimpleAsync()
        {
            var query = _context.People.Select(k =>
           new Person { PersonID = k.PersonID, Name = k.Name });

            return await query.ToListAsync();
        }

        
    }
}
