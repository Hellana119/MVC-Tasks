﻿using Day2.Models.Domain;
using Day2.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            var tickets = Ticket._getticket;
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var tickets = Ticket._getticket;
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(AddTicketVM ticketVM)
        {
            var tickets = Ticket._getticket;
            var addTicket = new Ticket
            {
                CreatedDate = DateTime.Now.AddHours(-1),
                IsClosed= ticketVM.IsClosed,
                Description= ticketVM.Description,
                Severity= ticketVM.Severity,
            };
            tickets.Add(addTicket);
            //return View("index", tickets);
            return RedirectToAction(nameof(Index));
           
        }
    }
}
