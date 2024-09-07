using System.Collections.Generic;
using System.Threading.Tasks;
using ControleAcademico1.Models;

namespace ControleAcademico1.Services
{
    public interface IAutorService
    {
        Task<IEnumerable<Autor>> GetAllAutoresAsync();
        Task<Autor> GetAutorByIdAsync(int id);
        Task AddAutorAsync(Autor autor);
        Task UpdateAutorAsync(Autor autor);
        Task DeleteAutorAsync(int id);
        Task<bool> AutorExistsAsync(int id);
    }
}