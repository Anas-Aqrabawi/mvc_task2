using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_task2.Models;

namespace mvc_task2.Controllers
{
    public class LoginAndRegisterController : Controller
    {
        private readonly ModelContext _context;
        public LoginAndRegisterController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user, string username, string password)
        {
            var userInfo = await _context.UserLogins.
                Where(X => X.UserName == username && X.Password == password)
                .SingleOrDefaultAsync();

            if (userInfo == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    _context.SaveChanges();

                    UserLogin userLogin = new UserLogin();
                    userLogin.UserName = username;
                    userLogin.Password = password;
                    userLogin.UserId = user.UserId;
                    userLogin.RoleId = 3;

                    _context.Add(userLogin);
                    _context.SaveChanges();
                }
            }

            ModelState.AddModelError("", "Username already exists");
            ModelState.AddModelError("", "Password already exists");

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            var userLoginInfo = await _context.UserLogins.
                Where(X => X.UserName == userLogin.UserName && X.Password == userLogin.Password)
                .SingleOrDefaultAsync();

            if (userLoginInfo != null)
            {
                switch(userLoginInfo.RoleId)
                {
                    case 1:
                        HttpContext.Session.SetInt32("AdminId", (int)userLoginInfo.RoleId);
                        return RedirectToAction("Index", "Admin");

                    case 2:
                        HttpContext.Session.SetInt32("ChefId", (int)userLoginInfo.RoleId);
                        return RedirectToAction("Index", "Chef");

                    case 3:
                        HttpContext.Session.SetInt32("UserId", (int)userLoginInfo.RoleId);
                        return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Username or Password are incorrect.");
            return View();
        }
    }
}
