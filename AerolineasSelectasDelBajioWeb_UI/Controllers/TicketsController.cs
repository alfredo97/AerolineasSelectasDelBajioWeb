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
    public class TicketsController : Controller
    {
        private readonly AerolineasSelectasDelBajioContext _context;

        public TicketsController(AerolineasSelectasDelBajioContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var aerolineasSelectasDelBajioContext = _context.Ticket.Include(t => t.TicketAirplane).Include(t => t.TicketSale)
                .Include(t => t.TicketSourceDestiny)
                .Include(t => t.TicketSourceDestiny.SourceDestinyFromNavigation)
                .Include(t => t.TicketSourceDestiny.SourceDestinyToNavigation);
            
            return View(await aerolineasSelectasDelBajioContext.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.TicketAirplane)
                .Include(t => t.TicketSale)
                .Include(t => t.TicketSourceDestiny)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {

            
            ViewData["TicketAirplaneId"] = new SelectList(_context.Airplane, "AirplaneId", "AirplaneName");
            ViewData["TicketSaleId"] = new SelectList(_context.Sale, "SaleId", "SaleAspnetusersId");
            ViewData["TicketSourceDestinyId"] = new SelectList(_context.SourceDestiny.Include(m => m.SourceDestinyFromNavigation).Include(m => m.SourceDestinyToNavigation), "SourceDestinyId", "custom");

           
   

            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,TicketNPlace,TicketPrice,TicketDepartureTime,TicketAirplaneId,TicketSourceDestinyId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.TicketSaleId = 1;
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketAirplaneId"] = new SelectList(_context.Airplane, "AirplaneId", "AirplaneName", ticket.TicketAirplaneId);
            ViewData["TicketSaleId"] = new SelectList(_context.Sale, "SaleId", "SaleAspnetusersId", ticket.TicketSaleId);
            ViewData["TicketSourceDestinyId"] = new SelectList(_context.SourceDestiny, "SourceDestinyId", "SourceDestinyId", ticket.TicketSourceDestinyId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["TicketAirplaneId"] = new SelectList(_context.Airplane, "AirplaneId", "AirplaneName", ticket.TicketAirplaneId);
            ViewData["TicketSaleId"] = new SelectList(_context.Sale, "SaleId", "SaleAspnetusersId", ticket.TicketSaleId);
            ViewData["TicketSourceDestinyId"] = new SelectList(_context.SourceDestiny, "SourceDestinyId", "SourceDestinyId", ticket.TicketSourceDestinyId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,TicketNPlace,TicketPrice,TicketDepartureTime,TicketAirplaneId,TicketSourceDestinyId,TicketSaleId")] Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketId))
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
            ViewData["TicketAirplaneId"] = new SelectList(_context.Airplane, "AirplaneId", "AirplaneName", ticket.TicketAirplaneId);
            ViewData["TicketSaleId"] = new SelectList(_context.Sale, "SaleId", "SaleAspnetusersId", ticket.TicketSaleId);
            ViewData["TicketSourceDestinyId"] = new SelectList(_context.SourceDestiny, "SourceDestinyId", "SourceDestinyId", ticket.TicketSourceDestinyId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.TicketAirplane)
                .Include(t => t.TicketSale)
                .Include(t => t.TicketSourceDestiny)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.TicketId == id);
        }
    }
}
