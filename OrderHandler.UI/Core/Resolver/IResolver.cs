namespace OrderHandler.UI.Core.Resolver;

internal interface IResolver<T>
{
    T GetInstance(string? alias);
}