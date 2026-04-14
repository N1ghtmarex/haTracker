namespace Application.Task.Dtos;

/// <summary>
/// Модель добавления типа задания
/// </summary>
public class AddTaskTypeModel
{
    /// <summary>
    /// Наименование
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Иконка
    /// </summary>
    public required string Icon { get; init; }
}
