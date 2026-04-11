using Application.Emoji.Dtos;
using Application.Mappers;
using Riok.Mapperly.Abstractions;

namespace Application.Emoji.Mappers;

[Mapper]
public static partial class EmojiMapper
{
    [MapValue(nameof(Domain.Entities.Emoji.Id), Use = nameof(@GeneralMapper.GenerateId))]
    public static partial Domain.Entities.Emoji MapToEntity(AddEmojiModel source);

    public static partial IQueryable<EmojiViewModel> ProjectToViewModel(this IQueryable<Domain.Entities.Emoji> q);
}
