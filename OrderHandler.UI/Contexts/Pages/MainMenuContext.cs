﻿using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using OrderHandler.UI.Core;
using OrderHandler.UI.Pages;
using OrderHandler.UI.Model.MainMenuAdd;

namespace OrderHandler.UI.Contexts.Pages; 

public class MainMenuContext : MainPagePropertyChanger {
	bool _isShowFavouritesSubAppSubApp;
	bool _isShowGenericSubApp;

	public MainMenuContext() {
		MenuNodes = new();
		FillMenuNodes();
	}

	public ObservableCollection<SubAppNode> MenuNodes { get; set; }

	public bool IsShowFavouritesSubApp {
		get => _isShowFavouritesSubAppSubApp;
		set {
			_isShowFavouritesSubAppSubApp = value;
			OnPropertyChanged();
		}
	}
	
	public bool IsShowGenericSubApp {
		get => _isShowGenericSubApp;
		set {
			_isShowGenericSubApp = value;
			OnPropertyChanged();
		}
	}

	// ---------- Меню страницы ----------
	// ---------- Статусы ----------
	RelayCommand? _showStatusWindowCommand;
	public RelayCommand ShowStatusWindowCommand =>
		_showStatusWindowCommand ??= new(obj => {
            
		}, null);
    
	RelayCommand? _returnToLoginScreen;
	public RelayCommand ReturnToLoginScreen =>
		_returnToLoginScreen ??= new(obj => {
            GoToPage(nameof(Login));
		}, null);
    
	// ---------- Настройки ----------
	RelayCommand? _showUserSettingsWindowCommand;
	public RelayCommand ShowUserSettingsWindowCommand =>
		_showUserSettingsWindowCommand ??= new(obj => {
			
		}, null);
	
	RelayCommand? _showAddSettingsWindowCommand;
	public RelayCommand ShowAddSettingsWindowCommand =>
		_showAddSettingsWindowCommand ??= new(obj => {
			
		}, null);
	
	RelayCommand? _doubleClickToSubApp;
	public RelayCommand DoubleClickToSubApp =>
		_doubleClickToSubApp ??= new(_ => {
			string? subAppPageName = GetAllDescendants(MenuNodes)
				.FirstOrDefault(node => node.IsSelected)?.SubAppPageName;
			
			if (subAppPageName is not null)
				GoToPage(subAppPageName);
		}, null);

	
	IEnumerable<SubAppNode> GetAllDescendants(IEnumerable<SubAppNode> rootNodes)
	{
		var nodes = new Stack<SubAppNode>(rootNodes);
		
		while (nodes.Any())
		{
			var node = nodes.Pop();
			yield return node;
			foreach (var n in node.Children) 
				nodes.Push(n);
		}
	}
	
	//todo Тут загрузка из JSON'a который в %APPDATA%
	void FillMenuNodes() {
		//todo тут загрузка из БД для каждого пользователя отдельно
		var favourites = new SubAppNode {
			Id = 0,
			Name = "Избранное"
		};

		var apps = new SubAppNode {
			Id = 1,
			Name = "Приложения",
			IsExpanded = true
		};
		
		MenuNodes.Add(favourites);
		MenuNodes.Add(apps);
		
		apps.Children.Add(new() {
			Id = 2,
			IdParent = 1,
			Name = "Основные",
			IsExpanded = true,
			Children = {
				new SubAppNode {
					Id = 3,
					IdParent = 2,
					Name = "Заказы",
					IsExpanded = true,
					Children = {
						new SubAppNode {
							Id = 4,
							IdParent = 3,
							Name = "Заказы по фильтрам",
						},
						new SubAppNode {
							Id = 5,
							IdParent = 3,
							Name = "Все заказы",
							SubAppPageName = nameof(OrderManager)
						},
						new SubAppNode {
							Id = 6,
							IdParent = 3,
							Name = "Добавить заказ"
						},
						new SubAppNode {
							Id = 7,
							IdParent = 3,
							Name = "Массовая загрузка заказов"
						}
					}
				},
				new SubAppNode {
					Id = 8,
					IdParent = 2,
					Name = "Документы",
					IsExpanded = true,
					Children = {
						new SubAppNode {
							Id = 9,
							IdParent = 8,
							Name = "Выгрузка заказов в Excel"
						},
						new SubAppNode {
							Id = 10,
							IdParent = 8,
							Name = "Выгрузка всех заказов в Excel"
						}
					}
				}
			}
		});
		apps.Children.Add(new() {
			Id = 11,
			IdParent = 1,
			Name = "Администрирование",
			IsExpanded = true,
			Children = {
				new SubAppNode {
					Id = 12,
					IdParent = 11,
					Name = "Роли",
					IsExpanded = true,
					Children = {
						new SubAppNode {
							Id = 13,
							IdParent = 12,
							Name = "Список ролей"
						},
						new SubAppNode {
							Id = 14,
							IdParent = 12,
							Name = "Создать роль"
						}
					}
				},
				new SubAppNode {
					Id = 15,
					IdParent = 11,
					Name = "Пользователи",
					IsExpanded = true,
					Children = {
						new SubAppNode {
							Id = 16,
							IdParent = 15,
							Name = "Список пользователей"
						},
						new SubAppNode {
							Id = 17,
							IdParent = 15,
							Name = "Создать пользователя"
						}
					}
				}
			}
		});
	}
}