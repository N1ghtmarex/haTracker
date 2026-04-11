using Application.Emoji.Commands;
using Application.Emoji.Dtos;
using Application.Emoji.Queries;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("emoji")]
public class EmojiController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Добавление эмодзи
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<Result<Ulid>> AddEmoji([FromBody] AddEmojiCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Получение списка эмодзи
    /// </summary>
    /// <param name="query">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<Result<PagedResult<EmojiViewModel>>> GetEmojis([FromQuery] GetEmojiListQuery query, CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }
}
