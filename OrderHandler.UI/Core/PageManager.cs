#region System_Using
using System;
using System.Windows.Controls;
#endregion System_Using

#region OrderHandler_Using
using OrderHandler.UI.Core.Resolver;
#endregion OrderHandler_Using

namespace OrderHandler.UI.Core;

internal class PageManager
{
    private readonly ContextResolver contextResolver;
    private readonly PageResolver pageResolver;
    private Page? currentPage = null;

    internal delegate void UpdateCurrentPageHandler(Page page);

    internal event UpdateCurrentPageHandler? UpdateCurrentPage;

    internal PageManager(UpdateCurrentPageHandler updateCurrentPageHandler)
    {
        contextResolver = new();
        pageResolver = new();
        UpdateCurrentPage += updateCurrentPageHandler;
    }

    internal Page SetFirstPage(string alias)
    {
        if (currentPage is null)
        {
            currentPage = this[alias];
            return currentPage;
        }
        throw new NotImplementedException();
    }

    private Page this[string? alias]
    {
        get
        {
            Page page = pageResolver.GetInstance(alias);
            PropertyChanger context = contextResolver.GetInstance(alias);
            
            context.TurnPage += SetPage;

            page.DataContext = context;

            currentPage = page;

            return page;
        }
    }

    private void SetPage(string? alias)
    {
        currentPage = this[alias];
        UpdateCurrentPage?.Invoke(currentPage);
    }
}