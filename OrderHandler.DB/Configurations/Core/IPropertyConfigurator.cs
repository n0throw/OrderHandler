using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace OrderHandler.DB.Configurations.Core;

/// <summary>
/// Общий интерфейс для конфигурации столбцов таблиц в БД
/// </summary>
public interface IPropertyConfigurator {
    /// <summary>
    /// Настраивает столбец в таблице
    /// </summary>
    /// <typeparam name="TProp">Стобец</typeparam>
    /// <typeparam name="TBaseEntity">Таблица, в которой настраиваются столбцы</typeparam>
    /// <param name="builder">Конструктор, который будет использоваться для настройки типа объекта</param>
    /// <param name="propertyExpression">Лямбда-выражение, представляющее ссылочное свойство на столбец</param>
    /// <param name="columnName">Имя столбца в БД</param>
    /// <param name="comment">Комментарий к свойству таблицы</param>
    /// <param name="isRequired">Обязательный для заполнения параметр</param>
    /// <param name="maxLength">Максимальная длина строки(Только для строковых типов данных)</param>
    /// <param name="isUnicode">Хранить строку в кодировке Unicode</param>
    /// <param name="precision">Точность (Только для decimal)</param>
    /// <param name="columnType">Ручная настройка типа столбца</param>
    public void ConfigureProperty<TBaseEntity, TProp>(
        EntityTypeBuilder<TBaseEntity> builder,
        Expression<Func<TBaseEntity, TProp?>> propertyExpression,
        string? columnName = null,
        string? comment = null,
        bool? isRequired = null,
        int? maxLength = null,
        bool? isUnicode = null,
        (int, int)? precision = null,
        string? columnType = null
    ) where TBaseEntity : class;
}