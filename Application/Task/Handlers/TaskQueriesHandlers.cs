using Application.Task.Dtos;
using Application.Task.Mappers;
using Application.Task.Queries;
using Core.EntityFramework.Features.SearchPagination;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Handlers;

internal class TaskQueriesHandlers(ApplicationDbContext dbContext) : IRequestHandler<GetTaskTypeListQuery, Result<PagedResult<TaskTypeViewModel>>>,
    IRequestHandler<GetTaskListQuery, Result<PagedResult<TaskViewModel>>>
{
    public async Task<Result<PagedResult<TaskTypeViewModel>>> Handle(GetTaskTypeListQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.TaskTypes
            .AsNoTracking()
            .Where(x => !x.IsArchive)
            .OrderBy(x => x.Name)
            .ApplySearch(request, x => x.Name);

        var result = await query
            .ApplyPagination(request)
            .ProjectToViewModel()
            .ToListAsync(cancellationToken);

        return Result.Success(result.AsPagedResult(request, await query.CountAsync(cancellationToken)));
    }

    public async Task<Result<PagedResult<TaskViewModel>>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Tasks
            .AsNoTracking()
            .Where(x => !x.IsArchive)
            .Include(x => x.Color)
            .Include(x => x.Emoji)
            .Include(x => x.Unit)
            .Include(x => x.Author)
            .Include(x => x.TaskType)
            .OrderBy(x => x.Title)
            .ApplySearch(request, x => x.Title);

        var result = await query
            .ApplyPagination(request)
            .Select(x => TaskMapper.MapToViewModel(x, x.Completions.First().CurrentValue, x.Completions.First().IsCompleted))
            .ToListAsync(cancellationToken);

        return Result.Success(result.AsPagedResult(request, await query.CountAsync(cancellationToken)));
    }
}
