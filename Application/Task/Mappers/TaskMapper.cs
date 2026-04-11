using Application.Color.Mappers;
using Application.Emoji.Mappers;
using Application.Mappers;
using Application.Task.Dtos;
using Application.Unit.Mappers;
using Application.User.Mappers;
using Riok.Mapperly.Abstractions;

namespace Application.Task.Mappers;

[Mapper]
[UseStaticMapper(typeof(ColorMapper))]
[UseStaticMapper(typeof(EmojiMapper))]
[UseStaticMapper(typeof(UnitMapper))]
[UseStaticMapper(typeof(UserMapper))]
public static partial class TaskMapper
{
    [MapValue(nameof(Domain.Entities.Task.Id), Use = nameof(@GeneralMapper.GenerateId))]
    public static partial Domain.Entities.Task MapToEntity(AddTaskModel source, Ulid authorId);

    public static partial TaskViewModel MapToViewModel(Domain.Entities.Task source);
}
