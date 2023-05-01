using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands
{
    public record PackItem(Guid PackingListId, string ItemName) : ICommand;
}

