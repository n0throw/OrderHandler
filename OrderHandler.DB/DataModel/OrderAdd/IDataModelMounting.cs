namespace OrderHandler.DB.DataModel.OrderAdd;

public interface IDataModelMounting : ICloneable {
    public bool IsMounting { get; }
    public DateTime Date { get; }
}