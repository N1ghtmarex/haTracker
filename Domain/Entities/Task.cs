using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities;

/// <summary>
/// Задание
/// </summary>
public class Task : BaseEntity<Ulid>, IHasArchiveTrack, IHasTrackDateAttribute
{
    /// <summary>
    /// Идентификатор создателя
    /// </summary>
    public required Ulid AuthorId { get; set; }

    /// <summary>
    /// Создатель
    /// </summary>
    public User? Author { get; set; }

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
    public required int TargetValue { get; set; }

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
    /// Дата
    /// </summary>
    public required DateTimeOffset Date { get; set; }

    /// <summary>
    /// Выполнения
    /// </summary>
    public ICollection<Completion>? Completions { get; set; }
}
