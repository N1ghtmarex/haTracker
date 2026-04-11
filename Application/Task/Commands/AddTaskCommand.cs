using Application.Task.Dtos;
using Core.Utils;
using MediatR;

namespace Application.Task.Commands;

public class AddTaskCommand : IRequest<Result<Ulid>>
{
    /// <summary>
    /// Модель запроса
    /// </summary>
    public required AddTaskModel Body { get; init; }
}
