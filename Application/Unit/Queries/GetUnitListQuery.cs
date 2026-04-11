using Application.Unit.Dtos;
using Core.BaseModels;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using MediatR;

namespace Application.Unit.Queries;

public class GetUnitListQuery : SearchablePagedQuery, IRequest<Result<PagedResult<UnitViewModel>>>
{
}
