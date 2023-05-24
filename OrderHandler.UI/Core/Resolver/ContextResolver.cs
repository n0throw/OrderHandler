using System;
using System.Collections.Generic;

using OrderHandler.UI.Contexts;
using OrderHandler.UI.Core.Service.File;
using OrderHandler.UI.Core.Service.Dialog;
using OrderHandler.UI.Contexts.CommandsImpl;

namespace OrderHandler.UI.Core.Resolver;

public class ContextResolver : Resolver<PropertyChanger> {
    const string DefaultContext = "DefaultPageContext";
    const string PostfixAlias = "Context";

    protected override string DefaultInstance => DefaultContext;
    protected override string DefaultPostfixAlias => PostfixAlias;

    public ContextResolver() : base(new Dictionary<string, Func<PropertyChanger>>()
    {
        { nameof(LoginContext), () => new LoginContext() },
        { nameof(DefaultPageContext), () => new DefaultPageContext() },
        { nameof(TableOrderManagerContext), () => new TableOrderManagerContext(new TableOrderManagerCommandsImpl(new DialogService(), new ExcelOrderFileService())) }
    }) { }
}