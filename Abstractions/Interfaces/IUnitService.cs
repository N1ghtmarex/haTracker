using Core.Utils;
using Domain.Entities;

namespace Abstractions.Interfaces;

public interface IUnitService
{
    Task<Result<Unit>> GetUnitAsync(Ulid id, CancellationToken cancellationToken = default);
}