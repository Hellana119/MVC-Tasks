using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.ViewModels;
using TicketSystem.DAL;
using TicketSystem.DAL.Models;
using TicketSystem.DAL.Repos.TicketsRepo;

namespace TicketSystem.BL;

public class TicketsManager : ITicketsManager
{
    private readonly ITicketsRepo _ticketsRepo;

    public TicketsManager(ITicketsRepo ticketsRepo)
    {
        _ticketsRepo = ticketsRepo;
    }

    public TicketEditVM GetForEdit(int id)
    {
        Ticket? TicketFromDB = _ticketsRepo.GetTicketWithDevelopers(id);
        if (TicketFromDB is null)
        {
            return null;
        }
        return new TicketEditVM(
                Id: TicketFromDB.Id,
            Title: TicketFromDB.Title,
            DepartmentId: TicketFromDB.DepartmentId,
            DevelopersIds: TicketFromDB.Developers.Select(d => d.Id).ToArray()
            ) ;
    }

    public TicketDetailsVM? GetTicketDetails(int id)
    {
        Ticket? TicketFromDB = _ticketsRepo.GetTicketWithDeveloperAndDepartment(id);
        if(TicketFromDB is null)
        {
            return null;
        }
        return new TicketDetailsVM(
            Id: TicketFromDB.Id,
            Title: TicketFromDB.Title,
            Description: TicketFromDB.Description,
            Severity: TicketFromDB.severity,
            DepartmentName: TicketFromDB.Department?.Name ?? "",
            DevelorerCount: TicketFromDB.Developers.Count
            ) ;
    }

    public void Update(TicketEditVM editVM)
    {
        //Ticket entitToUpdate = _ticketsRepo.GetWithNoIncludes(editVM.Id);
    }
}
