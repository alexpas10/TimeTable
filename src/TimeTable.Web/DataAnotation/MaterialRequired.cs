using System.ComponentModel.DataAnnotations;
using TimeTable.Common.AppConstants;

namespace TimeTable.Web.DataAnotation {
	public class MaterialRequiredAttribute : BaseValidationAttribute {

		public MaterialRequiredAttribute()
			: this(Dom.Translation.Common.Required) { }

		public MaterialRequiredAttribute(int errorMessageCode) {
			ErrorMessageCode = errorMessageCode;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
			bool isValid = true;
			if (value == null) {
				isValid = false;
			}

			if (isValid && value is string) {
				string stringValue = value as string;
				if (string.IsNullOrWhiteSpace(stringValue)) {
					isValid = false;
				}
			}

			return GetValidationResult(isValid);
		}
	}
}
