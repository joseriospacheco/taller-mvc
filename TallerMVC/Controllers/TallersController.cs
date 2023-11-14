using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerMVC.Data;
using TallerMVC.Models;

namespace TallerMVC.Controllers
{
    public class TallersController : Controller
    {
        private readonly TallerMVCContext _context;

        public TallersController(TallerMVCContext context)
        {
            _context = context;
        }

        // GET: Tallers
        public async Task<IActionResult> Index()
        {
            return _context.Taller != null ?
                        View(await _context.Taller.ToListAsync()) :
                        Problem("Entity set 'TallerMVCContext.Taller'  is null.");
        }

        // GET: Tallers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Taller == null)
            {
                return NotFound();
            }

            var taller = await _context.Taller
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taller == null)
            {
                return NotFound();
            }

            return View(taller);
        }

        // GET: Tallers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tallers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,Fecha")] Taller taller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taller);
        }

        // GET: Tallers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Taller == null)
            {
                return NotFound();
            }

            var taller = await _context.Taller.FindAsync(id);
            if (taller == null)
            {
                return NotFound();
            }
            return View(taller);
        }

        // POST: Tallers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,Fecha")] Taller taller)
        {
            if (id != taller.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TallerExists(taller.Id))
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
            return View(taller);
        }

        // GET: Tallers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Taller == null)
            {
                return NotFound();
            }

            var taller = await _context.Taller
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taller == null)
            {
                return NotFound();
            }

            return View(taller);
        }

        // POST: Tallers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Taller == null)
            {
                return Problem("Entity set 'TallerMVCContext.Taller'  is null.");
            }
            var taller = await _context.Taller.FindAsync(id);
            if (taller != null)
            {
                _context.Taller.Remove(taller);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TallerExists(int id)
        {
            return (_context.Taller?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
