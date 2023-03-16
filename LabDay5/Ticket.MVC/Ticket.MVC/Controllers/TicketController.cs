using Microsoft.AspNetCore.Mvc;
using TicketSystem.BL;
using TicketSystem.BL.Managers.Developers;
using TicketSystem.BL.ViewModels;
using TicketSystem.DAL.Migrations;

namespace TicketSystem.MVC.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketsManager _ticketsManager;
        private readonly IDepartmentManager _departmentManager;
        private readonly IDeveloperManager _developerManager;

        public TicketController(ITicketsManager ticketsManager, 
            IDepartmentManager departmentManager,
            IDeveloperManager developerManager)
        {
            _ticketsManager = ticketsManager;
            _departmentManager = departmentManager;
            _developerManager = developerManager;
        }
        public IActionResult Details(int id)
        {
            var ticketVM = _ticketsManager.GetTicketDetails(id);
            if(ticketVM is null) {
                return NotFound(); 
            }
            return View(ticketVM);
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var TicketVM = _ticketsManager.GetForEdit(id);
            ViewBag.Departments = _departmentManager.GetDepartmentListItems();
            ViewBag.Developers = _developerManager.GetDevelopersListItems();

            return View();
        }
        //[HttpPost]
        //public IActionResult Edit(TicketEditVM ticketVM)
        //{
        //    Update(ticketVM);
        //    return RedirectToAction(nameof(Index));

        //    return View();
        //}
    }
}
