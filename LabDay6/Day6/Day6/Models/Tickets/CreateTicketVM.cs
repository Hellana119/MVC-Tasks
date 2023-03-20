using System.ComponentModel.DataAnnotations;

namespace Day6.Models.Tickets
{
    public class CreateTicketVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;

        public CreateTicketVM(int id, string title, string description)
        {
            Id = id;
            Title = title;
        }
     }
}
