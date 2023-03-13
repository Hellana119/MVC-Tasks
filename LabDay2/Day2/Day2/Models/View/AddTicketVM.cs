using Day2.Models.Domain;

namespace Day2.Models.View
{
    public record AddTicketVM(bool IsClosed, Severity Severity, string Description);
 
}
