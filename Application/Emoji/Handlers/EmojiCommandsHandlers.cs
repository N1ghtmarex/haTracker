using Application.Emoji.Commands;
using Application.Emoji.Mappers;
using Core.Utils;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Emoji.Handlers;

public class EmojiCommandsHandlers(ApplicationDbContext dbContext) : IRequestHandler<AddEmojiCommand, Result<Ulid>>
{
    public async Task<Result<Ulid>> Handle(AddEmojiCommand request, CancellationToken cancellationToken)
    {
        var emojiWithSameValue = await dbContext.Emojis
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Value == request.Body.Value, cancellationToken);

        if (emojiWithSameValue != null)
        {
            return Result.Failure<Ulid>($"Эмодзи \"{request.Body.Value}\" уже добавлено!");
        }

        var emojiToCreate = EmojiMapper.MapToEntity(request.Body);

        var createdEmoji = await dbContext.AddAsync(emojiToCreate, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(createdEmoji.Entity.Id);
    }
}
