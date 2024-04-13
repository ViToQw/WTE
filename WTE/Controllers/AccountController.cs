using Microsoft.AspNetCore.Mvc;
using System;
using WTE.Models;

namespace WTE.Controllers
{
    public class AccountController : Controller
    {
        private IConfiguration _config;
        public AccountController(IConfiguration config)
        {
            _config=config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("account/profile")]
        public IActionResult Profile()
        {
            ViewBag.id= _config["Id_User"];
            return View();
        }


        [HttpGet]
        public IActionResult SetIdUser(int user_id)
        {
            _config["Id_User"] = user_id.ToString();
            return Ok();
        }
        
    }
    

    }
