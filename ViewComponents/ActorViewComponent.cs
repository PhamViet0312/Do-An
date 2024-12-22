using Do_An.Models;
using Microsoft.AspNetCore.Mvc;

namespace Do_An.ViewComponents
{
    public class ActorViewComponent : ViewComponent
    {
        private readonly MovieContext _context;

        public ActorViewComponent(MovieContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string viewName = "Default")
        {
            var items = _context.TbActors
                .Where(m => m.IsActive == true).ToList();
            return await Task.FromResult(View(viewName, items));
        }
    }
}
