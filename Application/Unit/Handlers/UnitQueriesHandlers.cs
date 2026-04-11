using Application.Unit.Dtos;
using Application.Unit.Mappers;
using Application.Unit.Queries;
using Core.EntityFramework.Features.SearchPagination;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Unit.Handlers;

internal class UnitQueriesHandlers(ApplicationDbContext dbContext) : IRequestHandler<GetUnitListQuery, Result<PagedResult<UnitViewModel>>>
{
    public async Task<Result<PagedResult<UnitViewModel>>> Handle(GetUnitListQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Units
            .AsNoTracking()
            .Where(x => !x.IsArchive)
            .OrderBy(x => x.Name)
            .ThenBy(x => x.ShortName)
            .ApplySearch(request, x => x.Name, x => x.ShortName);

        var result = await query
            .ApplyPagination(request)
            .ProjectToViewModel()
            .ToListAsync(cancellationToken);

        return Result.Success(result.AsPagedResult(request, await query.CountAsync(cancellationToken)));
    }
}
