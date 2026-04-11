using Application.User.Dtos;
using Core.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.User.Queries;

public class GetUserQuery : IRequest<Result<UserViewModel>>
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [FromRoute]
    public required Ulid UserId { get; set; }
}
