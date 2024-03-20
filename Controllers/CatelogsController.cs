using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpManagement.Data;
using Library.Models;

namespace Library.Controllers
{
    public class CatelogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatelogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Catelogs
        public async Task<IActionResult> Index()
        {
              return _context.Catalogs != null ? 
                          View(await _context.Catalogs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Catalogs'  is null.");
        }

        // GET: Catelogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Catalogs == null)
            {
                return NotFound();
            }

            var catelog = await _context.Catalogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catelog == null)
            {
                return NotFound();
            }

            return View(catelog);
        }

        // GET: Catelogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catelogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CatalogCode,CatalogName,ISBN,AuthorName,Publisher,PublicYear,PublicEdition")] Catelog catelog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catelog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catelog);
        }

        // GET: Catelogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Catalogs == null)
            {
                return NotFound();
            }

            var catelog = await _context.Catalogs.FindAsync(id);
            if (catelog == null)
            {
                return NotFound();
            }
            return View(catelog);
        }

        // POST: Catelogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CatalogCode,CatalogName,ISBN,AuthorName,Publisher,PublicYear,PublicEdition")] Catelog catelog)
        {
            if (id != catelog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catelog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatelogExists(catelog.Id))
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
            return View(catelog);
        }

        // GET: Catelogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Catalogs == null)
            {
                return NotFound();
            }

            var catelog = await _context.Catalogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catelog == null)
            {
                return NotFound();
            }

            return View(catelog);
        }

        // POST: Catelogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Catalogs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Catalogs'  is null.");
            }
            var catelog = await _context.Catalogs.FindAsync(id);
            if (catelog != null)
            {
                _context.Catalogs.Remove(catelog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatelogExists(int id)
        {
          return (_context.Catalogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
