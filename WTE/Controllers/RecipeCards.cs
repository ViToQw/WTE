using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WTE.Controllers
{
    public class RecipeCards : Controller
    {
        private readonly IConfiguration _config;
        public RecipeCards(IConfiguration config)
        {
            _config=config;
        }

        public ActionResult Index()
        {
            ViewBag.id= _config["Id_User"];
            return View();
        }

        public IActionResult GoToProfile()
        {
            return RedirectToAction("Profile", "Account");
        }

       

    }
}
