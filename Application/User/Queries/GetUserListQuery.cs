using Application.User.Dtos;
using Core.BaseModels;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using MediatR;

namespace Application.User.Queries;

public class GetUserListQuery : SearchablePagedQuery, IRequest<Result<PagedResult<UserViewModel>>>
{
}
