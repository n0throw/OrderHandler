using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace OrderHandler.DB.Configurations.Core;

/// <summary>
/// Общий интерфейс для конфигурации отношения таблиц в БД.
/// </summary>
public interface IRelationConfigurator {

    /// <summary>
    /// Настройка отношения между таблицами.
    /// Используется для настройки отношения один к одному
    /// </summary>
    /// <typeparam name="TBaseEntity">Таблица, в которой настраиваются отношения</typeparam>
    /// <typeparam name="TSecondEntity">Таблица, к которой настраиваются отношения</typeparam>
    /// <param name="builder">Конструктор, который будет использоваться для настройки типа объекта</param>
    /// <param name="hasNavigationExpression">Лямбда-выражение, представляющее ссылочное свойство навигации на зависимую таблицу</param>
    /// <param name="withNavigationExpression">Лямбда-выражение, представляющее ссылочное свойство навигации из зависимой таблицы</param>
    /// <param name="foreignKeyExpression">Внешний ключ</param>
    /// <param name="deleteBehavior">Поведение при удалении</param>
    public void OTOConfigureRelation<TBaseEntity, TSecondEntity>(
        EntityTypeBuilder<TBaseEntity> builder,
        Expression<Func<TBaseEntity, TSecondEntity?>> hasNavigationExpression,
        Expression<Func<TSecondEntity, TBaseEntity?>> withNavigationExpression,
        Expression<Func<TSecondEntity, object?>> foreignKeyExpression,
        DeleteBehavior deleteBehavior = DeleteBehavior.NoAction
    ) where TBaseEntity : class
      where TSecondEntity : class;

    /// <summary>
    /// Настройка отношения между таблицами.
    /// Используется для настройки отношения один ко многим
    /// </summary>
    /// <typeparam name="TRelataedEntity">Тип связанной таблицы</typeparam>
    /// <param name="builder">Конфигуратор таблицы</param>
    /// <param name="hasNavigationExpression">Лямбда-выражение, представляющее ссылочное свойство навигации к таблице</param>
    /// <param name="withNavigationExpression">Лямбда-выражение, представляющее ссылочное свойство навигации из зависимой таблицы</param>
    /// <param name="foreignKeyExpression">Внешний ключ</param>
    /// <param name="deleteBehavior">Поведение при удалении</param>
    public void OTMConfigureRelation<TBaseEntity, TSecondEntity>(
        EntityTypeBuilder<TBaseEntity> builder,
        Expression<Func<TBaseEntity, IEnumerable<TSecondEntity>?>> hasNavigationExpression,
        Expression<Func<TSecondEntity, TBaseEntity?>> withNavigationExpression,
        Expression<Func<TSecondEntity, object?>> foreignKeyExpression,
        DeleteBehavior deleteBehavior = DeleteBehavior.NoAction
    ) where TBaseEntity : class
      where TSecondEntity : class;
}