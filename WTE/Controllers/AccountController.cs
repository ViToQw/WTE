using Microsoft.AspNetCore.Mvc;
using WTE.Models;

namespace WTE.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
/*
        [HttpPost]
        public IActionResult Check()
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View("Index");
        }*/

    }


}
