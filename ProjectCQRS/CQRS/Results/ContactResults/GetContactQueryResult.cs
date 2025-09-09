using System.ComponentModel.DataAnnotations;

namespace ProjectCQRS.CQRS.Results.ContactResults
{
    public class GetContactQueryResult
    {
        public int ContactId { get; set; }
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(200)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Project { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
