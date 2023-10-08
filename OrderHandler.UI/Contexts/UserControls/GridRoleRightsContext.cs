using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model.UserControls.GridRoleRights;

namespace OrderHandler.UI.Contexts.UserControls; 

public class GridRoleRightsContext  : BasePropertyChanger {
    public ObservableCollection<RoleRight> Rights { get; }

    public GridRoleRightsContext() {
        List<RightRightState> allStates = new() {
            new("Ничего", RightRightStates.Nothing),
            new("Просмотр", RightRightStates.Show),
            new("Редактирование", RightRightStates.Editing)
        };
        List<RightRightState> statesWithOutEditing = new() {
            new("Ничего", RightRightStates.Nothing),
            new("Просмотр", RightRightStates.Show)
        };

        Rights = new () {
            new(
                "Заказы по фильтрам",
                statesWithOutEditing.ToList()
            ),
            new(
                "Все заказы",
                statesWithOutEditing.ToList()
            ),
            new(
                "Основные столбцы заказа",
                allStates.ToList()
            ),
            new(
                "Документация конструктора",
                allStates.ToList()
            ),
            new(
                "Заказы по фильтрам",
                statesWithOutEditing.ToList()
            ),
            new(
                "Все заказы",
                statesWithOutEditing.ToList()
            ),
            new(
                "Основные столбцы заказа",
                allStates.ToList()
            ),
            new(
                "Документация конструктора",
                allStates.ToList()
            ),
            new(
                "Заказы по фильтрам",
                statesWithOutEditing.ToList()
            ),
            new(
                "Все заказы",
                statesWithOutEditing.ToList()
            ),
            new(
                "Основные столбцы заказа",
                allStates.ToList()
            ),
            new(
                "Документация конструктора",
                allStates.ToList()
            ),
            new(
                "Заказы по фильтрам",
                statesWithOutEditing.ToList()
            ),
            new(
                "Все заказы",
                statesWithOutEditing.ToList()
            ),
            new(
                "Основные столбцы заказа",
                allStates.ToList()
            ),
            new(
                "Документация конструктора",
                allStates.ToList()
            )
        };
    }
}