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

        [HttpGet]
        [Route("account/LogOut")]
        public IActionResult LogOut()
        {
            _config["IsAutorization"] = "false";
            return Ok();

        }

        /*код для фото пользователя*/
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file provided");
            }

            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            // Получаем расширение файла
            var extension = Path.GetExtension(file.FileName);
            // Создаем новое имя файла с временной меткой
            var newFileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{timestamp}{extension}";


            var filePath = Path.Combine(uploads, newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileUrl = $"/uploads/{file.FileName}"; // URL для сохраненного файла
            return Ok(new { url = fileUrl });
        }

     

    }
    }
