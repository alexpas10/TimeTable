using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TimeTable.Common.AppConstants;
using TimeTable.Model;
using TimeTable.Web.DataAnotation;

namespace TimeTable.Web.ViewModel {

	public class LoadDetailVM : BaseVM {

		public int SubjectId { get; set; }
		public string SubjectName { get; set; }
		public ICollection<SelectItemVM> Subjects { get; set; }

		public int SubjectTypeId { get; set; }
		public int SubjectTypeName { get; set; }
		public ICollection<SelectItemVM> SubjectTypes { get; set; }

		public int TeacherId { get; set; }
		public string TeacherName { get; set; }
		public ICollection<SelectItemVM> Teachers { get; set; }

		public int GroupId { get; set; }
		public string GroupName { get; set; }
		public ICollection<SelectItemVM> Groups { get; set; }
	}
}