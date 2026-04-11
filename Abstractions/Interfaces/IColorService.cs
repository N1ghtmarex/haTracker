using Core.Utils;
using Domain.Entities;

namespace Abstractions.Interfaces;

public interface IColorService
{
    Task<Result<Color>> GetColorAsync(Ulid id, CancellationToken cancellationToken = default);
}
