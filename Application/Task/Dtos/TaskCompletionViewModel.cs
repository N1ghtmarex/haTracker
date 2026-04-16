using Application.Color.Dtos;
using Application.Emoji.Dtos;

namespace Application.Task.Dtos;

/// <summary>
/// Модель выполнений задания
/// </summary>
public class TaskCompletionViewModel
{
    /// <summary>
    /// Идентификатор задания
    /// </summary>
    public required Ulid Id { get; init; }

    /// <summary>
    /// Наименование задания
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Иконка
    /// </summary>
    public EmojiViewModel? Emoji { get; init; }

    /// <summary>
    /// Целевое значение
    /// </summary>
    public required int TargetValue { get; init; }

    /// <summary>
    /// Цвет
    /// </summary>
    public required ColorViewModel Color { get; init; }

    /// <summary>
    /// Максимальная серия выполнений
    /// </summary>
    public required int MaxStreak { get; init; }

    /// <summary>
    /// Текущая серия выполнений
    /// </summary>
    public required int CurrentStreak { get; init; }

    /// <summary>
    /// Выполнения
    /// </summary>
    public List<CompletionViewModel>? Completions { get; init; }
}
