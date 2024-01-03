using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarlightProperties.Data;
using StarlightProperties.Models;

namespace StarlightProperties.Controllers
{
    public class HousesController : Controller
    {
        private readonly HomeDbContext _context;

        public HousesController(HomeDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]

        public async Task<IActionResult> Index(string OwnerSearch)
        {
            ViewData["GetOwnerName"] = OwnerSearch;

            var ownerquery = from x in _context.House select x;
            if (!String.IsNullOrEmpty(OwnerSearch))
            {
                ownerquery = ownerquery.Where(x => x.OwnerName.Contains(OwnerSearch) || x.PropertyName.Contains(OwnerSearch));
            }
            return View(await ownerquery.AsNoTracking().ToListAsync());
        }

        [Authorize]
        // GET: Houses
        public async Task<IActionResult> Index()
        {
            return View(await _context.House.ToListAsync());
        }

        // GET: Houses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.House
                .FirstOrDefaultAsync(m => m.Id == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // GET: Houses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PropertyName,OwnerName,OwnerContact,PropertyValue,PropertySize,NumberRoom,Location")] House house)
        {
            if (ModelState.IsValid)
            {
                _context.Add(house);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(house);
        }

        // GET: Houses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.House.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PropertyName,OwnerName,OwnerContact,PropertyValue,PropertySize,NumberRoom,Location")] House house)
        {
            if (id != house.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(house);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseExists(house.Id))
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
            return View(house);
        }

        // GET: Houses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.House
                .FirstOrDefaultAsync(m => m.Id == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var house = await _context.House.FindAsync(id);
            if (house != null)
            {
                _context.House.Remove(house);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseExists(int id)
        {
            return _context.House.Any(e => e.Id == id);
        }
    }
}
