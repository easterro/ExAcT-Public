using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExtracurricularActivitiyLog.Data;
using ExtracurricularActivitiyLog.Models;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace ExtracurricularActivitiyLog.Controllers
{
    [Authorize(Roles = "Staff_Users_ESG,Faculty_Users_ESG")]
    public class RostersController : Controller
    {
        private readonly SchoolContext _context;

        public RostersController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Rosters

        
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Rosters.Include(r => r.Clubs).Include(r => r.Students);
            return View(await schoolContext.ToListAsync());
        }


        // GET: Rosters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roster = await _context.Rosters
                .Include(r => r.Clubs)
                .Include(r => r.Students)
                .FirstOrDefaultAsync(m => m.RosterID == id);
            if (roster == null)
            {
                return NotFound();
            }

            return View(roster);
        }

        // GET: Rosters/Create


        public IActionResult Create()
        {
            
            ViewData["ClubID"] = new SelectList(_context.Clubs.Select(x => new { x.ClubID, FullClub = x.ClubID + " - " + x.ClubName }).ToArray(), "ClubID", "FullClub");
            ViewData["StudentID"] = new SelectList(_context.Students.Select(x => new { x.ID, FullName = x.StudentID + " - " + x.FirstName + " " + x.LastName }).ToArray(), "ID", "FullName");
            return View();
        }

        

        // POST: Rosters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RosterID,ClubID,StudentID,Positions")] Roster roster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roster);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Clubs", new { id = roster.ClubID });
            }
            ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "ClubID", roster.ClubID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID", roster.StudentID);
            return View(roster);
        }

        // GET: Rosters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roster = await _context.Rosters.FindAsync(id);
            if (roster == null)
            {
                return NotFound();
            }
            ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "ClubID", roster.ClubID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID", roster.StudentID);
            return View(roster);
        }

        // POST: Rosters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RosterID,ClubID,StudentID,Positions")] Roster roster)
        {
            if (id != roster.RosterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RosterExists(roster.RosterID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Clubs", new { id = roster.ClubID });
            }
            ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "ClubID", roster.ClubID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID", roster.StudentID);
            return View(roster);
        }

        // GET: Rosters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roster = await _context.Rosters
                .Include(r => r.Clubs)
                .Include(r => r.Students)
                .FirstOrDefaultAsync(m => m.RosterID == id);
            if (roster == null)
            {
                return NotFound();
            }

            return View(roster);
        }

        // POST: Rosters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roster = await _context.Rosters.FindAsync(id);
            _context.Rosters.Remove(roster);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Clubs", new { id = roster.ClubID });
        }


        private bool RosterExists(int id)
        {
            return _context.Rosters.Any(e => e.RosterID == id);
        }
    }
}
