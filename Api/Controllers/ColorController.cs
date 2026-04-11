using Application.Color.Commands;
using Application.Color.Dtos;
using Application.Color.Queries;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("color")]
public class ColorController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Добавление цвета
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost("add")]
    public async Task<Result<Ulid>> AddColor([FromBody] AddColorCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Получение списка цветов
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<Result<PagedResult<ColorViewModel>>> GetColors([FromQuery] GetColorListQuery query, CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }
}
