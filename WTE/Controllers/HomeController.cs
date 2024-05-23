using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WTE.Models;

namespace WTE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config=config;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /*private readonly IConfiguration _config;
        public HomeController(IConfiguration config)
        {
            _config = config;
        }
        [Route("home/index")]
        public IActionResult Index()
        {
            ViewBag.id= _config["Id_User"];
            return View();
        }
        [HttpGet]
        [Route("home/SetUser")]
        public IActionResult SetIdUser(int user_id)
        {
            _config["Id_User"] = user_id.ToString();
            return Ok();

        }*/




    }
}