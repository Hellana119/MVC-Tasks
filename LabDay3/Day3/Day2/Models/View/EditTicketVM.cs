using Day3.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Day3.Models.View
{
   // public record AddTicketVM(bool IsClosed, Severity Severity, string Description, Department? department);
    public record EditTicketVM
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; init; }
        public bool IsClosed { get; init; }
        public Severity Severity { get; init; }
        public string Description { get; init; }
        public Guid DepartmentId { get; init; }

        [Display (Name = "Developers")]
        public List<Guid> DevelopersIds { get; init; }
    }

}
