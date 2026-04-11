namespace Application.User.Dtos;

/// <summary>
/// Модель пользователя
/// </summary>
public class UserViewModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required Ulid Id { get; init; }

    /// <summary>
    /// Идентификатор во внешней системе
    /// </summary>
    public required Guid ExternalUserId { get; init; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Username { get; init; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Дата последнего изменения
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; init; }
}
