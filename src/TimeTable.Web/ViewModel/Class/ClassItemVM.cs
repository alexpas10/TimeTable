using System.Collections.Generic;
using TimeTable.Model;

namespace TimeTable.Web.ViewModel {

	public class ClassItemVM : BaseVM {

		public int Number { get; set; }
		public int DayOfWeekId { get; set; }
		public string DayOfWeekName { get; set; }
		public int WeekAlternationId { get; set; }
		public string WeekAlternationName { get; set; }
		public int LoadId { get; set; }
		public string TeacherName { get; set; }
		public string SubjectName { get; set; }
		public string GroupName { get; set; }
		public int RoomId { get; set; }
		public string RoomName { get; set; }
		public int GroupId { get; set; }

	}
}