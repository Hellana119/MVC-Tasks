using Day3.Models;
using Day3.Models.Domain;
using Day3.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Day3.Models.Domain.Ticket;

namespace Day2.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            var tickets = Ticket.GetTickets();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var tickets = Ticket.GetTickets();
            var departments = Department.GetDepartments();
            //ViewBag.Department = departments;
           var departmentsList = departments.Select(mapDepartmentoItem).ToList();
            ViewData[magicStrings.Departments] = departmentsList;

            var developers = Developer.GetDevelopers();
            var developerListItems = developers.Select(d => new SelectListItem($"{d.FirstName}  {d.LastName}", d.Id.ToString()));
            ViewBag.developerListItems = developerListItems;
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(AddTicketVM ticketVM)
        {
            var developers = Developer.GetDevelopers();
            var selectedDevIds = ticketVM.DevelopersIds;
            var selectedDev = developers.Where(d => selectedDevIds.Contains(d.Id)).ToList();

            var tickets = Ticket.GetTickets();
            var addTicket = new Ticket
            {
                CreatedDate = DateTime.Now.AddHours(-1),
                IsClosed= ticketVM.IsClosed,
                Description= ticketVM.Description,
                Severity= ticketVM.Severity,
                department = Department.GetDepartments().First(d => d.Id.ToString() == ticketVM.DepartmentId.ToString()),
                Developers = selectedDev,
            };
            tickets.Add(addTicket);
            //return View("index", tickets);
            return RedirectToAction(nameof(Index));
           
        }
        private SelectListItem mapDepartmentoItem (Department department)
        {
            //var item = new SelectListItem();
            //item.Text = department.Name;
            //item.Value = department.Id.ToString();
            var item = new SelectListItem(department.Name, department.Id.ToString());
            return item;
        }
    }
}
