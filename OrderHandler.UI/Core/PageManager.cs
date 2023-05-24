using System.Windows.Controls;

using OrderHandler.UI.Core.Resolver;

namespace OrderHandler.UI.Core;

public class PageManager {
    readonly ContextResolver _contextResolver;
    readonly PageResolver _pageResolver;
    Page? _currentPage;

    public delegate void UpdateCurrentPageHandler(Page page);
    public event UpdateCurrentPageHandler? UpdateCurrentPage;

    public PageManager(UpdateCurrentPageHandler updateCurrentPageHandler) {
        _contextResolver = new();
        _pageResolver = new();
        UpdateCurrentPage += updateCurrentPageHandler;
    }

    public Page SetFirstPage(string alias) {
        _currentPage ??= this[alias];
        return _currentPage;
    }

    Page this[string? alias] {
        get {
            var page = _pageResolver.GetInstance(alias);
            var context = _contextResolver.GetInstance(alias);

            context.TurnPage += SetPage;
            page.DataContext = context;
            _currentPage = page;

            return page;
        }
    }

    void SetPage(string? alias) {
        _currentPage = this[alias];
        UpdateCurrentPage?.Invoke(_currentPage);
    }
}