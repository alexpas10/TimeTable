using System.Collections.Generic;
using TimeTable.DAL.DBContext;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {
	public interface ITeacherRepository : IRepository<EntityDbContext> {
		bool HasSubject(int teacherId, int subjectId);
		TeacherItems GetTeacherItems(TeacherFilter filter);
		TeacherDetails GetTeacherDetails(int id);
		void UpdateSubjects(Teacher teacher, ICollection<int> subjectIds);
		ICollection<KeyValue> GetTeachers(int? subjectId = null);
	}
}
