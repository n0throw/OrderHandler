using System.Collections.Generic;
using OrderHandler.DB.Data;
using OrderHandler.UI.Model;

namespace OrderHandler.UI.Core;

public interface IOrderService {
    IEnumerable<Order> Open(string fileName);
    void Save(string fileName, IEnumerable<ViewOrder> orders);
}
