namespace Application.Unit.Dtos;

/// <summary>
/// Модель единицы измерения
/// </summary>
public class UnitViewModel
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
    /// Сокращенное наименование
    /// </summary>
    public required string ShortName { get; init; }
}
