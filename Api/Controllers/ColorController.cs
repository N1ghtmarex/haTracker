using Application.Color.Commands;
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
}
