using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;

namespace TicketSystem.DAL.Repos.TicketsRepo
{
    public class TicketsRepo : ITicketsRepo
    {
        private readonly TicketContext _context;

        public TicketsRepo(TicketContext context)
        {
            _context = context;
        }

        public Ticket? GetTicketWithDeveloperAndDepartment(int id)
        {
            return _context.Set<Ticket>()
                .Include(t=>t.Department)
                .Include(t => t.Developers)
                .FirstOrDefault(t=>t.Id == id);

        }

        public Ticket? GetTicketWithDevelopers(int id)
        {
            return _context.Set<Ticket>()
            .Include(t => t.Developers)
            .FirstOrDefault(t => t.Id == id);

        }
    }
}
