using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL;

namespace TicketSystem.BL.ViewModels
{
    public record ReadVM(int Id, string Title, string Description, Severity Severity);

}
