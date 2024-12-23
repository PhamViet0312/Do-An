using Do_An.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Do_An.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Do_An.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/dang-nhap")]
    public class LoginController : Controller
    {

        private readonly MovieContext _context;
        private readonly Login _loginadmin;

        public LoginController(MovieContext context)
        {
            _context = context;
            _loginadmin = new Login(context);
        }

        [HttpGet]
        public IActionResult Index(string? Returnurl = null)
        {
            ViewBag.Returnurl = Returnurl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(TbAccount model, string? Returnurl = null)
        {
            ViewBag.Returnurl = Returnurl;


            if (ModelState.IsValid)
            {
                var user = await _context.TbAccounts.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefaultAsync();


                if (user != null && !string.IsNullOrEmpty(user.Email))
                {
                    var claims = new List<Claim>
                    {

                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(MySetting.CLAIM_CUSTOMERID, user.Email),

                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (Url.IsLocalUrl(Returnurl))
                    {
                        return Redirect(Returnurl);
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }



                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác!");
                    return View(model);
                }
            }
            ViewBag.ReturnUrl = Returnurl;
            return View();
        }

        [Authorize(AuthenticationSchemes = "AdminAuth")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
