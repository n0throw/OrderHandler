using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using OrderHandler.DB.Data;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.DB.Configurations.Core;

namespace OrderHandler.DB.Configurations;

/// <summary>
/// Класс для конфигурации таблицы Заказ пользователя (<see cref="Order" />)
/// </summary>
public class OrderConfiguration : IEntityTypeConfiguration<Order> {
    private readonly IRelationConfigurator relationConfigurator;
    private readonly IPropertyConfigurator propertyConfigurator;

    /// <summary>
    /// Конструктор.
    /// Создаёт конфигураторы отношений (<see cref="IRelationConfigurator" />) и свойства (<see cref="IPropertyConfigurator" />) таблиц
    /// </summary>
    public OrderConfiguration() {
        relationConfigurator = new RelationConfigurator();
        propertyConfigurator = new PropertyConfigurator();
    }

    /// <summary>
    /// Настраивает объект типа <see cref="Order" />.
    /// </summary>
    /// <param name="builder">Конструктор, который будет использоваться для настройки типа объекта.</param>
    public void Configure(EntityTypeBuilder<Order> builder) {
        // todo комментарии к свойствам закомментил пока, так как падает, потому что навигационных свойств нет в бд. Комменты нужно юзать на idшках в зависимых классах, нужно будет для них конфигурационные классы так же написать 
        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.OrderMain,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Основной информации"
        // );
        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.DocConst,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.DocConst,
        //     comment: "Id Документации конструктора"
        // );

        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.DocTech,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.DocTech,
        //     comment: "Id Документации технолога"
        // );
        
        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.Supply,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.Supply,
        //     comment: "Id Снабжения"
        // );
        
        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.SawCenter,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.SawCenter,
        //     comment: "Id Пильного центра"
        // );

        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.Edge,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.Edge,
        //     comment: "Id Кромки"
        // );

        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.Additive,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.Additive,
        //     comment: "Id Присадки"
        // );

        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.Milling,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.Milling,
        //     comment: "Id Фрезеровки"
        // );

        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.Grinding,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.Grinding,
        //     comment: "Id Шлифовки"
        // );

        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.Press,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Пресса"
        // );

        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.Assembling,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Сборки"
        // );

        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.Packing,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Упаковки"
        // );

        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.Equipment,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Комплектации"
        // );

        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.Shipment,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Отгрузки"
        // );
        propertyConfigurator.ConfigureProperty(builder, u => u.Note, comment: "Примечание");
        relationConfigurator.OTOConfigureRelation(
            builder,
            e => e.Mounting,
            e => e.Order,
            e => e.OrderId
        );
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     e => e.OrderMain,
        //     comment: "Id Монтажа"
        // );
    }

    /// <summary>
    /// Конфигурация отношений и свойства таблицы <see cref="Order" />
    /// </summary>
    /// <param name="builder">Конструктор, который будет использоваться для настройки типа объекта.</param>
    /// <param name="comment">Комментарий к свойству таблицы</param>
    protected void OTOConfigureRelationAndProperty(
        EntityTypeBuilder<Order> builder,
        Expression<Func<Order, OrderGeneric?>> hasNavigationExpression,
        string comment
    ) {
        relationConfigurator.OTOConfigureRelation(
            builder,
            hasNavigationExpression,
            e => e.Order,
            e => e.OrderId
        );
        // todo комментарии к свойствам закомментил пока, так как падает, потому что навигационных свойств нет в бд. Комменты нужно юзать на idшках в зависимых классах, нужно будет для них конфигурационные классы так же написать 
        // propertyConfigurator.ConfigureProperty(
        //     builder,
        //     hasNavigationExpression,
        //     comment: comment
        // );
    }
}