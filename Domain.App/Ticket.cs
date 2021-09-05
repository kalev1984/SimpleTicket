using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.App
{
    public class Ticket
    {
        public int Id { get; set; }
        
        [DisplayName("Description Name")]
        [MinLength(5)]
        [MaxLength(50)]
        [Required]
        public string Description { get; set; }
        
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }
        
        [DisplayName("Ticket Created")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public override bool Equals(object obj)
        {
            if (obj is not Ticket ticket)
            {
                return false;
            }

            return Description.Equals(ticket.Description) && DueDate.Equals(ticket.DueDate);
        }

        public override int GetHashCode()
        {
            return Description.GetHashCode() ^ DueDate.GetHashCode();
        }
    }
}