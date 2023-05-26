namespace OrderHandler.DB.Data.UserAdd;

/// <summary>
/// Класс CaseName.
/// Личное имя пользователя во всех падежах.
/// Модель БД.
/// </summary>
public class CaseName {
    /// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Личное имя, для которого данное ФИО представлено в именительном падеже.
    /// </summary>
    public GivenName Nominative { get; set; }
    /// <summary>
    /// Личное имя, для которого данное ФИО представлено в родительном падеже.
    /// </summary>
    public GivenName Genitive { get; set; }
    /// <summary>
    /// Личное имя, для которого данное ФИО представлено в дательном падеже.
    /// </summary>
    public GivenName Dative { get; set; }
    /// <summary>
    /// Личное имя, для которого данное ФИО представлено в винительонм падеже.
    /// </summary>
    public GivenName Accusative { get; set; }
    /// <summary>
    /// Личное имя, для которого данное ФИО представлено в творительном падеже.
    /// </summary>
    public GivenName Ablative { get; set; }
    /// <summary>
    /// Личное имя, для которого данное ФИО представлено в предложном падеже.
    /// </summary>
    public GivenName Prepositional { get; set; }

    /// <summary>
    /// Id Пользователя.
    /// Внешний ключ
    /// </summary>
    public long IdUser { get; set; }
    /// <summary>
    /// Пользователь.
    /// Внешний ключ
    /// </summary>
    public User? User { get; set; }
}
