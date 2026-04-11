using Core.Utils;
using Domain.Entities;

namespace Abstractions.Interfaces;

public interface IEmojiService
{
    Task<Result<Emoji>> GetEmojiAsync(Ulid id, CancellationToken cancellationToken = default);
}
