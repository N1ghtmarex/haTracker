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
    private static Ulid taskTypeId = Ulid.Parse("01KNX9A1FWD6WAZX9ZAY4CXAFQ");
    private static Ulid dailyTypeId = Ulid.Parse("01KNX9ARBT9JK0RCJN2F1K92ET");

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
            .Where(x => !x.IsArchive && x.TaskTypeId == request.TaskTypeId);

        if (request.TaskTypeId == taskTypeId && request.Date != null)
        {
            query = query
                .Where(x => x.Date.Date == request.Date.Value.Date.Date);
        }
        else if (request.TaskTypeId == dailyTypeId && request.Date != null)
        {
            query = query
                .Where(x => x.Date.Date <= request.Date.Value.Date.Date);
        }

        query = query
            .Include(x => x.Color)
            .Include(x => x.Emoji)
            .Include(x => x.Unit)
            .Include(x => x.Author)
            .Include(x => x.TaskType)
            .OrderBy(x => x.Title)
            .ApplySearch(request, x => x.Title);

        var result = await query
            .ApplyPagination(request)
            .Select(x => TaskMapper.MapToViewModel(x, x.Completions != null && x.Completions.FirstOrDefault(x => x.Date.Date == request.Date.GetValueOrDefault().Date) != null 
                ? x.Completions.FirstOrDefault(x => x.Date.Date == request.Date.GetValueOrDefault().Date)!.CurrentValue : 0,
                    x.Completions != null && x.Completions.FirstOrDefault(x => x.Date.Date == request.Date.GetValueOrDefault().Date) != null 
                        && x.Completions.FirstOrDefault(x => x.Date.Date == request.Date.GetValueOrDefault().Date)!.IsCompleted))
            .ToListAsync(cancellationToken);

        return Result.Success(result.AsPagedResult(request, await query.CountAsync(cancellationToken)));
    }
}
