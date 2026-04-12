using Application.Mappers;
using Application.Task.Dtos;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Task.Mappers;

[Mapper]
public static partial class CompletionMapper
{
    [MapValue(nameof(Completion.Id), Use = nameof(@GeneralMapper.GenerateId))]
    public static partial Completion MapToEntity(EditTaskCompletionModel source, Ulid userId, bool isCompleted);
}
