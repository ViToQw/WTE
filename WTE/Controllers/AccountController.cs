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

        [Route("account/profile")]
        public IActionResult Profile()
        {
            return View();
        }
        

    }
    


    }
