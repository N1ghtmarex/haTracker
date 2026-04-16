using Application.Task.Dtos;
using Core.BaseModels;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using MediatR;

namespace Application.Task.Queries;

public class GetTasksCompletionsListQuery : SearchablePagedQuery, IRequest<Result<PagedResult<TaskCompletionViewModel>>>
{
}
