using System.ComponentModel.DataAnnotations;

namespace ProjectCQRS.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(200)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Project { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
    }
}
