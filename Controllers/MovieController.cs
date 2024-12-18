using Do_An.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Route("/movie/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.TbMovies == null)
            {
                return NotFound();
            }

            var movie = await _context.TbMovies.Include(m => m.CategoryMovie).FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.movieReview = _context.TbMovieReviews.Where(m => m.MovieId == id && m.IsActive == true).ToList();

            return View(movie);
        }
    }
}
