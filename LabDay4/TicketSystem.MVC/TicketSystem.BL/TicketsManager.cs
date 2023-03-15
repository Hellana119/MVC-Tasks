using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.ViewModels;
using TicketSystem.DAL;

namespace TicketSystem.BL
{
    public class TicketsManager : ITicketsManager
    {
        private readonly ITicketsRepo _ticketsRepo;

        public TicketsManager(ITicketsRepo ticketsRepo)
        {
            _ticketsRepo = ticketsRepo;
        }

        public List<ReadVM> GetAll()
        {
            var ticketFromDB =_ticketsRepo.GetAll();
            return ticketFromDB.Select(t=> new ReadVM(t.Id, t.Title, t.Description, t.Severity)).ToList();
        }
        public ReadVM? Get(int id)
        {
            var ticketFromDB = _ticketsRepo.Get(id);
            if(ticketFromDB == null)
            {
                return null;
            }
            return new ReadVM(ticketFromDB.Id, ticketFromDB.Title, ticketFromDB.Description, ticketFromDB.Severity);

        }

        public void Add(ReadVM ticketVM)
        {
            var ticket = new Ticket
            {
                Title = ticketVM.Title,
                Description = ticketVM.Description,
                Severity = ticketVM.Severity
            };

            _ticketsRepo.Add(ticket);
            _ticketsRepo.SaveChanges();
        }

        public void Add(AddVM ticket)
        {
            throw new NotImplementedException();
        }
    }
}
