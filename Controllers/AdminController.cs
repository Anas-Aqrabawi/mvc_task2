using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_task2.Models;

namespace mvc_task2.Controllers
{
   
    public class AdminController : Controller
    {
        private readonly ModelContext _context;

        public AdminController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var id = HttpContext.Session.GetInt32("AdminId");
            var admin = _context.Users.Where(X => X.UserId == id).SingleOrDefault();

            return View(admin);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "LoginAndRegister");
        }
    }
}
