using Domain.Abstractions;

namespace Domain.Entities;

/// <summary>
/// Цвет
/// </summary>
public class Color : BaseEntity<Ulid>, IHasArchiveTrack
{
    /// <summary>
    /// Значение
    /// </summary>
    public required string Value { get; set; }

    /// <summary>
    /// Статус архивности
    /// </summary>
    public bool IsArchive { get; set; }
}
