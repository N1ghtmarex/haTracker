using Application.User.Dtos;
using Application.User.Mappers;
using Application.User.Queries;
using Core.EntityFramework.Features.SearchPagination;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Handlers;

internal class UserQueriesHandlers(ApplicationDbContext dbContext) : IRequestHandler<GetUserQuery, Result<UserViewModel>>,
    IRequestHandler<GetUserListQuery, Result<PagedResult<UserViewModel>>>
{
    public async Task<Result<UserViewModel>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .ProjectToViewModel()
            .SingleOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        if (user == null)
        {
            return Result.Failure<UserViewModel>($"Пользователь с идентификатором \"{request.UserId}\" не найден!");
        }

        return Result.Success(user);
    }

    public async Task<Result<PagedResult<UserViewModel>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Users
            .AsNoTracking()
            .Where(x => !x.IsArchive)
            .OrderBy(x => x.Username)
            .ApplySearch(request, x => x.Username);

        var result = await query
            .ApplyPagination(request)
            .ProjectToViewModel()
            .ToListAsync(cancellationToken);

        return Result.Success(result.AsPagedResult(request, await query.CountAsync(cancellationToken)));
    }
}
