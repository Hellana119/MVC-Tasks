using Day6.Models.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace Day6.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult AddImg()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImg(AddImgVM imgVM)
        {
            if (imgVM.Image is null)
            {
                ModelState.AddModelError("", "Image is Not Found");
                return View();
            }
            if (imgVM.Image.Length > 1000_000)
            {
                ModelState.AddModelError("", "Image Size Exceeded the limit");
                return View();
            }
            var allowedExtentions = new string[] { ".png" , ".svg"};
            var sentExtention = Path.GetExtension(imgVM.Image.FileName).ToLower();
            if(!allowedExtentions.Contains(sentExtention))
            {
                ModelState.AddModelError("", "Image Extention isn't valid");
                return View();
            }
            string newName = $"{Guid.NewGuid()}{sentExtention}";
            var fullPath = @$"E:\9-months scholarship iti\.Net\4.MVC\Tasks\LabDay6\Day6\Day6\wwwroot\Images\{newName}";
            using (var stream = System.IO.File.Create(fullPath))
            {
                imgVM.Image.CopyTo(stream);
                stream.Dispose();
            }

            //return View();
            return RedirectToAction(nameof(Create));
        }
    }
}
