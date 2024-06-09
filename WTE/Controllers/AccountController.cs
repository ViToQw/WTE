using Microsoft.AspNetCore.Http;
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

        public IActionResult Registration()
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
        [Route("account/SetUser")]
        public IActionResult SetIdUser(int user_id)
        {
            _config["Id_User"] = user_id.ToString();
            return Ok();

        }
        
    }
    

    }
