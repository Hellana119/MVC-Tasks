using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;
using TicketSystem.DAL.Repos.DepartmentsRepo;

namespace TicketSystem.BL;

public class DepartmentManager : IDepartmentManager
{
    private readonly IDepartmentRepo _departmentRepo;

    public DepartmentManager(IDepartmentRepo departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }
    public IEnumerable<SelectListItem> GetDepartmentListItems()
    {
       var departmentsFromDB = _departmentRepo.GetAll();
        return departmentsFromDB.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
    }
}
