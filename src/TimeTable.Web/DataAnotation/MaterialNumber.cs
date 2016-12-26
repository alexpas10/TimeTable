using System.ComponentModel.DataAnnotations;

namespace TimeTable.Web.DataAnotation {
	public class MaterialNumberAttribute : BaseValidationAttribute {

		public MaterialNumberAttribute() {
		}

		public MaterialNumberAttribute(int errorMessageCode) {
			ErrorMessageCode = errorMessageCode;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
			bool isValid = false;

			int intValue;
			if (value == null
				|| value is int
				|| int.TryParse(value.ToString(), out intValue)) {

				isValid = true;
			}

			return GetValidationResult(isValid);
		}
	}
}
