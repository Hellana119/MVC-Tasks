using LabDay1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabDay1.Controllers
{
    

        public class CarController : Controller
    {
        public IActionResult GetAll()
        {
            var cars = Car.GetCars();
            return View(cars);
        }

        public IActionResult GetDetails(string carModel, Status? status) {
            var car = Car.GetCars().FirstOrDefault(c => c.Model == carModel);
            getData data = new getData();
            data.car = car;
            data.status = status;
            return View(data);
        }
    }
}
