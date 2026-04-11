using Application.Task.Dtos;
using Core.BaseModels;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using MediatR;

namespace Application.Task.Queries;

public class GetTaskTypeListQuery : SearchablePagedQuery, IRequest<Result<PagedResult<TaskTypeViewModel>>>
{
}
