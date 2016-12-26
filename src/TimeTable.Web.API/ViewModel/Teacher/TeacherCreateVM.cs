using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimeTable.Web.API.ViewModel {

	public class TeacherCreateVM : BaseVM {

		[Required]
		[MaxLength(32, ErrorMessage = "Maximum lenght exceeded")]
		public string Name { get; set; }

		[Required]
		[MaxLength(32, ErrorMessage = "Maximum lenght exceeded")]
		public string Surname { get; set; }

		[Required]
		[MaxLength(32, ErrorMessage = "Maximum lenght exceeded")]
		public string Patronymic { get; set; }

		[Required]
		public int PositionId { get; set; }

		public ICollection<int> SubjectIds { get; set; }
	}
}