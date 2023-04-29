using System.Collections.Generic;
using System.Linq;

namespace OrderHandler.UI.Model.Validation;
public interface IValidator<in T> where T : class {
	public List<ValidationResult> Errors { get; }
	public string Separator { get; }
	public string this[string paramName] =>
		string.Join(Separator,
					Errors
						.Where(err => err.ParamName == paramName)
						.Select(err => err.Error)
		);
	public bool Validate(T obj);
}