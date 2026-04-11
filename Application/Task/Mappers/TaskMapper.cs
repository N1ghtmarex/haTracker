using Application.Mappers;
using Application.Task.Dtos;
using Riok.Mapperly.Abstractions;

namespace Application.Task.Mappers;

[Mapper]
public static partial class TaskMapper
{
    [MapValue(nameof(Domain.Entities.Task.Id), Use = nameof(@GeneralMapper.GenerateId))]
    public static partial Domain.Entities.Task MapToEntity(AddTaskModel source, Ulid authorId);
}
