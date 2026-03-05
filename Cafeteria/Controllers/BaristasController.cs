using Cafeteria.Data;
using Cafeteria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria.Controllers
{
    public class BaristasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaristasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Baristas
        public async Task<IActionResult> Index()
        {
            var lista = await _context.Baristas
                .OrderBy(b => b.Nome)
                .ToListAsync();

            return View(lista);
        }

        

        // GET: /Baristas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Baristas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Barista barista)
        {
            if (!ModelState.IsValid)
                return View(barista);

            _context.Baristas.Add(barista);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Baristas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var barista = await _context.Baristas.FindAsync(id);
            if (barista == null) return NotFound();

            return View(barista);
        }

        // POST: /Baristas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Barista barista)
        {
            if (id != barista.Id) return NotFound();

            if (!ModelState.IsValid)
                return View(barista);

            _context.Update(barista);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Baristas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // (se quiser proteger delete só logado, você coloca aqui depois)

            if (id == null) return NotFound();

            var barista = await _context.Baristas
                .FirstOrDefaultAsync(b => b.Id == id);

            if (barista == null) return NotFound();

            return View(barista);
        }

        // POST: /Baristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // (se quiser proteger delete só logado, você coloca aqui depois)

            var barista = await _context.Baristas.FindAsync(id);
            if (barista != null)
            {
                _context.Baristas.Remove(barista);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}