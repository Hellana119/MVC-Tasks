using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BL.ViewModels
{
    public record TicketEditVM(int Id,
        string Title,
        int DepartmentId,
        int [] DevelopersIds);
     
}
