using Domain.Enums;

namespace Application.Task.Dtos;

/// <summary>
/// Модель добавления задания
/// </summary>
public class AddTaskModel
{
    /// <summary>
    /// Идентификатор типа
    /// </summary>
    public required Ulid TaskTypeId { get; init; }

    /// <summary>
    /// Наименование
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Идентификатор эмодзи
    /// </summary>
    public required Ulid EmojiId { get; init; }

    /// <summary>
    /// Идентификатор цвета
    /// </summary>
    public required Ulid ColorId { get; init; }

    /// <summary>
    /// Тип отслеживания
    /// </summary>
    public required TrackingType TrackingType { get; init; }

    /// <summary>
    /// Единица измерения
    /// </summary>
    public required Ulid? UnitId { get; init; }

    /// <summary>
    /// Целевое значение
    /// </summary>
    public required int TargetValue { get; init; }
}
