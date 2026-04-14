using Abstractions.Interfaces;
using Application.Task.Commands;
using Application.Task.Mappers;
using Core.Utils;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Handlers;

internal class TaskCommandsHandlers(ApplicationDbContext dbContext, IColorService colorService, IEmojiService emojiService,
    IUnitService unitService, IUserService userService, ITaskService taskService, ICompletionService completionService)
        : IRequestHandler<AddTaskTypeCommand, Result<Ulid>>, IRequestHandler<AddTaskCommand, Result<Ulid>>,
        IRequestHandler<EditTaskCompletionCommand, Result<string>>
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

    public async Task<Result<Ulid>> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        var taskToCreate = TaskMapper.MapToEntity(request.Body, Ulid.Parse("01FZJ5K5Z0K8QH3X9N5G0RT0D5"));

        await colorService.GetColorAsync(taskToCreate.ColorId, cancellationToken);
        await emojiService.GetEmojiAsync(taskToCreate.ColorId, cancellationToken);
        await unitService.GetUnitAsync(taskToCreate.ColorId, cancellationToken);
        await userService.GetUserAsync(taskToCreate.ColorId, cancellationToken);

        var createdTask = await dbContext.AddAsync(taskToCreate, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(createdTask.Entity.Id);
    }

    public async Task<Result<string>> Handle(EditTaskCompletionCommand request, CancellationToken cancellationToken)
    {
        var task = await taskService.GetTaskAsync(request.Body.TaskId, cancellationToken);

        if (task.IsFailure)
        {
            return Result.Failure<string>($"Задание с идентификатором \"{request.Body.TaskId}\" не найдено!");
        }

        var completion = await completionService.GetTaskCompletionByDateAsync(task.Value!.Id, DateTimeOffset.UtcNow, cancellationToken);

        if (completion != null)
        {
            if (request.Body.CurrentValue == null)
            {
                return Result.Failure<string>($"Задание с идентификатором \"{request.Body.TaskId}\" уже выполнено!");
            }
            
            completion.CurrentValue = request.Body.CurrentValue;

            completion.IsCompleted = (!completion.IsCompleted || request.Body.CurrentValue != 0) && completion.CurrentValue >= task.Value.TargetValue;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success(completion.IsCompleted ? "Задание выполнено!" : "Изменение прогресса засчитано!");
        }

        var completionToCreate = CompletionMapper.MapToEntity(request.Body, userId: Ulid.Parse("01FZJ5K5Z0K8QH3X9N5G0RT0D5"), 
            isCompleted: (request.Body.CurrentValue != null && request.Body.CurrentValue == task.Value.TargetValue) || task.Value.TargetValue == 0);

        var createdCompletion = await dbContext.AddAsync(completionToCreate, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(createdCompletion.Entity.IsCompleted ? "Задание выполнено!" : "Изменение прогресса засчитано!");
    }
}
