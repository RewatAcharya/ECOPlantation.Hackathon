using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECOPlantation.Data;
using ECOPlantation.Models;
using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace ECOPlantation.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUsersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: ApplicationUsers/Register
        public IActionResult Register()
        {
            return PartialView();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "ApplicationUsers");
            }
            return PartialView(applicationUser);
        }

        // GET: ApplicationUsers/Login
        public IActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _context.ApplicationUsers.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (user == null)
            {
                return PartialView();
            }

            var claims = new List<Claim>
                               {
                                   new(ClaimTypes.Name, user.Id.ToString()),
                                   new("UserName", user.FullName),
                               };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");

        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
