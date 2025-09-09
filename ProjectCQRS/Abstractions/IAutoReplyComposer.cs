using ProjectCQRS.CQRS.Results.ContactResults;

namespace ProjectCQRS.Abstractions
{
    public interface IAutoReplyComposer
    {
        Task<string> ComposeAsync(string customerMessage, CancellationToken ct = default);

    }
}
