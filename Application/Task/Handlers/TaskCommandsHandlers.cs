using Application.Task.Commands;
using Application.Task.Mappers;
using Core.Utils;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Handlers;

internal class TaskCommandsHandlers(ApplicationDbContext dbContext) : IRequestHandler<AddTaskTypeCommand, Result<Ulid>>
{
    public async Task<Result<Ulid>> Handle(AddTaskTypeCommand request, CancellationToken cancellationToken)
    {
        var taskTypeWithSameName = await dbContext.TaskTypes
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Name == request.Body.Name, cancellationToken);

        if (taskTypeWithSameName != null)
        {
            return Result.Failure<Ulid>($"Тип задания с названием \"{request.Body.Name}\" уже существует!");
        }

        var taskTypeToCreate = TaskTypeMapper.MapToEntity(request.Body);

        var createdTaskType = await dbContext.AddAsync(taskTypeToCreate, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(createdTaskType.Entity.Id);
    }
}
