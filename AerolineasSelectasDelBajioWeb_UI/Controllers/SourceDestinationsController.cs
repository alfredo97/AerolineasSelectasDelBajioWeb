using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AerolineasSelectasDelBajioWeb_Entities;
using AerolineasSelectasDelBajioWeb_UI.Models;

namespace AerolineasSelectasDelBajioWeb_UI.Controllers
{
    public class SourceDestinationsController : Controller
    {
        private readonly AerolineasSelectasDelBajioContext _context;

        public SourceDestinationsController(AerolineasSelectasDelBajioContext context)
        {
            _context = context;
        }

        // GET: SourceDestinations
        public async Task<IActionResult> Index()
        {
            var aerolineasSelectasDelBajioContext = _context.SourceDestiny.Include(s => s.SourceDestinyFromNavigation).Include(s => s.SourceDestinyToNavigation);
            return View(await aerolineasSelectasDelBajioContext.ToListAsync());
        }

        // GET: SourceDestinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sourceDestiny = await _context.SourceDestiny
                .Include(s => s.SourceDestinyFromNavigation)
                .Include(s => s.SourceDestinyToNavigation)
                .FirstOrDefaultAsync(m => m.SourceDestinyId == id);
            if (sourceDestiny == null)
            {
                return NotFound();
            }

            return View(sourceDestiny);
        }

        // GET: SourceDestinations/Create
        public IActionResult Create()
        {
            ViewData["SourceDestinyFrom"] = new SelectList(_context.City, "CityId", "CityName");
            ViewData["SourceDestinyTo"] = new SelectList(_context.City, "CityId", "CityName");
            return View();
        }

        // POST: SourceDestinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SourceDestinyId,SourceDestinyFrom,SourceDestinyTo")] SourceDestiny sourceDestiny)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sourceDestiny);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SourceDestinyFrom"] = new SelectList(_context.City, "CityId", "CityName", sourceDestiny.SourceDestinyFrom);
            ViewData["SourceDestinyTo"] = new SelectList(_context.City, "CityId", "CityName", sourceDestiny.SourceDestinyTo);
            return View(sourceDestiny);
        }

        // GET: SourceDestinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sourceDestiny = await _context.SourceDestiny.FindAsync(id);
            if (sourceDestiny == null)
            {
                return NotFound();
            }
            ViewData["SourceDestinyFrom"] = new SelectList(_context.City, "CityId", "CityName", sourceDestiny.SourceDestinyFrom);
            ViewData["SourceDestinyTo"] = new SelectList(_context.City, "CityId", "CityName", sourceDestiny.SourceDestinyTo);
            return View(sourceDestiny);
        }

        // POST: SourceDestinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SourceDestinyId,SourceDestinyFrom,SourceDestinyTo")] SourceDestiny sourceDestiny)
        {
            if (id != sourceDestiny.SourceDestinyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sourceDestiny);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SourceDestinyExists(sourceDestiny.SourceDestinyId))
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
            ViewData["SourceDestinyFrom"] = new SelectList(_context.City, "CityId", "CityName", sourceDestiny.SourceDestinyFrom);
            ViewData["SourceDestinyTo"] = new SelectList(_context.City, "CityId", "CityName", sourceDestiny.SourceDestinyTo);
            return View(sourceDestiny);
        }

        // GET: SourceDestinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sourceDestiny = await _context.SourceDestiny
                .Include(s => s.SourceDestinyFromNavigation)
                .Include(s => s.SourceDestinyToNavigation)
                .FirstOrDefaultAsync(m => m.SourceDestinyId == id);
            if (sourceDestiny == null)
            {
                return NotFound();
            }

            return View(sourceDestiny);
        }

        // POST: SourceDestinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sourceDestiny = await _context.SourceDestiny.FindAsync(id);
            _context.SourceDestiny.Remove(sourceDestiny);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SourceDestinyExists(int id)
        {
            return _context.SourceDestiny.Any(e => e.SourceDestinyId == id);
        }
    }
}
