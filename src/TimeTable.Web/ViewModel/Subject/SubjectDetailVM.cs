using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TimeTable.Web.DataAnotation;

namespace TimeTable.Web.ViewModel {

	public class SubjectDetailVM : BaseVM {

		[Required]
		[MaxLength(255)]
		public string Name { get; set; }
		public string ShortName { get; set; }

		[MaterialMultipleSelect]
		public int[] SelectedTeachers { get; set; }
		public ICollection<TeacherRefVM> Teachers { get; set; }
		public ICollection<SelectItemVM> TeacherItems { get; set; }
	}
}