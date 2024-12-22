using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Do_An.Models;

namespace Do_An.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ActorController : Controller
    {
        private readonly MovieContext _context;

        public ActorController(MovieContext context)
        {
            _context = context;
        }

        // GET: Admin/Actor
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbActors.ToListAsync());
        }

        // GET: Admin/Actor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbActor = await _context.TbActors
                .FirstOrDefaultAsync(m => m.ActorId == id);
            if (tbActor == null)
            {
                return NotFound();
            }

            return View(tbActor);
        }

        // GET: Admin/Actor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Actor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorId,Name,Alias,DateOfBirth,Nationality,Description,Biography,ProfileImage,IsActive")] TbActor tbActor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbActor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbActor);
        }

        // GET: Admin/Actor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbActor = await _context.TbActors.FindAsync(id);
            if (tbActor == null)
            {
                return NotFound();
            }
            return View(tbActor);
        }

        // POST: Admin/Actor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActorId,Name,Alias,DateOfBirth,Nationality,Description,Biography,ProfileImage,IsActive")] TbActor tbActor)
        {
            if (id != tbActor.ActorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbActor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbActorExists(tbActor.ActorId))
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
            return View(tbActor);
        }

        // GET: Admin/Actor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbActor = await _context.TbActors
                .FirstOrDefaultAsync(m => m.ActorId == id);
            if (tbActor == null)
            {
                return NotFound();
            }

            return View(tbActor);
        }

        // POST: Admin/Actor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbActor = await _context.TbActors.FindAsync(id);
            if (tbActor != null)
            {
                _context.TbActors.Remove(tbActor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbActorExists(int id)
        {
            return _context.TbActors.Any(e => e.ActorId == id);
        }
    }
}
