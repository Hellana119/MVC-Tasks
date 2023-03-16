using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;

namespace TicketSystem.DAL.Repos.DepartmentsRepo
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly TicketContext _context;

        public DepartmentRepo(TicketContext context)
        {
            _context = context;
        }
        public IEnumerable<Department> GetAll()
        {
            return _context.Set<Department>();
        }
    }
}
