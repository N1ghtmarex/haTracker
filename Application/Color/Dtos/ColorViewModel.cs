namespace Application.Color.Dtos;

/// <summary>
/// Модель цвета
/// </summary>
public class ColorViewModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required Ulid Id { get; init; }

    /// <summary>
    /// Значение
    /// </summary>
    public required string Value { get; init; }
}
