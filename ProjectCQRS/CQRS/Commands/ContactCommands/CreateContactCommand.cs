using System.ComponentModel.DataAnnotations;
using ProjectCQRS.Context;

namespace ProjectCQRS.CQRS.Commands.ContactCommands
{
    public class CreateContactCommand
    {
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
