using Domain.Abstractions;

namespace Domain.Entities;

/// <summary>
/// Тип элемента отслеживания
/// </summary>
public class TaskType : BaseEntity<Ulid>, IHasArchiveTrack, IHasTrackDateAttribute
{
    /// <summary>
    /// Наименование
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Иконка
    /// </summary>
    public required string Icon { get; set; }

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

    /// <summary>
    /// Задания
    /// </summary>
    public ICollection<Task>? Tasks { get; set; }
}
