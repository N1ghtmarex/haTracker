using Core.Utils;

namespace Abstractions.Interfaces;

public interface ITaskService
{
    Task<Result<Domain.Entities.Task>> GetTaskAsync(Ulid id, CancellationToken cancellationToken = default);
}
