using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities;

/// <summary>
/// Задание
/// </summary>
public class Task : BaseEntity<Ulid>, IHasArchiveTrack, IHasTrackDateAttribute
{
    /// <summary>
    /// Идентификатор типа задания
    /// </summary>
    public required Ulid TaskTypeId { get; set; }

    /// <summary>
    /// Тип задания
    /// </summary>
    public TaskType? TaskType { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Идентификатор эмодзи
    /// </summary>
    public Ulid? EmojiId { get; set; }

    /// <summary>
    /// Эмодзи
    /// </summary>
    public Emoji? Emoji { get; set; }

    /// <summary>
    /// Идентификатор цвета
    /// </summary>
    public required Ulid ColorId { get; set; }

    /// <summary>
    /// Цвет
    /// </summary>
    public Color? Color { get; set; }

    /// <summary>
    /// Тип отслеживания
    /// </summary>
    public required TrackingType TrackingType { get; set; }

    /// <summary>
    /// Идентификатор единицы измерения
    /// </summary>
    public Ulid? UnitId { get; set; }

    /// <summary>
    /// Единица измерения
    /// </summary>
    public Unit? Unit { get; set; }

    /// <summary>
    /// Цель
    /// </summary>
    public required string TargetValue { get; set; }

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
