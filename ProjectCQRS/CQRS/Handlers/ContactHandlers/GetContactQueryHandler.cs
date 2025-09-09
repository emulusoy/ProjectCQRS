using Microsoft.EntityFrameworkCore;
using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Results.ContactResults;

namespace ProjectCQRS.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler(CQRSContext context)

    {
        private readonly CQRSContext _context = context;
        public async Task<List<GetContactQueryResult>> Handle()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return contacts.Select(x=>new GetContactQueryResult
            {
                ContactId = x.ContactId,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                Project = x.Project,
                Subject = x.Subject,
                Message = x.Message,
                IsRead = x.IsRead,
                CreatedAt = x.CreatedAt,
            }).ToList();
        }
    }
}
