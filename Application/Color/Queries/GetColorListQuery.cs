using Application.Color.Dtos;
using Core.EntityFramework.Features.SearchPagination.Models;
using MediatR;

namespace Application.Color.Queries;

public class GetColorListQuery : IRequest<PagedResult<ColorViewModel>>
{
}
