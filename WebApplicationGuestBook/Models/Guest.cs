using System.ComponentModel.DataAnnotations;

namespace WebApplicationGuestBook.Models
{
    public class Guest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Note { get; set; }
        public string? Relation { get;set; }
        public string? NoKendaraan { get; set; }
        public string Username { get; set;}
    }
}
