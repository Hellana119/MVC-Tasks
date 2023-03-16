using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAL.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<Ticket> Tickets => new HashSet<Ticket>();
        public string FullName() => $"{FirstName} {LastName}";
    }
}
