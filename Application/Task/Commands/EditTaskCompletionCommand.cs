using Application.Task.Dtos;
using Core.Utils;
using MediatR;

namespace Application.Task.Commands;

public class EditTaskCompletionCommand : IRequest<Result<string>>
{
    /// <summary>
    /// Модель запроса
    /// </summary>
    public required EditTaskCompletionModel Body { get; init; }
}
