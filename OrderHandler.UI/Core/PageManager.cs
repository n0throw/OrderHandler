using System.Windows.Controls;
using OrderHandler.UI.Core.Resolver;

namespace OrderHandler.UI.Core;

public class PageManager {
    private readonly ContextResolver contextResolver;
    private readonly PageResolver pageResolver;
    private Page? currentPage = null;

    public delegate void UpdateCurrentPageHandler(Page page);
    public event UpdateCurrentPageHandler? UpdateCurrentPage;

    public PageManager(UpdateCurrentPageHandler updateCurrentPageHandler) {
        contextResolver = new();
        pageResolver = new();
        UpdateCurrentPage += updateCurrentPageHandler;
    }

    public Page SetFirstPage(string alias) {
        currentPage ??= this[alias];
        return currentPage;
    }

    private Page this[string? alias] {
        get {
            Page page = pageResolver.GetInstance(alias);
            PropertyChanger context = contextResolver.GetInstance(alias);

            context.TurnPage += SetPage;
            page.DataContext = context;
            currentPage = page;

            return page;
        }
    }

    private void SetPage(string? alias) {
        currentPage = this[alias];
        UpdateCurrentPage?.Invoke(currentPage);
    }
}