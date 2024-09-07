using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico1.Data;
using ControleAcademico1.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAcademico1.Services
{
    public class AutorService : IAutorService
    {
        private readonly ControleAcademico1Context _context;

        public AutorService(ControleAcademico1Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Autor>> GetAllAutoresAsync()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<Autor> GetAutorByIdAsync(int id)
        {
            return await _context.Autores.FindAsync(id);
        }

        public async Task AddAutorAsync(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAutorAsync(Autor autor)
        {
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAutorAsync(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> AutorExistsAsync(int id)
        {
            return await _context.Autores.AnyAsync(e => e.Id == id);
        }
    }
}
