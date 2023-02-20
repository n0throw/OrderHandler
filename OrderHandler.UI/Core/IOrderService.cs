using OrderHandler.DB.Model;

using OrderHandler.UI.Model;

using System.Collections.Generic;

namespace OrderHandler.UI.Core;

internal interface IOrderService
{
    IEnumerable<Order> Open(string fileName);
    void Save(string fileName, IEnumerable<ViewOrder> orders);
}
