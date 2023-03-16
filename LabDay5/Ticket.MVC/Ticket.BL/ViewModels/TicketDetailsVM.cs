using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TicketSystem.DAL.Models.Ticket;


namespace TicketSystem.BL.ViewModels
{
    public record TicketDetailsVM(int Id,
        string Title,
        string Description,
        Severity Severity,
        string DepartmentName,
        int DevelorerCount
        );
  
}
