using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
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
        var getComment = (string fkCaseName) => $"Личное имя, для которого данное ФИО представлено в {fkCaseName} падеже.";
        OTOConfigureRelationAndProperty(
            builder,
            e => e.Nominative,
            e => e.Nominative,
            e => e.IdNominative,
            getComment("именительном")
        );
        OTOConfigureRelationAndProperty(
            builder,
            e => e.Genitive,
            e => e.Genitive,
            e => e.IdGenitive,
            getComment("родительном")
        );
        OTOConfigureRelationAndProperty(
            builder,
            e => e.Dative,
            e => e.Dative,
            e => e.IdDative,
            getComment("дательном")
        );
        OTOConfigureRelationAndProperty(
            builder,
            e => e.Accusative,
            e => e.Accusative,
            e => e.IdAccusative,
            getComment("винительонм")
        );
        OTOConfigureRelationAndProperty(
            builder,
            e => e.Ablative,
            e => e.Ablative,
            e => e.IdAblative,
            getComment("творительном")
        );
        OTOConfigureRelationAndProperty(
            builder,
            e => e.Prepositional,
            e => e.Prepositional,
            e => e.IdPrepositional,
            getComment("предложном")
        );
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
        propertyConfigurator.ConfigureProperty(
            builder,
            hasNavigationExpression,
            comment: comment
        );
    }
}