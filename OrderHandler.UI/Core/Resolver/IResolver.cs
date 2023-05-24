namespace OrderHandler.UI.Core.Resolver;

public interface IResolver<out T> {
    T GetInstance(string? alias);
}