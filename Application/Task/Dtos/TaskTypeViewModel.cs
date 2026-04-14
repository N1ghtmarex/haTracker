namespace Application.Task.Dtos;

/// <summary>
/// Модель типа задания
/// </summary>
public class TaskTypeViewModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required Ulid Id { get; init; }

    /// <summary>
    /// Наименование
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Иконка
    /// </summary>
    public required string Icon { get; init; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Дата последнего изменения
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; init; }
}
