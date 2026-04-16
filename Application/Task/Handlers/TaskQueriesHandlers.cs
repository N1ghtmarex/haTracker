using Application.Task.Dtos;
using Application.Task.Mappers;
using Application.Task.Queries;
using Core.EntityFramework.Features.SearchPagination;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Handlers;

internal class TaskQueriesHandlers(ApplicationDbContext dbContext) : IRequestHandler<GetTaskTypeListQuery, Result<PagedResult<TaskTypeViewModel>>>,
    IRequestHandler<GetTaskListQuery, Result<PagedResult<TaskViewModel>>>, IRequestHandler<GetTasksCompletionsListQuery, Result<PagedResult<TaskCompletionViewModel>>>
{
    private static Ulid taskTypeId = Ulid.Parse("01KNX9A1FWD6WAZX9ZAY4CXAFQ");
    private static Ulid dailyTypeId = Ulid.Parse("01KNX9ARBT9JK0RCJN2F1K92ET");
    private static Ulid habitTypeId = Ulid.Parse("01KNX9AVXFSF21PCFEYCG620KB");

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

    public async Task<Result<PagedResult<TaskCompletionViewModel>>> Handle(GetTasksCompletionsListQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Tasks
            .AsNoTracking()
            .Where(x => x.TaskTypeId == habitTypeId)
            .Include(x => x.Completions)
            .Include(x => x.Emoji)
            .Include(x => x.Color)
            .OrderBy(x => x.Title)
            .ApplySearch(request, x => x.Title);

        var result = await query
            .ApplyPagination(request)
            .Select(x => CompletionMapper.MapToViewModel(x, CalculateMaxStreak(x.Completions), CalculateCurrentStreak(x.Completions)))
            .ToListAsync(cancellationToken);

        return Result.Success(result.AsPagedResult(request, await query.CountAsync(cancellationToken)));
    }

    private static int CalculateMaxStreak(ICollection<Completion>? completions)
    {

        if (completions == null)
        {
            return 0;
        }

        var streak = 1;
        var maxStreak = 1;

        var dates = completions
            .OrderBy(x => x.Date)
            .Where(x => x.IsCompleted)
            .Select(x => x.Date.Date)
            .ToList();

        for (var i = 1; i < dates.Count; i++)
        {
            if ((dates[i] - dates[i - 1]).TotalDays == 1)
            {
                streak++;
            }
            else
            {
                maxStreak = streak > maxStreak ? streak : maxStreak;
                streak = 1;
            }
        }

        return Math.Max(streak, maxStreak);
    }

    private static int CalculateCurrentStreak(ICollection<Completion>? completions)
    {
        if (completions == null)
        {
            return 0;
        }

        int currentStreak = 0;
        var checkDate = DateTimeOffset.UtcNow.Date;

        var dates = completions
            .OrderBy(x => x.Date)
            .Where(x => x.IsCompleted)
            .Select(x => x.Date.Date)
            .ToList();

        if (!dates.Contains(checkDate))
        {
            checkDate = checkDate.AddDays(-1);
        }

        while (dates.Contains(checkDate))
        {
            currentStreak++;
            checkDate = checkDate.AddDays(-1);
        }

        return currentStreak;
    }
}
