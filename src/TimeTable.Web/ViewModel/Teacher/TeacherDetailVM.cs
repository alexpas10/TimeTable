using System.Collections.Generic;
using TimeTable.Common.AppConstants;
using TimeTable.Web.DataAnotation;

namespace TimeTable.Web.ViewModel {

	public class TeacherDetailVM : BaseVM {

		public int TabId { get; set; }

		[MaterialRequired]
		[MaterialDisplay(LabelCode = Dom.Translation.Teacher.Name)]
		public string Name { get; set; }

		[MaterialRequired]
		[MaterialDisplay(LabelCode = Dom.Translation.Teacher.Surname)]
		public string Surname { get; set; }

		[MaterialRequired]
		[MaterialDisplay(LabelCode = Dom.Translation.Teacher.Patronymic)]
		public string Patronymic { get; set; }
		public string FormattedName { get; set; }

		[MaterialRequired]
		[MaterialDisplay(LabelCode = Dom.Translation.Teacher.Position)]
		public int? PositionId { get; set; }
		public ICollection<SelectItemVM> PositionItems { get; set; }

		[MaterialDisplay(LabelCode = Dom.Translation.Teacher.Position)]
		public string PositionName { get; set; }

		[MaterialMultipleSelect]
		[MaterialDisplay(LabelCode = Dom.Translation.Subject.Plural)]
		public int[] SelectedSubjects { get; set; }
		public ICollection<SubjectRefVM> Subjects { get; set; }
		public ICollection<SelectItemVM> SubjectItems { get; set; }
		public ICollection<SelectItemVM> SubjectTypeItems { get; set; }
	}
}