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
    public class MovieController : Controller
    {
        private readonly MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        // GET: Admin/Movie
        public async Task<IActionResult> Index()
        {
            var movieContext = _context.TbMovies.Include(t => t.CategoryMovie);
            return View(await movieContext.ToListAsync());
        }

        // GET: Admin/Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMovie = await _context.TbMovies
                .Include(t => t.CategoryMovie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (tbMovie == null)
            {
                return NotFound();
            }

            return View(tbMovie);
        }

        // GET: Admin/Movie/Create
        public IActionResult Create()
        {
            ViewData["CategoryMovieId"] = new SelectList(_context.TbCategoryMovies, "CategoryMovieId", "CategoryMovieId");
            return View();
        }

        // POST: Admin/Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,CategoryMovieId,Title,Alias,Image,Since,Description,ReleaseDate,Duration,Rating,Language,Poster,TrailerUrl,IsActive")] TbMovie tbMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryMovieId"] = new SelectList(_context.TbCategoryMovies, "CategoryMovieId", "CategoryMovieId", tbMovie.CategoryMovieId);
            return View(tbMovie);
        }

        // GET: Admin/Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMovie = await _context.TbMovies.FindAsync(id);
            if (tbMovie == null)
            {
                return NotFound();
            }
            ViewData["CategoryMovieId"] = new SelectList(_context.TbCategoryMovies, "CategoryMovieId", "CategoryMovieId", tbMovie.CategoryMovieId);
            return View(tbMovie);
        }

        // POST: Admin/Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,CategoryMovieId,Title,Alias,Image,Since,Description,ReleaseDate,Duration,Rating,Language,Poster,TrailerUrl,IsActive")] TbMovie tbMovie)
        {
            if (id != tbMovie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbMovieExists(tbMovie.MovieId))
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
            ViewData["CategoryMovieId"] = new SelectList(_context.TbCategoryMovies, "CategoryMovieId", "CategoryMovieId", tbMovie.CategoryMovieId);
            return View(tbMovie);
        }

        // GET: Admin/Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMovie = await _context.TbMovies
                .Include(t => t.CategoryMovie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (tbMovie == null)
            {
                return NotFound();
            }

            return View(tbMovie);
        }

        // POST: Admin/Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbMovie = await _context.TbMovies.FindAsync(id);
            if (tbMovie != null)
            {
                _context.TbMovies.Remove(tbMovie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbMovieExists(int id)
        {
            return _context.TbMovies.Any(e => e.MovieId == id);
        }
    }
}
