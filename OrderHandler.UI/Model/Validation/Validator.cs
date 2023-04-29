using System.Linq;
using System.Collections.Generic;

namespace OrderHandler.UI.Model.Validation;
public abstract class Validator<T> : IValidator<T> where T : class {
	public List<ValidationResult> Errors { get; }
	public string Separator { get; }

	protected Validator(string separator = "\n") {
		Errors = new();
		Separator = separator;
	}

	public abstract bool Validate(T obj);

	protected IEnumerable<ValidationResult> CreateValidationResults(string paramName, IEnumerable<string> errors) =>
		errors.Select(err => new ValidationResult(paramName, err));
}