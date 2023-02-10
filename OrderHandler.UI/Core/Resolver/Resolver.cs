#region System_Using
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
#endregion System_Using

#region OrderHandler_Using

#endregion OrderHandler_Using

namespace OrderHandler.UI.Core.Resolver;

internal abstract class Resolver<T> : IResolver<T>
{
    private readonly ReadOnlyDictionary<string, Func<T>> contexts;
    internal abstract string DefaultInstance { get; }
    protected abstract string DefaultPostfixAlias { get; }

    protected Resolver(IDictionary<string, Func<T>> contexts)
        => this.contexts = new(contexts);

    public T GetInstance(string? alias)
    {
        if (alias is null)
            alias = DefaultInstance;
        else
            alias = $"{alias}{DefaultPostfixAlias}";

        return contexts[alias]();
    }
}