using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Do_An.Models;

namespace Do_An.Areas.Admin.Components
{
    [ViewComponent(Name = "AdminMenu")]
    public class AdminMenuComponent : ViewComponent
    {
        private readonly MovieContext _context;

        public AdminMenuComponent(MovieContext db)
        {
            _context = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var mnlist = _context.TblAdminMenus.Where(mn => mn.IsActive ?? true).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", mnlist));
        }
    }
}
