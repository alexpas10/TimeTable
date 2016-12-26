using System.Collections.Generic;
using TimeTable.Common.AppConstants;
using TimeTable.Model;

namespace TimeTable.DAL {
	public partial class DbInitializer {

		public IEnumerable<Load> LoadData { get; set; } = new List<Load> {
			new Load { Id = 1, GroupId = 1, SubjectId = (int)Subjects.Мат_аналіз, HoursPerWeek = 2, TeacherId = (int)Teachers.Михайлюк, SubjectTypeId = Dom.DomainValue.Lection },
			new Load { Id = 2, GroupId = 1, SubjectId = (int)Subjects.Мат_аналіз, HoursPerWeek = 3, TeacherId = (int)Teachers.Карлова, SubjectTypeId = Dom.DomainValue.Practice },
			new Load { Id = 3, GroupId = 1, SubjectId = (int)Subjects.Програмування, HoursPerWeek = 2, TeacherId = (int)Teachers.Караванова, SubjectTypeId = Dom.DomainValue.Lection },
			new Load { Id = 4, GroupId = 1, SubjectId = (int)Subjects.Програмування, HoursPerWeek = 2, TeacherId = (int)Teachers.Караванова, SubjectTypeId = Dom.DomainValue.Practice },
			new Load { Id = 5, GroupId = 1, SubjectId = (int)Subjects.Програмування, HoursPerWeek = 2, TeacherId = (int)Teachers.Караванова, SubjectTypeId = Dom.DomainValue.Laboratory },
			new Load { Id = 6, GroupId = 1, SubjectId = (int)Subjects.Дискретна_математика, HoursPerWeek = 2, TeacherId = (int)Teachers.Філіпчук, SubjectTypeId = Dom.DomainValue.Lection },
			new Load { Id = 7, GroupId = 1, SubjectId = (int)Subjects.Дискретна_математика, HoursPerWeek = 2, TeacherId = (int)Teachers.Філіпчук, SubjectTypeId = Dom.DomainValue.Practice },
			new Load { Id = 8, GroupId = 1, SubjectId = (int)Subjects.Алгебра_і_геометрія, HoursPerWeek = 2, TeacherId = (int)Teachers.Колісник, SubjectTypeId = Dom.DomainValue.Lection },
			new Load { Id = 9, GroupId = 1, SubjectId = (int)Subjects.Алгебра_і_геометрія, HoursPerWeek = 2, TeacherId = (int)Teachers.Колісник, SubjectTypeId = Dom.DomainValue.Practice },
			new Load { Id = 10, GroupId = 1, SubjectId = (int)Subjects.Олімп_задачі_з_інформатики, HoursPerWeek = 1, TeacherId = (int)Teachers.Піддубна, SubjectTypeId = Dom.DomainValue.Practice },
			new Load { Id = 11, GroupId = 2, SubjectId = (int)Subjects.Програмування, HoursPerWeek = 2, TeacherId = (int)Teachers.Дорош, SubjectTypeId = Dom.DomainValue.Laboratory },
			new Load { Id = 12, GroupId = 2, SubjectId = (int)Subjects.Мат_аналіз, HoursPerWeek = 2, TeacherId = (int)Teachers.Михайлюк, SubjectTypeId = Dom.DomainValue.Lection },
			new Load { Id = 13, GroupId = 2, SubjectId = (int)Subjects.Мат_аналіз, HoursPerWeek = 3, TeacherId = (int)Teachers.Карлова, SubjectTypeId = Dom.DomainValue.Practice },
			new Load { Id = 14, GroupId = 2, SubjectId = (int)Subjects.Програмування, HoursPerWeek = 2, TeacherId = (int)Teachers.Караванова, SubjectTypeId = Dom.DomainValue.Lection },
			new Load { Id = 15, GroupId = 2, SubjectId = (int)Subjects.Програмування, HoursPerWeek = 2, TeacherId = (int)Teachers.Караванова, SubjectTypeId = Dom.DomainValue.Practice },
			new Load { Id = 16, GroupId = 2, SubjectId = (int)Subjects.Дискретна_математика, HoursPerWeek = 2, TeacherId = (int)Teachers.Філіпчук, SubjectTypeId = Dom.DomainValue.Lection },
			new Load { Id = 17, GroupId = 2, SubjectId = (int)Subjects.Дискретна_математика, HoursPerWeek = 2, TeacherId = (int)Teachers.Філіпчук, SubjectTypeId = Dom.DomainValue.Practice },
			new Load { Id = 18, GroupId = 2, SubjectId = (int)Subjects.Алгебра_і_геометрія, HoursPerWeek = 2, TeacherId = (int)Teachers.Колісник, SubjectTypeId = Dom.DomainValue.Lection },
			new Load { Id = 19, GroupId = 2, SubjectId = (int)Subjects.Алгебра_і_геометрія, HoursPerWeek = 2, TeacherId = (int)Teachers.Колісник, SubjectTypeId = Dom.DomainValue.Practice },
			new Load { Id = 20, GroupId = 2, SubjectId = (int)Subjects.Олімп_задачі_з_інформатики, HoursPerWeek = 1, TeacherId = (int)Teachers.Піддубна, SubjectTypeId = Dom.DomainValue.Practice }
		};
	}
}