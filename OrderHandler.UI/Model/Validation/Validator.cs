using System.Linq;
using System.Collections.Generic;

namespace OrderHandler.UI.Model.Validation;
public abstract class Validator<T> : IValidator<T> where T : class {
    public List<ValidationResult> Errors { get; private set; }
    public string Separator { get; init; }
    
    public Validator(string separator = "\n") {
        Errors = new List<ValidationResult>();
        Separator = separator;
    }
    public string this[string columnName] =>
        string.Join(Separator, Errors.Where(err => err.ParamName == columnName));
    public abstract bool Validate(T obj);
    public IEnumerable<ValidationResult> CreateValidationResults(string paramName, List<string> errors) =>
        errors.Select(err => new ValidationResult(paramName, err));
}