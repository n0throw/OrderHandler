#region System_Using
using System;
using System.Windows.Controls;
using System.Collections.Generic;
#endregion System_Using

#region OrderHandler_Using
using OrderHandler.UI.Pages;
using OrderHandler.UI.Pages.Tables;
#endregion OrderHandler_Using

namespace OrderHandler.UI.Core.Resolver;

internal sealed class PageResolver : Resolver<Page>
{
    private const string DefaultPageName = "DefaultPage";
    internal override string DefaultInstance => DefaultPageName;
    protected override string DefaultPostfixAlias => string.Empty;

    internal PageResolver() : base(new Dictionary<string, Func<Page>>()
    {
        { nameof(Login), () => new Login() },
        { nameof(DefaultPage), () => new DefaultPage() },
        { nameof(TableOrderManager), () => new TableOrderManager() }
    })
    { }
}