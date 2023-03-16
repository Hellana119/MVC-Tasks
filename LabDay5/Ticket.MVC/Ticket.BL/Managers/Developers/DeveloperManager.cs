using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;
using TicketSystem.DAL.Repos.DevelopersRepo;

namespace TicketSystem.BL.Managers.Developers
{
    public class DeveloperManager : IDeveloperManager
    {
        private readonly IDevelopersRepo _developersRepo;

        public DeveloperManager(IDevelopersRepo developersRepo)
        {
            _developersRepo = developersRepo;
        }
        public IEnumerable<SelectListItem> GetDevelopersListItems()
        {
            IEnumerable<Developer> developersFromDB = _developersRepo.GetAll();
            return developersFromDB.Select(d => new SelectListItem(d.FirstName, d.Id.ToString()));
        }
    }
}
