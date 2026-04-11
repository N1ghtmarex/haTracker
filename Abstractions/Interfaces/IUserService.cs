using Core.Utils;
using Domain.Entities;

namespace Abstractions.Interfaces;

public interface IUserService
{
    Task<Result<User>> GetUserAsync(Ulid id, CancellationToken cancellationToken = default);
}