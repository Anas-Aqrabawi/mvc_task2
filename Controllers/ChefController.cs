using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_task2.Models;

namespace mvc_task2.Controllers
{
    public class ChefController : Controller
    {
        private readonly ModelContext _context;

        public ChefController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var chefid = HttpContext.Session.GetInt32("ChefId");
            var Chef = _context.Users.Where(X => X.UserId == chefid).SingleOrDefault();

            return View(Chef);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "LoginAndRegister");
        }
    }
}
