using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleAcademico1.Data;
using ControleAcademico1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;

namespace ControleAcademico1.Controllers
{
    public class TrabalhosController : Controller
    {
        private readonly ControleAcademico1Context _context;

        public TrabalhosController(ControleAcademico1Context context)
        {
            _context = context;
        }

        // GET: Trabalhos
        public async Task<IActionResult> Index()
        {
            var trabalhos = _context.Trabalhos
                .Include(t => t.Autor)
                .Include(t => t.Orientador);
            return View(await trabalhos.ToListAsync());
        }

        // GET: Trabalhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trabalhos == null)
            {
                return NotFound();
            }

            var trabalho = await _context.Trabalhos
                .Include(t => t.Autor)
                .Include(t => t.Orientador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabalho == null)
            {
                return NotFound();
            }

            return View(trabalho);
        }

        // GET: Trabalhos/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome");
            ViewData["OrientadorId"] = new SelectList(_context.Orientadores, "Id", "Nome");
            return View();
        }

        // POST: Trabalhos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Tipo,AutorId,OrientadorId")] Trabalho trabalho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabalho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome", trabalho.AutorId);
            ViewData["OrientadorId"] = new SelectList(_context.Orientadores, "Id", "Nome", trabalho.OrientadorId);
            return View(trabalho);
        }

        // GET: Trabalhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trabalhos == null)
            {
                return NotFound();
            }

            var trabalho = await _context.Trabalhos.FindAsync(id);
            if (trabalho == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome", trabalho.AutorId);
            ViewData["OrientadorId"] = new SelectList(_context.Orientadores, "Id", "Nome", trabalho.OrientadorId);
            return View(trabalho);
        }

        // POST: Trabalhos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Tipo,AutorId,OrientadorId")] Trabalho trabalho)
        {
            if (id != trabalho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabalho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabalhoExists(trabalho.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome", trabalho.AutorId);
            ViewData["OrientadorId"] = new SelectList(_context.Orientadores, "Id", "Nome", trabalho.OrientadorId);
            return View(trabalho);
        }

        // GET: Trabalhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trabalhos == null)
            {
                return NotFound();
            }

            var trabalho = await _context.Trabalhos
                .Include(t => t.Autor)
                .Include(t => t.Orientador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabalho == null)
            {
                return NotFound();
            }

            return View(trabalho);
        }

        // POST: Trabalhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trabalhos == null)
            {
                return Problem("Entity set 'ControleAcademico1Context.Trabalhos'  is null.");
            }
            var trabalho = await _context.Trabalhos.FindAsync(id);
            if (trabalho != null)
            {
                _context.Trabalhos.Remove(trabalho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabalhoExists(int id)
        {
            return _context.Trabalhos.Any(e => e.Id == id);
        }
    }
}