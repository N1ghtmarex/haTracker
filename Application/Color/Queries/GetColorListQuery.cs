using Application.Color.Dtos;
using Core.BaseModels;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using MediatR;

namespace Application.Color.Queries;

public class GetColorListQuery : SearchablePagedQuery, IRequest<Result<PagedResult<ColorViewModel>>>
{
}
