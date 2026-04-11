using Application.Mappers;
using Application.Task.Dtos;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Task.Mappers;

[Mapper]
public static partial class TaskTypeMapper
{
    [MapValue(nameof(TaskType.Id), Use = nameof(@GeneralMapper.GenerateId))]
    public static partial TaskType MapToEntity(AddTaskTypeModel source);

    public static partial IQueryable<TaskTypeViewModel> ProjectToViewModel(this IQueryable<TaskType> q);
}
