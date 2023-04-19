using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
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
        OTOConfigureRelationAndProperty(builder, e => e.OrderMain, comment: "Id Основной информации");
        OTOConfigureRelationAndProperty(builder, e => e.DocConst, comment: "Id Документации конструктора");
        OTOConfigureRelationAndProperty(builder, e => e.DocTech, comment: "Id Документации технолога");
        OTOConfigureRelationAndProperty(builder, e => e.Supply, comment: "Id Снабжения");
        OTOConfigureRelationAndProperty(builder, e => e.SawCenter, comment: "Id Пильного центра");
        OTOConfigureRelationAndProperty(builder, e => e.Edge, comment: "Id Кромки");
        OTOConfigureRelationAndProperty(builder, e => e.Additive, comment: "Id Присадки");
        OTOConfigureRelationAndProperty(builder, e => e.Milling, comment: "Id Фрезеровки");
        OTOConfigureRelationAndProperty(builder, e => e.Grinding, comment: "Id Шлифовки");
        OTOConfigureRelationAndProperty(builder, e => e.Press, comment: "Id Пресса");
        OTOConfigureRelationAndProperty(builder, e => e.Assembling, comment: "Id Сборки");
        OTOConfigureRelationAndProperty(builder, e => e.Packing, comment: "Id Упаковки");
        OTOConfigureRelationAndProperty(builder, e => e.Equipment, comment: "Id Комплектации");
        OTOConfigureRelationAndProperty(builder, e => e.Shipment, comment: "Id Отгрузки");
        propertyConfigurator.ConfigureProperty(builder, u => u.Note, comment: "Примечание");
        OTOConfigureRelationAndProperty(builder, e => e.Mounting, comment: "Id Монтажа");
    }

    /// <summary>
    /// Конфигурация отношений и свойства таблицы <see cref="Order" />
    /// </summary>
    /// <param name="builder">Конструктор, который будет использоваться для настройки типа объекта.</param>
    /// <param name="comment">Комментарий к свойству таблицы</param>
    protected void OTOConfigureRelationAndProperty(
        EntityTypeBuilder<Order> builder,
        Expression<Func<Order, OrderAddConfigureBase?>> hasNavigationExpression,
        string comment
    ) {
        relationConfigurator.OTOConfigureRelation(
            builder,
            hasNavigationExpression,
            e => e.Order,
            e => e.OrderId
        );
        propertyConfigurator.ConfigureProperty(
            builder,
            hasNavigationExpression,
            comment: comment
        );
    }
}