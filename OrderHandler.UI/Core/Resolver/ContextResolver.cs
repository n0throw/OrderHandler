#region System_Using
using System;
using System.Collections.Generic;
#endregion System_Using

#region OrderHandler_Using
using OrderHandler.UI.Contexts;
#endregion OrderHandler_Using

namespace OrderHandler.UI.Core.Resolver;

internal class ContextResolver : Resolver<PropertyChanger>
{
    private const string DefaultContext = "DefaultPageContext";
    private const string postfixAlias = "Context";
    internal override string DefaultInstance => DefaultContext;
    protected override string DefaultPostfixAlias => postfixAlias;

    internal ContextResolver() : base(new Dictionary<string, Func<PropertyChanger>>()
    {
        { nameof(LoginContext), () => new LoginContext() },
        { nameof(DefaultPageContext), () => new DefaultPageContext() },
        { nameof(TableOrderManagerContext), () => new TableOrderManagerContext() }
    })
    { }
}