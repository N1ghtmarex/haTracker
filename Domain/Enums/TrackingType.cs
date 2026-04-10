using System.ComponentModel;

namespace Domain.Enums;

/// <summary>
/// Тип отслеживания
/// </summary>
public enum TrackingType
{
    /// <summary>
    /// Выполнено/Не выполнено
    /// </summary>
    [Description("Выполнено/Не выполнено")]
    Boolean = 0,

    /// <summary>
    /// Единица измерения
    /// </summary>
    [Description("Единица измерения")]
    Unit = 1
}
