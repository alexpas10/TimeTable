using System.ComponentModel.DataAnnotations;
using TimeTable.Common.AppConstants;
using TimeTable.Web.DataAnotation;

namespace TimeTable.Web.ViewModel {
	public class LoginViewModel {

		[MaterialRequired]
		[EmailAddress]
		[MaterialDisplay(LabelCode = Dom.Translation.Common.Email)]
		public string Email { get; set; }

		[MaterialRequired]
		[DataType(DataType.Password)]
		[MaterialDisplay(LabelCode = Dom.Translation.Common.Password)]
		public string Password { get; set; }

		[MaterialDisplay(LabelCode = Dom.Translation.Common.RememberMe)]
		public bool RememberMe { get; set; }
	}
}
