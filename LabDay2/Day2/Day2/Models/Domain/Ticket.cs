namespace Day2.Models.Domain
{
    public class Ticket
    {
        public DateTime CreatedDate { get; set; }
        public bool IsClosed { get; set; }
        public Severity Severity { get; set; }
        public string Description { get; set; }

        public Ticket() { }

        public Ticket(DateTime createdDate, bool isClosed, Severity severity, string description) {
            CreatedDate = createdDate;
            IsClosed = isClosed;
            Severity = severity;
            Description = description;
        }

        public static List<Ticket> GetTickets() => new()
        {
            new (DateTime.Now.AddHours(1),true, Severity.low,"london"),
            new (DateTime.Now.AddHours(2),true, Severity.high,"German"),
            new (DateTime.Now.AddHours(3),true, Severity.medium,"italy"),
            new (DateTime.Now.AddHours(4),true, Severity.high,"Egypt"),


        };
    }
}
