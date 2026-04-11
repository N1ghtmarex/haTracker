using Application.Unit.Dtos;
using Core.Utils;
using MediatR;

namespace Application.Unit.Commands;

public class AddUnitCommand : IRequest<Result<Ulid>>
{
    /// <summary>
    /// Модель запроса
    /// </summary>
    public required AddUnitModel Body { get; init; }
}
