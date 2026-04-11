using Application.Emoji.Dtos;
using Core.Utils;
using MediatR;

namespace Application.Emoji.Commands;

public class AddEmojiCommand : IRequest<Result<Ulid>>
{
    /// <summary>
    /// Модель запроса
    /// </summary>
    public required AddEmojiModel Body { get; init; }
}
