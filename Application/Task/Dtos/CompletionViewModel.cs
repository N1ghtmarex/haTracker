namespace Application.Task.Dtos;

/// <summary>
/// Модель выполнения
/// </summary>
public class CompletionViewModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required Ulid Id { get; init; }

    /// <summary>
    /// Дата
    /// </summary>
    public required DateTimeOffset Date { get; init; }

    /// <summary>
    /// Текущее значение
    /// </summary>
    public required int CurrentValue { get; init; }

    /// <summary>
    /// Статус выполнения
    /// </summary>
    public required bool IsCompleted { get; init; }
}
