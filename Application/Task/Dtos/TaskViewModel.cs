using Application.Color.Dtos;
using Application.Emoji.Dtos;
using Application.Unit.Dtos;
using Application.User.Dtos;
using Domain.Enums;

namespace Application.Task.Dtos;

/// <summary>
/// Модель задания
/// </summary>
public class TaskViewModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required Ulid Id { get; init; }

    /// <summary>
    /// Автор
    /// </summary>
    public required UserViewModel Author { get; init; }

    /// <summary>
    /// Тип
    /// </summary>
    public required TaskTypeViewModel TaskType { get; init; }

    /// <summary>
    /// Наименование
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Эмодзи
    /// </summary>
    public required EmojiViewModel Emoji { get; init; }

    /// <summary>
    /// Цвет
    /// </summary>
    public required ColorViewModel Color { get; init; }

    /// <summary>
    /// Тип отслеживания
    /// </summary>
    public required TrackingType TrackingType { get; init; }

    /// <summary>
    /// Единица измерения
    /// </summary>
    public UnitViewModel? Unit { get; init; }

    /// <summary>
    /// Целевое значение
    /// </summary>
    public required int TargetValue { get; init; }

    /// <summary>
    /// Текущее значение
    /// </summary>
    public int? CurrentValue { get; init; }

    /// <summary>
    /// Статус выполнения
    /// </summary>
    public required bool IsCompleted { get; init; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Дата последнего изменения
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; init; }
}
