using Application.Color.Dtos;
using Core.Utils;
using MediatR;

namespace Application.Color.Commands;

public class AddColorCommand : IRequest<Result<Ulid>>
{
    /// <summary>
    /// Модель запроса
    /// </summary>
    public required AddColorModel Model { get; init; }
}
