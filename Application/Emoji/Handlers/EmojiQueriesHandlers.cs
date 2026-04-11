using Application.Emoji.Dtos;
using Application.Emoji.Mappers;
using Application.Emoji.Queries;
using Core.EntityFramework.Features.SearchPagination;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Emoji.Handlers;

internal class EmojiQueriesHandlers(ApplicationDbContext dbContext) : IRequestHandler<GetEmojiListQuery, Result<PagedResult<EmojiViewModel>>>
{
    public async Task<Result<PagedResult<EmojiViewModel>>> Handle(GetEmojiListQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Emojis
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
