using Domain.Abstractions;

namespace Domain.Entities;

public class User : BaseEntity<Ulid>, IHasTrackDateAttribute, IHasArchiveTrack
{
    /// <summary>
    /// Идентификатор пользователя из внешней системы
    /// </summary>
    public required Guid ExternalUserId { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Username { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Дата изменения
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// Статус архивности
    /// </summary>
    public bool IsArchive { get; set; }
}
