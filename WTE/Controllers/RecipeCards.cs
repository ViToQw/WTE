using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WTE.Controllers
{
    public class RecipeCards : Controller
    {
        // GET: RecipeCards
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult GoToProfile()
        {
            // Перенаправление на действие Profile контроллера Account
            return RedirectToAction("Profile", "Account");
        }

    }
}
