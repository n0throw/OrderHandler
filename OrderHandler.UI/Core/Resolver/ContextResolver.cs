using System;
using System.Collections.Generic;
using OrderHandler.UI.Contexts;
using OrderHandler.UI.Contexts.CommandsImpl;
using OrderHandler.UI.Core.Service.Dialog;
using OrderHandler.UI.Core.Service.File;

namespace OrderHandler.UI.Core.Resolver;

public class ContextResolver : Resolver<PropertyChanger> {
    private const string DefaultContext = "DefaultPageContext";
    private const string postfixAlias = "Context";

    public override string DefaultInstance => DefaultContext;
    protected override string DefaultPostfixAlias => postfixAlias;

    public ContextResolver() : base(new Dictionary<string, Func<PropertyChanger>>()
    {
        { nameof(LoginContext), () => new LoginContext() },
        { nameof(DefaultPageContext), () => new DefaultPageContext() },
        { nameof(TableOrderManagerContext), () => new TableOrderManagerContext(new TableOrderManagerCommandsImpl(new DialogService(), new ExcelOrderFileService())) }
    }) { }
}