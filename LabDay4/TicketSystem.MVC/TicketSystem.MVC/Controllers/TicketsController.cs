using Microsoft.AspNetCore.Mvc;
using TicketSystem.BL;
using TicketSystem.BL.ViewModels;

namespace TicketSystem.MVC.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsManager _ticketsManager;

        public TicketsController(ITicketsManager ticketsManager)
        {
            _ticketsManager = ticketsManager;
        }
        public IActionResult Index()
        {
            return View(_ticketsManager.GetAll());
        }
        public IActionResult Details(int id)
        {
            var ticket = _ticketsManager.Get(id);
            if(ticket is null) {
                View("NotFound");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddVM ticket)
        {
            _ticketsManager.Add(ticket);
            return RedirectToAction(nameof(Index));
        }
    }
}
