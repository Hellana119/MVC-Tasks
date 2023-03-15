using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.ViewModels;
using TicketSystem.DAL;


namespace TicketSystem.BL
{
    public interface ITicketsManager
    {
       List<ReadVM> GetAll();
        ReadVM? Get(int id);
        void Add(AddVM ticket);
    }
}
