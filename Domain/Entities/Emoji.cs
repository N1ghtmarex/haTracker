using Domain.Abstractions;

namespace Domain.Entities;

/// <summary>
/// Эмодзи для использования в качестве иконки
/// </summary>
public class Emoji : BaseEntity<Ulid>, IHasArchiveTrack
{
    /// <summary>
    /// Текстовое значение
    /// </summary>
    public required string Value { get; set; }
    /// <summary>
    /// Статус архивности
    /// </summary>
    public bool IsArchive { get; set; }

    /// <summary>
    /// Задания
    /// </summary>
    public ICollection<Task>? Tasks { get; set; }
}
