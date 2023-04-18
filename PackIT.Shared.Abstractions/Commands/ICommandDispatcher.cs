namespace PackIT.Shared.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchCommandAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}
