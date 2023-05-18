using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using OrderHandler.DB.Configurations.Core;
using OrderHandler.DB.Data.UserAdd;

namespace OrderHandler.DB.Configurations;
/// <summary>
/// Класс для конфигурации таблицы Личного имени пользователя (<see cref="CaseName" />)
/// </summary>
public class CaseNameConfiguration : IEntityTypeConfiguration<CaseName> {
    private readonly IRelationConfigurator relationConfigurator;
    private readonly IPropertyConfigurator propertyConfigurator;

    /// <summary>
    /// Конструктор.
    /// Создаёт конфигураторы отношений (<see cref="IRelationConfigurator" />) и свойства (<see cref="IPropertyConfigurator" />) таблиц
    /// </summary>
    public CaseNameConfiguration() {
        relationConfigurator = new RelationConfigurator();
        propertyConfigurator = new PropertyConfigurator();
    }

    /// <summary>
    /// Настраивает объект типа <see cref="CaseName" />.
    /// </summary>
    /// <param name="builder">Конструктор, который будет использоваться для настройки типа объекта.</param>
    public void Configure(EntityTypeBuilder<CaseName> builder) {
        // todo комментарии к свойствам закомментил пока, так как падает, потому что навигационных свойств нет в бд. Комменты нужно юзать на idшках в зависимых классах, нужно будет для них конфигурационные классы так же написать 
        // var getComment = (string fkCaseName) => $"Личное имя, для которого данное ФИО представлено в {fkCaseName} падеже.";
        builder.OwnsOne(u => u.Nominative);
        builder.OwnsOne(u => u.Genitive);
        builder.OwnsOne(u => u.Dative);
        builder.OwnsOne(u => u.Accusative);
        builder.OwnsOne(u => u.Ablative);
        builder.OwnsOne(u => u.Prepositional);
    }

    /// <summary>
    /// Конфигурация отношений и свойства таблицы <see cref="CaseName" />
    /// </summary>
    /// <param name="builder">Конструктор, который будет использоваться для настройки типа объекта.</param>
    /// <param name="hasNavigationExpression">Лямбда-выражение, представляющее ссылочное свойство навигации на зависимую таблицу</param>
    /// <param name="withNavigationExpression">Лямбда-выражение, представляющее ссылочное свойство навигации из зависимой таблицы</param>
    /// <param name="foreignKeyExpression">Внешний ключ</param>
    /// <param name="comment">Комментарий к свойству таблицы</param>
    protected void OTOConfigureRelationAndProperty(
        EntityTypeBuilder<CaseName> builder,
        Expression<Func<CaseName, GivenName?>> hasNavigationExpression,
        Expression<Func<GivenName, CaseName?>> withNavigationExpression,
        Expression<Func<GivenName, object?>> foreignKeyExpression,
        string comment
    ) {
        relationConfigurator.OTOConfigureRelation(
            builder,
            hasNavigationExpression,
            withNavigationExpression,
            foreignKeyExpression
        );
        // todo комментарии к свойствам закомментил пока, так как падает, потому что навигационных свойств нет в бд. Комменты нужно юзать на idшках в зависимых классах, нужно будет для них конфигурационные классы так же написать 
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     hasNavigationExpression,
        //     comment: comment
        // );
    }
}