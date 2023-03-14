using Day3.Models.Domain;

namespace Day3.Models.View
{
   // public record AddTicketVM(bool IsClosed, Severity Severity, string Description, Department? department);
    public record AddTicketVM
    {
        public DateTime CreatedDate { get; init; }
        public bool IsClosed { get; init; }
        public Severity Severity { get; init; }
        public string Description { get; init; }
        public Guid DepartmentId { get; init; }
        public List<Guid> DevelopersIds { get; init; }
    }

}
