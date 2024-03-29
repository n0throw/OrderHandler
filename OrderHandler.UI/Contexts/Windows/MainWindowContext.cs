﻿using System.Windows.Controls;
using System.Windows.Navigation;

using OrderHandler.UI.Core;

namespace OrderHandler.UI.Contexts.Windows;

public class MainWindowContext : MainPagePropertyChanger {
    readonly NavigationService _navigationService;

    public MainWindowContext(NavigationService navigationService) {
        _navigationService = navigationService;
        PageManager pageManager = new(Navigate);
        Navigate(pageManager.SetFirstPage("Login"));
    }

    void Navigate(Page page) =>
        _navigationService.Navigate(page);
}
