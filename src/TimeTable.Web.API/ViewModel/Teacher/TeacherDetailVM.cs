using System.Collections.Generic;

namespace TimeTable.Web.API.ViewModel {

	public class TeacherDetailVM : BaseVM {
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public int PositionId { get; set; }
		public int PositionNameCode { get; set; }
		public IDictionary<int, string> Subjects { get; set; }
	}
}