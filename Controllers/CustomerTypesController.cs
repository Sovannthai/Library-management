using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpManagement.Data;
using Library.Models;
using X.PagedList;

namespace Library.Controllers
{
    public class CustomerTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerTypes
        public async Task<IActionResult> Index(int? page)
        {
            var customerTypes = _context.CustomerType.AsQueryable(); // Use AsQueryable() instead of ToListAsync()
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var pagedCustomerTypes = await customerTypes.ToPagedListAsync(pageNumber, pageSize); // Use ToPagedListAsync()
            return View(pagedCustomerTypes);
        }       
        // GET: CustomerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CustomerType customerType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerType);
        }

        // GET: CustomerTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomerType == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerType.FindAsync(id);
            if (customerType == null)
            {
                return NotFound();
            }
            return View(customerType);
        }

        // POST: CustomerTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CustomerType customerType)
        {
            if (id != customerType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerTypeExists(customerType.Id))
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
            return View(customerType);
        }

        // POST: CustomerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.CustomerType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CustomerType'  is null.");
            }
            var customerType = await _context.CustomerType.FindAsync(id);
            if (customerType != null)
            {
                _context.CustomerType.Remove(customerType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerTypeExists(int id)
        {
          return (_context.CustomerType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
