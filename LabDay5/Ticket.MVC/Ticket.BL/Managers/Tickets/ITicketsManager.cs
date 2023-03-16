using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.ViewModels;

namespace TicketSystem.BL;
//namespace TicketSystem.BL.Managers.Tickets



public interface ITicketsManager
{
    TicketDetailsVM? GetTicketDetails(int id);
    TicketEditVM GetForEdit(int id);
    void Update(TicketEditVM editVM);
}
