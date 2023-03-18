namespace OrderHandler.UI.Core.Resolver;

public interface IResolver<T> {
    T GetInstance(string? alias);
}