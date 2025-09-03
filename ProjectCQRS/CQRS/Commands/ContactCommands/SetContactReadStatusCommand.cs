namespace ProjectCQRS.CQRS.Commands.ContactCommands
{
    public class SetContactReadStatusCommand
    {
        public int ContactId { get; set; }

        public SetContactReadStatusCommand(int contactId)
        {
            ContactId = contactId;
        }

        public bool IsRead { get; set; }
    }
}
