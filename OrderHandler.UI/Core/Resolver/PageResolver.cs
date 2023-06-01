using System;
using System.Windows.Controls;
using System.Collections.Generic;

using OrderHandler.UI.Pages;

namespace OrderHandler.UI.Core.Resolver;

public sealed class PageResolver : Resolver<Page> {
    const string DefaultPageName = nameof(ErrorPage);
    protected override string DefaultInstance => DefaultPageName;
    protected override string DefaultPostfixAlias => string.Empty;

    public PageResolver() : base(new Dictionary<string, Func<Page>>()
    {
        { nameof(Login), () => new Login() },
        { nameof(ErrorPage), () => new ErrorPage() },
        { nameof(OrderManager), () => new OrderManager() },
        { nameof(MainMenu), () => new MainMenu() }
    }) { }
}