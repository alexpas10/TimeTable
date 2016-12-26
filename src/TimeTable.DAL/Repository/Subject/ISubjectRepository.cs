using System.Collections.Generic;
using TimeTable.DAL.DBContext;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {
	public interface ISubjectRepository : IRepository<EntityDbContext> {
		void UpdateTeachers(Subject subject, ICollection<int> teacherIds);
		SubjectItems GetSubjectItems(SubjectFilter filter);
		SubjectDetails GetSubjectDetails(int id);
		ICollection<KeyValue> GetSubjects(int? teacherId = null);
	}
}
