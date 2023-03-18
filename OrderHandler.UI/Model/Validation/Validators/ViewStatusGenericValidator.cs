using System;
using System.Linq;
using System.Collections.Generic;
using OrderHandler.UI.Model.ViewOrderAdd.Data;

namespace OrderHandler.UI.Model.Validation.Validators;
internal class ViewStatusGenericValidator : Validator<ViewDataStatusGeneric>, IViewStatusGenericValidator {
    private const string obligatoryValue = "Это поле обязательно для заполнения";
    private const string dateIsSmall = "Дата не может быть до 2019-го года";

    public ViewStatusGenericValidator(string separator = "\n") : base(separator) { }

    public override bool Validate(ViewDataStatusGeneric obj) {
        Errors.Clear();

        if (!ValidatePlannedDate(obj.PlannedDate, out List<string> errorsOrderIssue))
            Errors.AddRange(CreateValidationResults(nameof(obj.PlannedDate), errorsOrderIssue));

        return Errors.Count == 0;
    }
    public bool ValidatePlannedDate(DateTime planned, out List<string> error) {
        error = new();
        if (planned == DateTime.MinValue)
            error.Add(obligatoryValue);
        if (planned < new DateTime(2019, 1, 1))
            error.Add(dateIsSmall);

        return !error.Any();
    }
}
