using System.Collections.Generic;
using System.Linq;

namespace OrderHandler.UI.Model.Validation;
public interface IValidator<T> where T : class {
    public List<ValidationResult> Errors { get; }
    public string Separator { get; init; }
    public string this[string paramName] =>
        string.Join(Separator, Errors.Where(err => err.ParamName == paramName));
    public bool Validate(T obj);
}