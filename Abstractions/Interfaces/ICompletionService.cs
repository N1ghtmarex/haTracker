using Core.Utils;
using Domain.Entities;

namespace Abstractions.Interfaces;

public interface ICompletionService
{
    Task<Completion?> GetTaskCompletionByDateAsync(Ulid id, DateTimeOffset date, CancellationToken cancellationToken = default);
}
