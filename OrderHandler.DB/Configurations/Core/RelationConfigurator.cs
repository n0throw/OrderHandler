using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace OrderHandler.DB.Configurations.Core;

class RelationConfigurator : IRelationConfigurator {
    public void OTMConfigureRelation<TBaseEntity, TSecondEntity>(
        EntityTypeBuilder<TBaseEntity> builder,
        Expression<Func<TBaseEntity, IEnumerable<TSecondEntity>?>> hasNavigationExpression,
        Expression<Func<TSecondEntity, TBaseEntity?>> withNavigationExpression,
        Expression<Func<TSecondEntity, object?>> foreignKeyExpression,
        DeleteBehavior deleteBehavior = DeleteBehavior.NoAction
    ) where TBaseEntity : class
      where TSecondEntity : class => builder
        .HasMany(hasNavigationExpression)
        .WithOne(withNavigationExpression)
        .HasForeignKey(foreignKeyExpression)
        .OnDelete(deleteBehavior);

    public void OTOConfigureRelation<TBaseEntity, TSecondEntity>(
        EntityTypeBuilder<TBaseEntity> builder,
        Expression<Func<TBaseEntity, TSecondEntity?>> hasNavigationExpression,
        Expression<Func<TSecondEntity, TBaseEntity?>> withNavigationExpression,
        Expression<Func<TSecondEntity, object?>> foreignKeyExpression,
        DeleteBehavior deleteBehavior = DeleteBehavior.NoAction
    ) where TBaseEntity : class
      where TSecondEntity : class => builder
        .HasOne(hasNavigationExpression)
        .WithOne(withNavigationExpression)
        .HasForeignKey(foreignKeyExpression)
        .OnDelete(deleteBehavior);
}
