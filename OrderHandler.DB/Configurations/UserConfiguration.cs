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
        // todo комментарии к свойствам закомментил пока, так как падает, потому что навигационных свойств нет в бд. Комменты нужно юзать на idшках в зависимых классах, нужно будет для них конфигурационные классы так же написать 
        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.OrderMain,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Основной информации"
        // );
        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.DocConst,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.DocConst,
        //     comment: "Id Документации конструктора"
        // );

        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.DocTech,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.DocTech,
        //     comment: "Id Документации технолога"
        // );
        
        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.Supply,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.Supply,
        //     comment: "Id Снабжения"
        // );
        
        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.SawCenter,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.SawCenter,
        //     comment: "Id Пильного центра"
        // );

        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.Edge,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.Edge,
        //     comment: "Id Кромки"
        // );

        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.Additive,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.Additive,
        //     comment: "Id Присадки"
        // );

        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.Milling,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.Milling,
        //     comment: "Id Фрезеровки"
        // );

        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.Grinding,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.Grinding,
        //     comment: "Id Шлифовки"
        // );

        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.Press,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Пресса"
        // );

        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.Assembling,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Сборки"
        // );

        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.Packing,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Упаковки"
        // );

        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.Equipment,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Комплектации"
        // );

        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.Shipment,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Отгрузки"
        // );
        relationConfigurator.OTMConfigureRelation(
            builder,
            e => e.Mounting,
            e => e.User,
            e => e.UserId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Монтажа"
        // );
    }

    protected void ConfigureOneToOne(EntityTypeBuilder<User> builder) {
        relationConfigurator.OTOConfigureRelation(builder, e => e.Profile, e => e.User, e => e.IdUser);
        // todo комментарии к свойствам закомментил пока, так как падает, потому что навигационных свойств нет в бд. Комменты нужно юзать на idшках в зависимых классах, нужно будет для них конфигурационные классы так же написать 
        //propertyConfigurator.ConfigureProperty(builder, e => e.Profile, comment: "Id ФИО пользователея во всех склонениях");
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
        // todo комментарии к свойствам закомментил пока, так как падает, потому что навигационных свойств нет в бд. Комменты нужно юзать на idшках в зависимых классах, нужно будет для них конфигурационные классы так же написать 
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     hasNavigationExpression,
        //     comment: comment
        // );
    }
}