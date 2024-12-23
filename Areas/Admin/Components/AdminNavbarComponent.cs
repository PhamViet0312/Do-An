using Microsoft.AspNetCore.Mvc;
using Do_An.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Do_An.Areas.Admin.Components
{
    [ViewComponent(Name = "AdminNavbar")]
    public class AdminNavbarComponent : ViewComponent
    {
        private readonly MovieContext _context;

        public AdminNavbarComponent(MovieContext db)
        {
            _context = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var username = User.Identity?.Name;
            var adminnavbar = await _context.TbAccounts.Where(mn => mn.IsActive == true).FirstOrDefaultAsync(a => a.Email == username);
            return await Task.FromResult((IViewComponentResult)View("Default", adminnavbar));
        }

    }
}
