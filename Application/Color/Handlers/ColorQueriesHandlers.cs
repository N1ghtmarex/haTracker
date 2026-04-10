using Application.Color.Dtos;
using Application.Color.Mappers;
using Application.Color.Queries;
using Core.EntityFramework.Features.SearchPagination;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Color.Handlers;

internal class ColorQueriesHandlers(ApplicationDbContext dbContext) : IRequestHandler<GetColorListQuery, Result<PagedResult<ColorViewModel>>>
{
    public async Task<Result<PagedResult<ColorViewModel>>> Handle(GetColorListQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Colors
            .AsNoTracking()
            .Where(x => !x.IsArchive)
            .OrderBy(x => x.Value)
            .ApplySearch(request, x => x.Value);

        var result = await query
            .ApplyPagination(request)
            .ProjectToViewModel()
            .ToListAsync(cancellationToken);

        return Result.Success(result.AsPagedResult(request, await query.CountAsync(cancellationToken)));
    }
}
