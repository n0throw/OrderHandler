using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OrderHandler.UI.Core.Resolver;

public abstract class Resolver<T> : IResolver<T> {
    readonly ReadOnlyDictionary<string, Func<T>> _contexts;
    protected abstract string DefaultInstance { get; }
    protected abstract string DefaultPostfixAlias { get; }

    protected Resolver(IDictionary<string, Func<T>> contexts) =>
        _contexts = new(contexts);

    public T GetInstance(string? alias) {
        alias = alias is null ? DefaultInstance : $"{alias}{DefaultPostfixAlias}";

        if (!_contexts.ContainsKey(alias))
            alias = DefaultInstance;

        return _contexts[alias]();
    }
}