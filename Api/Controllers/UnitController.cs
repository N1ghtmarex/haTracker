using Application.Unit.Commands;
using Application.Unit.Dtos;
using Application.Unit.Queries;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("unit")]
public class UnitController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Добавление единицы измерения
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<Result<Ulid>> AddUnit([FromBody] AddUnitCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Получение списка единиц измерения
    /// </summary>
    /// <param name="query">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<Result<PagedResult<UnitViewModel>>> GetUnits([FromQuery] GetUnitListQuery query, CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }
}
