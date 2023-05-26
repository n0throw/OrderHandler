using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace OrderHandler.DB.Data.UserAdd;

/// <summary>
/// Класс GivenName.
/// ФИО Пользователя.
/// Модель БД.
/// </summary>
public class GivenName : ICloneable {
    /// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Отчество
    /// </summary>
    public string MiddleName { get; set; }
    
    /// <summary>
    /// Возвращает полное имя пользователя
    /// </summary>
    /// <returns>
    /// Cтрока вида "Фамилия Имя Отчество"
    /// </returns>
    public string GetFullRecordName() =>RemoveTwoMoreSpace.Replace(
        $"{LastName} {FirstName} {MiddleName}".Trim(), 
        ""
    );

    /// <summary>
    /// Возвращает среднюю форму имени пользователя
    /// </summary>
    /// <returns>Строка вида "Фамилия И.О."</returns>
    public string GerMiddleRecordName() => RemoveTwoMoreSpace.Replace(
        $"{LastName} {FirstName.FirstOrDefault()}.{MiddleName.FirstOrDefault()}.".Trim(), 
        ""
    );
    
    /// <summary>
    /// Возвращает короткую форму имени пользователя
    /// </summary>
    /// <returns>
    /// Cтрока вида "ФИО"
    /// </returns>
    public string GetShortRecordName() =>
        $"{LastName.FirstOrDefault()}{FirstName.FirstOrDefault()}{MiddleName.FirstOrDefault()}".Trim();

    public object Clone() => MemberwiseClone();
    
    static readonly Regex RemoveTwoMoreSpace = new(
        "\\s{2,}",
        RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace
    );
}
