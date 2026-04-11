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

internal class TaskQueriesHandlers(ApplicationDbContext dbContext) : IRequestHandler<GetTaskTypeListQuery, Result<PagedResult<TaskTypeViewModel>>>
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
}
