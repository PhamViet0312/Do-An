using Do_An.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Controllers
{
    public class ActorController : Controller
    {
        private readonly MovieContext _context;

        public ActorController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/actor/{alias}-{id}.html")]
        public async Task <IActionResult> Details(int? id)
        {
            if (id == null || _context.TbActors == null)
            {
                return NotFound();
            }
            var actors = await _context.TbActors.FirstOrDefaultAsync(m => m.ActorId == id);

            if (actors == null)
            {
                return NotFound();
            }
            return View(actors);
        }
    }
}
