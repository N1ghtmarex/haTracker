using Application.Task.Dtos;
using Core.BaseModels;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Task.Queries;

public class GetTaskListQuery : SearchablePagedQuery, IRequest<Result<PagedResult<TaskViewModel>>>
{
    /// <summary>
    /// Дата
    /// </summary>
    [FromQuery]
    public DateTimeOffset? Date { get; init; }

    /// <summary>
    /// Идентификатор типа
    /// </summary>
    [FromQuery]
    public required Ulid TaskTypeId { get; init; }
}
