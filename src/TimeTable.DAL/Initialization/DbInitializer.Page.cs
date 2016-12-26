using System.Collections.Generic;
using TimeTable.Common.AppConstants;
using TimeTable.Model;

namespace TimeTable.DAL {
	public partial class DbInitializer {

		public IEnumerable<Page> PageData { get; set; } = new List<Page> {
			new Page { Id = Dom.Page.About, IsDetailPage = true, TitleCode = Dom.Translation.Page.About },
			new Page { Id = Dom.Page.ClassDetails, IsDetailPage = true, TitleCode = Dom.Translation.Page.ClassDetails },
			new Page { Id = Dom.Page.ClassList, IsDetailPage = false, TitleCode = Dom.Translation.Page.ClassList },
			new Page { Id = Dom.Page.GroupDetails, IsDetailPage = true, TitleCode = Dom.Translation.Page.GroupDetails },
			new Page { Id = Dom.Page.GroupList, IsDetailPage = false, TitleCode = Dom.Translation.Page.GroupList },
			new Page { Id = Dom.Page.Home, IsDetailPage = false, TitleCode = Dom.Translation.Page.Home },
			new Page { Id = Dom.Page.LoadDetails, IsDetailPage = true, TitleCode = Dom.Translation.Page.LoadDetails },
			new Page { Id = Dom.Page.LoadList, IsDetailPage = false, TitleCode = Dom.Translation.Page.LoadList },
			new Page { Id = Dom.Page.Login, IsDetailPage = false, TitleCode = Dom.Translation.Page.Login },
			new Page { Id = Dom.Page.Registration, IsDetailPage = false, TitleCode = Dom.Translation.Page.Registration },
			new Page { Id = Dom.Page.RoomDetails, IsDetailPage = true, TitleCode = Dom.Translation.Page.RoomDetails },
			new Page { Id = Dom.Page.RoomList, IsDetailPage = false, TitleCode = Dom.Translation.Page.RoomList },
			new Page { Id = Dom.Page.SubjectDetails, IsDetailPage = true, TitleCode = Dom.Translation.Page.SubjectDetails },
			new Page { Id = Dom.Page.SubjectList, IsDetailPage = false, TitleCode = Dom.Translation.Page.SubjectList },
			new Page { Id = Dom.Page.TeacherDetails, IsDetailPage = true, TitleCode = Dom.Translation.Page.TeacherDetails },
			new Page { Id = Dom.Page.TeacherList, IsDetailPage = false, TitleCode = Dom.Translation.Page.TeacherList }
		};
	}
}
