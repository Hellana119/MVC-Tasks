using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAL.Models;

public class Ticket
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public Severity severity { get; set; }
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
    public Ticket()
    {

    }
    public Ticket(int id, string title, string description, Severity Severity, Department department, HashSet<Developer> developers)
    {
        Id = id;
        Title = title;
        Description = description;
        severity = Severity;
        Department = department;
        Developers = developers;
    }
    public enum Severity
    {
        Low, Medium, High
    }
}
