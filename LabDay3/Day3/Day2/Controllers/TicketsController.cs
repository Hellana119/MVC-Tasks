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
        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            getFormData();
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
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            getFormData();
            var EditTicket = GetTickets().First(a=> a.Id == id);
            var ticketVM = new EditTicketVM {
                Id = EditTicket.Id,
                IsClosed = EditTicket.IsClosed,
                Description = EditTicket.Description,
                Severity = EditTicket.Severity,
                DepartmentId = EditTicket.department.Id,
                DevelopersIds = EditTicket.Developers.Select(a => a.Id).ToList(),

            };
            return View(ticketVM);
        }
        [HttpPost]
        public IActionResult Edit(EditTicketVM ticketVM)
        {
            var developers = Developer.GetDevelopers();
            var selectedDevIds = ticketVM.DevelopersIds;
            var selectedDev = developers.Where(d => selectedDevIds.Contains(d.Id)).ToList();

            var EditTicket = GetTickets().First(a=> a.Id == ticketVM.Id);
            EditTicket.IsClosed = ticketVM.IsClosed;
            EditTicket.Severity = ticketVM.Severity;
            EditTicket.department = Department.GetDepartments().First(d => d.Id.ToString() == ticketVM.DepartmentId.ToString());
            EditTicket.Developers = selectedDev;
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var DeleteTicket = GetTickets().First(a => a.Id == id);
            GetTickets().Remove(DeleteTicket);
            return RedirectToAction(nameof(Index));
        }
        #endregion
        private void getFormData()
        {
            var departments = Department.GetDepartments();
            //ViewBag.Department = departments;
            var departmentsList = departments.Select(mapDepartmentoItem).ToList();
            ViewData[magicStrings.Departments] = departmentsList;

            var developers = Developer.GetDevelopers();
            var developerListItems = developers.Select(d => new SelectListItem($"{d.FirstName}  {d.LastName}", d.Id.ToString()));
            ViewBag.developerListItems = developerListItems;
        }
    }
}
