using Application.Task.Dtos;
using Core.Utils;
using MediatR;

namespace Application.Task.Commands;

public class AddTaskTypeCommand : IRequest<Result<Ulid>>
{
    /// <summary>
    /// Модель запроса
    /// </summary>
    public required AddTaskTypeModel Body { get; init; }
}
