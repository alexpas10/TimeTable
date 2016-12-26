using System.ComponentModel.DataAnnotations;
using TimeTable.Web.Context;

namespace TimeTable.Web.DataAnotation {
	public class BaseValidationAttribute : ValidationAttribute {

		public int ErrorMessageCode { get; set; }

		public virtual string GetErrorMessage() {
			return StyleContext.Current.Translations.Get(ErrorMessageCode);
		}

		protected ValidationResult GetValidationResult(bool isValid) {
			return isValid
				? ValidationResult.Success
				: new ValidationResult(GetErrorMessage());
		}
	}
}
