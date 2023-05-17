using System.Collections.Generic;

using OrderHandler.DB.Data;
using OrderHandler.UI.Model;
using OrderHandler.UI.Core.Resolver;

namespace OrderHandler.UI.Core;

public interface IOrderService {
    IEnumerable<Order> Open(string fileName);
    void Save(string fileName, ExcelVersion excelVersion, IEnumerable<ViewOrder> orders, bool fillInfo);
}
