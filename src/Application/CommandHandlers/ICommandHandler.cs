using Application.Commands;

namespace Application.CommandHandlers;

public interface ICommandHandler<in T> where T : ICommand
{
    Task Handle(T command);
}