using System;
using System.Windows.Controls;
using System.Collections.Generic;
using OrderHandler.UI.Pages;

namespace OrderHandler.UI.Core.Resolver;

public sealed class PageResolver : Resolver<Page> {
    private const string DefaultPageName = "DefaultPage";
    public override string DefaultInstance => DefaultPageName;
    protected override string DefaultPostfixAlias => string.Empty;

    public PageResolver() : base(new Dictionary<string, Func<Page>>()
    {
        { nameof(Login), () => new Login() },
        { nameof(DefaultPage), () => new DefaultPage() },
        { nameof(TableOrderManager), () => new TableOrderManager() }
    }) { }
}