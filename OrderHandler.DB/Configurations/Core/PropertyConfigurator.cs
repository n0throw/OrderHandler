using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;

namespace OrderHandler.DB.Configurations.Core;

/// <summary>
/// Класс для конфигурации столбцов таблиц в БД
/// </summary>
public class PropertyConfigurator : IPropertyConfigurator {
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
    ) where TBaseEntity : class {
        PropertyBuilder propBuilder = builder.Property(propertyExpression);
        if (columnName is not null)
            propBuilder = propBuilder.HasColumnName(columnName);
        if (comment is not null)
            propBuilder = propBuilder.HasComment(comment);
        if (isRequired is not null)
            propBuilder = propBuilder.IsRequired((bool)isRequired);
        if (maxLength is not null)
            propBuilder = propBuilder.HasMaxLength((int)maxLength);
        if (isUnicode is not null)
            propBuilder = propBuilder.IsUnicode((bool)isUnicode);
        if (precision is not null)
            propBuilder = propBuilder.HasPrecision(precision.Value.Item1, precision.Value.Item2);
        if (columnType is not null)
            _ = propBuilder.HasColumnType(columnType);
    }
}
