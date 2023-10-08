using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

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
    
    [Column("sNominativeLastName")]
    public string NominativeLastName { get; set; }
    [Column("sNominativeFirstName")]
    public string NominativeFirstName { get; set; }
    [Column("sNominativeMiddleName")]
    public string NominativeMiddleName { get; set; }
    
    [Column("sGenitiveLastName")]
    public string GenitiveLastName { get; set; }
    [Column("sGenitiveFirstName")]
    public string GenitiveFirstName { get; set; }
    [Column("sGenitiveMiddleName")]
    public string GenitiveMiddleName { get; set; }
    
    [Column("sDativeLastName")]
    public string DativeLastName { get; set; }
    [Column("sDativeFirstName")]
    public string DativeFirstName { get; set; }
    [Column("sDativeMiddleName")]
    public string DativeMiddleName { get; set; }
    
    [Column("sAccusativeLastName")]
    public string AccusativeLastName { get; set; }
    [Column("sAccusativeFirstName")]
    public string AccusativeFirstName { get; set; }
    [Column("sAccusativeMiddleName")]
    public string AccusativeMiddleName { get; set; }
    
    [Column("sAblativeLastName")]
    public string AblativeLastName { get; set; }
    [Column("sAblativeFirstName")]
    public string AblativeFirstName { get; set; }
    [Column("sAblativeMiddleName")]
    public string AblativeMiddleName { get; set; }
    
    [Column("sPrepositionalLastName")]
    public string PrepositionalLastName { get; set; }
    [Column("sPrepositionalFirstName")]
    public string PrepositionalFirstName { get; set; }
    [Column("sPrepositionalMiddleName")]
    public string PrepositionalMiddleName { get; set; }

    public ICollection<UserInfo> UserInfos { get; set; } = new List<UserInfo>();
    
    public CaseName(
        string nominativeLastName,
        string nominativeFirstName,
        string nominativeMiddleName
    ) : this(
        nominativeLastName,
        nominativeFirstName,
        nominativeMiddleName,
        nominativeLastName,
        nominativeFirstName,
        nominativeMiddleName,
        nominativeLastName,
        nominativeFirstName,
        nominativeMiddleName,
        nominativeLastName,
        nominativeFirstName,
        nominativeMiddleName,
        nominativeLastName,
        nominativeFirstName,
        nominativeMiddleName,
        nominativeLastName,
        nominativeFirstName,
        nominativeMiddleName
    ) { }
    
    public CaseName(
        string nominativeLastName,
        string nominativeFirstName,
        string nominativeMiddleName,
        string genitiveLastName,
        string genitiveFirstName,
        string genitiveMiddleName,
        string dativeLastName,
        string dativeFirstName,
        string dativeMiddleName,
        string accusativeLastName,
        string accusativeFirstName,
        string accusativeMiddleName,
        string ablativeLastName,
        string ablativeFirstName,
        string ablativeMiddleName,
        string prepositionalLastName,
        string prepositionalFirstName,
        string prepositionalMiddleName
    ) {
        NominativeLastName = nominativeLastName;
        NominativeFirstName = nominativeFirstName;
        NominativeMiddleName = nominativeMiddleName;
        GenitiveLastName = genitiveLastName;
        GenitiveFirstName = genitiveFirstName;
        GenitiveMiddleName = genitiveMiddleName;
        DativeLastName = dativeLastName;
        DativeFirstName = dativeFirstName;
        DativeMiddleName = dativeMiddleName;
        AccusativeLastName = accusativeLastName;
        AccusativeFirstName = accusativeFirstName;
        AccusativeMiddleName = accusativeMiddleName;
        AblativeLastName = ablativeLastName;
        AblativeFirstName = ablativeFirstName;
        AblativeMiddleName = ablativeMiddleName;
        PrepositionalLastName = prepositionalLastName;
        PrepositionalFirstName = prepositionalFirstName;
        PrepositionalMiddleName = prepositionalMiddleName;
    }
    
    /// <summary>
    /// Возвращает полное имя пользователя
    /// </summary>
    /// <returns>
    /// Cтрока вида "Фамилия Имя Отчество"
    /// </returns>
    public string GetFullRecordName() =>RemoveTwoMoreSpace.Replace(
        $"{NominativeLastName} {NominativeFirstName} {NominativeMiddleName}".Trim(), 
        ""
    );

    /// <summary>
    /// Возвращает среднюю форму имени пользователя
    /// </summary>
    /// <returns>Строка вида "Фамилия И.О."</returns>
    public string GerMiddleRecordName() => RemoveTwoMoreSpace.Replace(
        $"{NominativeLastName} {NominativeFirstName.FirstOrDefault()}.{NominativeMiddleName.FirstOrDefault()}.".Trim(), 
        ""
    );
    
    /// <summary>
    /// Возвращает короткую форму имени пользователя
    /// </summary>
    /// <returns>
    /// Cтрока вида "ФИО"
    /// </returns>
    public string GetShortRecordName() =>
        $"{NominativeLastName.FirstOrDefault()}{NominativeFirstName.FirstOrDefault()}{NominativeMiddleName.FirstOrDefault()}".Trim();

    static readonly Regex RemoveTwoMoreSpace = new(
        "\\s{2,}",
        RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace
    );
}
