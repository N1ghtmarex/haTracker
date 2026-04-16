namespace Application.Task.Dtos;

/// <summary>
/// Модель выполнения задания
/// </summary>
public class EditTaskCompletionModel
{
    /// <summary>
    /// Идентификатор задания
    /// </summary>
    public required Ulid TaskId { get; init; }

    /// <summary>
    /// Текущее значение
    /// </summary>
    public int? CurrentValue { get; init; }

    /// <summary>
    /// Дата
    /// </summary>
    public DateTimeOffset Date { get; init; }
}
