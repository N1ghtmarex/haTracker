using Domain.Abstractions;

namespace Domain.Entities;

/// <summary>
/// Выполнение
/// </summary>
public class Completion : BaseEntity<Ulid>, IHasArchiveTrack, IHasTrackDateAttribute
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public required Ulid UserId { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Идентификатор задания
    /// </summary>
    public required Ulid TaskId { get; set; }

    /// <summary>
    /// Задание
    /// </summary>
    public Task? Task { get; set; }

    /// <summary>
    /// Статус выполнения
    /// </summary>
    public required bool IsCompleted { get; set; }

    /// <summary>
    /// Текущее значение
    /// </summary>
    public int? CurrentValue { get; set; }

    /// <summary>
    /// Время отметки
    /// </summary>
    public required DateTimeOffset Date { get; init; }

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
