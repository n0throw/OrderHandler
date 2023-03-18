using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OrderHandler.UI.Core.Resolver;

public abstract class Resolver<T> : IResolver<T> {
    private readonly ReadOnlyDictionary<string, Func<T>> contexts;
    public abstract string DefaultInstance { get; }
    protected abstract string DefaultPostfixAlias { get; }

    protected Resolver(IDictionary<string, Func<T>> contexts) =>
        this.contexts = new(contexts);

    public T GetInstance(string? alias) {
        if (alias is null)
            alias = DefaultInstance;
        else
            alias = $"{alias}{DefaultPostfixAlias}";

        if (!contexts.ContainsKey(alias))
            alias = DefaultInstance;

        return contexts[alias]();
    }
}