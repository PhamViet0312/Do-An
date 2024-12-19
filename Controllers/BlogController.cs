using Do_An.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Controllers
{
    public class BlogController : Controller
    {
        private readonly MovieContext _context;

        public BlogController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/blog/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbBlogs == null)
            {
                return NotFound();
            }

            var blogs = await _context.TbBlogs.FirstOrDefaultAsync(m => m.BlogId == id);

            if (blogs == null)
            {
                return NotFound();
            }

            ViewBag.blogComment = _context.TbBlogComments.Where(m => m.BlogId == id && m.IsActive == true).ToList();

            return View(blogs);
        }
    }
}
