using Do_An.Models;
using Microsoft.AspNetCore.Mvc;

namespace Do_An.ViewComponents
{
    public class MovieViewComponent : ViewComponent
    {
        private readonly MovieContext _context;

        public MovieViewComponent(MovieContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMovies
                .Where(m => m.IsActive == true).ToList();

            return await Task.FromResult(View(items));
        }
    }
}
