using System.Text.RegularExpressions;

namespace OrderHandler.DB.Data.UserAdd;

/// <summary>
/// Класс GivenName.
/// ФИО Пользователя.
/// Модель БД.
/// </summary>
public class GivenName {
    /// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public int Id { get; set; }
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
    /// Id Личного имени, для которого данное ФИО представлено в именительном падеже.
    /// Внешний ключ
    /// </summary>
    public int IdNominative { get; set; }
    /// <summary>
    /// Личное имя, для которого данное ФИО представлено в именительном падеже.
    /// </summary>
    public CaseName? Nominative { get; set; }

    /// <summary>
    /// Id Личного имени, для которого данное ФИО представлено в родительном падеже.
    /// Внешний ключ
    /// </summary>
    public int IdGenitive { get; set; }
    /// <summary>
    /// Личное имя, для которого данное ФИО представлено в родительном падеже.
    /// </summary>
    public CaseName? Genitive { get; set; }

    /// <summary>
    /// Id Личного имени, для которого данное ФИО представлено в дательном падеже.
    /// Внешний ключ
    /// </summary>
    public int IdDative { get; set; }
    /// <summary>
    /// Личное имя, для которого данное ФИО представлено в дательном падеже.
    /// </summary>
    public CaseName? Dative { get; set; }

    /// <summary>
    /// Id Личного имени, для которого данное ФИО представлено в винительонм падеже.
    /// Внешний ключ
    /// </summary>
    public int IdAccusative { get; set; }
    /// <summary>
    /// Личное имя, для которого данное ФИО представлено в винительонм падеже.
    /// </summary>
    public CaseName? Accusative { get; set; }

    /// <summary>
    /// Id Личного имени, для которого данное ФИО представлено в творительном падеже.
    /// Внешний ключ
    /// </summary>
    public int IdAblative { get; set; }
    /// <summary>
    /// Личное имя, для которого данное ФИО представлено в творительном падеже.
    /// </summary>
    public CaseName? Ablative { get; set; }

    /// <summary>
    /// Id Личного имени, для которого данное ФИО представлено в предложном падеже.
    /// Внешний ключ
    /// </summary>
    public int IdPrepositional { get; set; }
    /// <summary>
    /// Личное имя, для которого данное ФИО представлено в предложном падеже.
    /// </summary>
    public CaseName? Prepositional { get; set; }


    /// <summary>
    /// Возвращает полное имя пользователя
    /// </summary>
    /// <returns>
    /// Cтрока вида "Фамилия Имя Отчество"
    /// </returns>
    public string GetFullName() =>
        Regex.Replace($"{LastName} {FirstName} {MiddleName}".Trim(), @"\s{2,}", "", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

    /// <summary>
    /// Возвращает короткую форму имени пользователя
    /// </summary>
    /// <returns>
    /// Cтрока вида "ФИО"
    /// </returns>
    public string GetShortName() =>
        $"{LastName.FirstOrDefault()}{FirstName.FirstOrDefault()}{MiddleName.FirstOrDefault()}".Trim();
}
