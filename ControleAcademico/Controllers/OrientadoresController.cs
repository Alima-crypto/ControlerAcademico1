using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleAcademico1.Data;
using ControleAcademico1.Models;
using System.Threading.Tasks;
using System.Linq;

namespace ControleAcademico1.Controllers
{
    public class OrientadoresController : Controller
    {
        private readonly ControleAcademico1Context _context;

        public OrientadoresController(ControleAcademico1Context context)
        {
            _context = context;
        }

        // GET: Orientadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orientadores.ToListAsync());
        }

        // GET: Orientadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orientadores == null)
            {
                return NotFound();
            }

            var orientadores = await _context.Orientadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orientadores == null)
            {
                return NotFound();
            }

            return View(orientadores);
        }

        // GET: Orientador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orientador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Curso")] Orientadores orientador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orientador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orientador);
        }

        // GET: Orientador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orientadores == null)
            {
                return NotFound();
            }

            var orientadores = await _context.Orientadores.FindAsync(id);
            if (orientadores == null)
            {
                return NotFound();
            }
            return View(orientadores);
        }

        // POST: Orientador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Curso")] Orientadores orientador)
        {
            if (id != orientador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orientador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrientadorExists(orientador.Id))
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
            return View(orientador);
        }

        // GET: Orientador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orientadores == null)
            {
                return NotFound();
            }

            var orientador = await _context.Orientadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orientador == null)
            {
                return NotFound();
            }

            return View(orientador);
        }

        // POST: Orientador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orientadores == null)
            {
                return Problem("Entity set 'ControleAcademico1Context.Orientador'  is null.");
            }
            var orientador = await _context.Orientadores.FindAsync(id);
            if (orientador != null)
            {
                _context.Orientadores.Remove(orientador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrientadorExists(int id)
        {
            return _context.Orientadores.Any(e => e.Id == id);
        }
    }
}
