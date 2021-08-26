

namespace BoBStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommands
    {
        ICommandResult Handler(T Command);
    }
}