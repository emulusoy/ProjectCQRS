using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using ProjectCQRS.Abstractions;
using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.ContactCommands;
using ProjectCQRS.CQRS.Results.ContactResults;
using ProjectCQRS.Entities;

namespace ProjectCQRS.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly CQRSContext _ctx;
        private readonly IEmailSender _email;
        private readonly IConfiguration _cfg;
        private readonly IAutoReplyComposer _composer;

        public CreateContactCommandHandler(CQRSContext ctx, IEmailSender email, IConfiguration cfg, IAutoReplyComposer composer)
        {
            _ctx = ctx; _email = email; _cfg = cfg;
            _composer = composer;
        }

        public async Task Handle(CreateContactCommand cmd)
        {
            var contact = new Contact
            {
                Name = cmd.Name,
                Email = cmd.Email,
                Phone = cmd.Phone,
                Project = cmd.Project,
                Subject = cmd.Subject,
                Message = cmd.Message,
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };

            _ctx.Contacts.Add(contact);
            await _ctx.SaveChangesAsync();
            var key = _cfg["GEMINI_API_KEY"]!;
            var aiText = await _composer.ComposeAsync(contact.Message);
            var body = $"Merhaba {contact.Name},\n\n{aiText}\n\nEMU AI LLM n8n \n+90 155 335 00 55\nwww.eemulusoy.com";
            await _email.SendAsync(contact.Email, contact.Name, contact.Subject ?? "Teşekkürler", body);

        }
    }
}
