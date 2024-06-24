using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMoto.Data;
using MvcMoto.Models;

namespace MvcMoto.Controllers
{
    public class MotoesController : Controller
    {
        private readonly MvcMotoContext _context;

        public MotoesController(MvcMotoContext context)
        {
            _context = context;
        }

        // GET: Motoes
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Moto == null)
            {
                return Problem("Entity set 'MvcMotoContext.Moto'  is null.");
            }

            var motoes = from m in _context.Moto
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                motoes = motoes.Where(s => s.Name!.Contains(searchString));
            }

            return View(await motoes.ToListAsync());
        }


        // GET: Motoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Moto == null)
            {
                return NotFound();
            }

            var moto = await _context.Moto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moto == null)
            {
                return NotFound();
            }

            return View(moto);
        }

        // GET: Motoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Circuit,Team,WorldRank,DriverNumber")] Moto moto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moto);
        }

        // GET: Motoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Moto == null)
            {
                return NotFound();
            }

            var moto = await _context.Moto.FindAsync(id);
            if (moto == null)
            {
                return NotFound();
            }
            return View(moto);
        }

        // POST: Motoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Circuit,Team,WorldRank,DriverNumber")] Moto moto)
        {
            if (id != moto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoExists(moto.Id))
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
            return View(moto);
        }

        // GET: Motoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Moto == null)
            {
                return NotFound();
            }

            var moto = await _context.Moto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moto == null)
            {
                return NotFound();
            }

            return View(moto);
        }

        // POST: Motoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Moto == null)
            {
                return Problem("Entity set 'MvcMotoContext.Moto'  is null.");
            }
            var moto = await _context.Moto.FindAsync(id);
            if (moto != null)
            {
                _context.Moto.Remove(moto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoExists(int id)
        {
          return (_context.Moto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
