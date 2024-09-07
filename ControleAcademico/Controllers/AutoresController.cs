using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControleAcademico1.Models;
using ControleAcademico1.Services;

namespace ControleAcademico1.Controllers
{
    public class AutoresController : Controller
    {
        private readonly IAutorService _autorService;

        // Injeção de dependência do serviço de Autor
        public AutoresController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
            var autores = await _autorService.GetAllAutoresAsync();
            return View(autores);
        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _autorService.GetAutorByIdAsync(id.Value);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // GET: Autors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Curso")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                await _autorService.AddAutorAsync(autor);
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _autorService.GetAutorByIdAsync(id.Value);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: Autors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Curso")] Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _autorService.UpdateAutorAsync(autor);
                }
                catch
                {
                    if (!await AutorExists(autor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _autorService.GetAutorByIdAsync(id.Value);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _autorService.DeleteAutorAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AutorExists(int id) => await _autorService.AutorExistsAsync(id);
    }
}
