using Abstractions.Interfaces;
using Core.Utils;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

internal class TaskService(ApplicationDbContext dbContext) : ITaskService
{
    public async Task<Result<Domain.Entities.Task>> GetTaskAsync(Ulid id, CancellationToken cancellationToken = default)
    {
        var task = await dbContext.Tasks
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (task != null)
        {
            return Result.Success(task);
        }

        return Result.Failure<Domain.Entities.Task>($"Задание с идентификатором \"{id}\" не найдено!");
    }
}
