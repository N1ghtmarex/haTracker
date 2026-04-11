namespace Application.Unit.Dtos;

/// <summary>
/// Модель добавления единицы измерения
/// </summary>
public class AddUnitModel
{
    /// <summary>
    /// Наименование
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Сокращенное наименование
    /// </summary>
    public required string ShortName { get; init; }
}
