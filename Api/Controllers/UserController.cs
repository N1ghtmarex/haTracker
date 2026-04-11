using Application.User.Dtos;
using Application.User.Queries;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("user")]
public class UserController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Получение конкретного пользователя
    /// </summary>
    /// <param name="query">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("{UserId}")]
    public async Task<Result<UserViewModel>> GetUser([FromQuery] GetUserQuery query, CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    /// <summary>
    /// Получение списка пользователей
    /// </summary>
    /// <param name="query">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<Result<PagedResult<UserViewModel>>> GetUsers([FromQuery] GetUserListQuery query, CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }
}
