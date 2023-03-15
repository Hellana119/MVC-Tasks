using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAL;

public class TicketRepo : ITicketsRepo
{
    private readonly TicketContext _context;

    public TicketRepo(TicketContext context)
	{
        _context = context;
    }

    public IEnumerable<Ticket> GetAll()
    {
        return _context.Set<Ticket>().AsNoTracking();
    }
    public Ticket? Get(int id)
    {
        return _context.Set<Ticket>().Find(id);
    }

    public void Add(Ticket ticket)
    {
        _context.Set<Ticket>().Add(ticket);
    }
    public void Update(Ticket ticket)
    {
        var EditTicket = _context.Set<Ticket>().AsNoTracking().First();
    }
    public void Delete(int id)
    {
        var DeletedTicket = Get(id);
        if (DeletedTicket != null)
        {
            _context.Set<Ticket>().Remove(DeletedTicket);
        }
    }



    public int SaveChanges()
    {
        return _context.SaveChanges();
    }





}
