using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using OrderHandler.DB.Data;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.DB.Configurations.Core;

namespace OrderHandler.DB.Configurations;
/// <summary>
/// Класс для конфигурации таблицы Пользователь (<see cref="User" />)
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User> {
    private readonly IRelationConfigurator relationConfigurator;
    private readonly IPropertyConfigurator propertyConfigurator;

    /// <summary>
    /// Конструктор.
    /// Создаёт конфигураторы отношений (<see cref="IRelationConfigurator" />) и свойства (<see cref="IPropertyConfigurator" />) таблиц
    /// </summary>
    public UserConfiguration() {
        relationConfigurator = new RelationConfigurator();
        propertyConfigurator = new PropertyConfigurator();
    }

    /// <summary>
    /// Настраивает объект типа <see cref="User" />.
    /// </summary>
    /// <param name="builder">Конструктор, который будет использоваться для настройки типа объекта.</param>
    public void Configure(EntityTypeBuilder<User> builder) {
        ConfigureOneToMany(builder);
        ConfigureOneToOne(builder);
    }

    protected void ConfigureOneToMany(EntityTypeBuilder<User> builder) {
        OTMConfigureRelationAndProperty(builder, e => e.OrderMain, comment: "Id Основной информации");
        OTMConfigureRelationAndProperty(builder, e => e.DocConst, comment: "Id Документации конструктора");
        OTMConfigureRelationAndProperty(builder, e => e.DocTech, comment: "Id Документации технолога");
        OTMConfigureRelationAndProperty(builder, e => e.Supply, comment: "Id Снабжения");
        OTMConfigureRelationAndProperty(builder, e => e.SawCenter, comment: "Id Пильного центра");
        OTMConfigureRelationAndProperty(builder, e => e.Edge, comment: "Id Кромки");
        OTMConfigureRelationAndProperty(builder, e => e.Additive, comment: "Id Присадки");
        OTMConfigureRelationAndProperty(builder, e => e.Milling, comment: "Id Фрезеровки");
        OTMConfigureRelationAndProperty(builder, e => e.Grinding, comment: "Id Шлифовки");
        OTMConfigureRelationAndProperty(builder, e => e.Press, comment: "Id Пресса");
        OTMConfigureRelationAndProperty(builder, e => e.Assembling, comment: "Id Сборки");
        OTMConfigureRelationAndProperty(builder, e => e.Packing, comment: "Id Упаковки");
        OTMConfigureRelationAndProperty(builder, e => e.Equipment, comment: "Id Комплектации");
        OTMConfigureRelationAndProperty(builder, e => e.Shipment, comment: "Id Отгрузки");
        OTMConfigureRelationAndProperty(builder, e => e.Mounting, comment: "Id Монтажа");
    }

    protected void ConfigureOneToOne(EntityTypeBuilder<User> builder) {
        relationConfigurator.OTOConfigureRelation(builder, e => e.Profile, e => e.User, e => e.IdUser);
        propertyConfigurator.ConfigureProperty(builder, e => e.Profile, comment: "Id ФИО пользователея во всех склонениях");
    }

    /// <summary>
    /// Конфигурация отношений и свойства таблицы <see cref="User" />
    /// </summary>
    /// <param name="builder">Конструктор, который будет использоваться для настройки типа объекта.</param>
    /// <param name="comment">Комментарий к свойству таблицы</param>
    protected void OTMConfigureRelationAndProperty(
        EntityTypeBuilder<User> builder,
        Expression<Func<User, IEnumerable<OrderGeneric>?>> hasNavigationExpression,
        string comment
    ) {
        relationConfigurator.OTMConfigureRelation(
            builder,
            hasNavigationExpression,
            e => e.User,
            e => e.UserId
        );
        propertyConfigurator.ConfigureProperty(
            builder,
            hasNavigationExpression,
            comment: comment
        );
    }
}