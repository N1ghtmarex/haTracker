using Abstractions.Interfaces;
using Core.Utils;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmojiService(ApplicationDbContext dbContext) : IEmojiService
{
    public async Task<Result<Emoji>> GetEmojiAsync(Ulid id, CancellationToken cancellationToken = default)
    {
        var emoji = await dbContext.Emojis
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (emoji != null)
        {
            return Result.Success(emoji);
        }

        return Result.Failure<Emoji>($"Эмодзи с идентификатором \"{id}\" не найдено!");
    }
}
