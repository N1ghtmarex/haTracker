namespace Application.Emoji.Dtos;

/// <summary>
/// Модель эмодзи
/// </summary>
public class EmojiViewModel
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
