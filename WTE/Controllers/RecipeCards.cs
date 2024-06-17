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


        /*код для фото пользователя*/
        [HttpPost("uploadRecipe")]
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
            var extension = Path.GetExtension(file.FileName);
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
