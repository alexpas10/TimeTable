using System.Collections.Generic;
using TimeTable.Common.AppConstants;
using TimeTable.Model;

namespace TimeTable.DAL {
	public partial class DbInitializer {

		public IEnumerable<Group> GroupData { get; set; } = new List<Group> {
			new Group { Id = 1,  Name = "101(а)", Year = 1, StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Subgroup },
			new Group { Id = 2,  Name = "101(б)", Year = 1, StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Subgroup },
			new Group { Id = 3,  Name = "111(а)", Year = 1, StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Subgroup },
			new Group { Id = 4,  Name = "111(б)", Year = 1, StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Subgroup },
			new Group { Id = 5,  Name = "101", Year = 1,    StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 6,  Name = "111", Year = 1,    StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 7,  Name = "102", Year = 1,    StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 8,  Name = "112", Year = 1,    StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 9,  Name = "107", Year = 1,    StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 10, Name = "108", Year = 1,    StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 11, Name = "146", Year = 1,    StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 12, Name = "109", Year = 1,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 13, Name = "201", Year = 2,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 14, Name = "211", Year = 2,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 15, Name = "202", Year = 2,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 16, Name = "212", Year = 2,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 17, Name = "207", Year = 2,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 18, Name = "204", Year = 2,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 19, Name = "205", Year = 2,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 20, Name = "301", Year = 3,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 21, Name = "302", Year = 3,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 22, Name = "311", Year = 3,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 23, Name = "312", Year = 3,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 24, Name = "322", Year = 3,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 25, Name = "307", Year = 3,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 26, Name = "304", Year = 3,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 27, Name = "305", Year = 3,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 28, Name = "306", Year = 3,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 29, Name = "401", Year = 4,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 30, Name = "402", Year = 4,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 31, Name = "422", Year = 4,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 32, Name = "407", Year = 4,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 33, Name = "404", Year = 4,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 34, Name = "405", Year = 4,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 35, Name = "406", Year = 4,   StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 36, Name = "501м", Year = 5,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 37, Name = "501с", Year = 5,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 38, Name = "502м", Year = 5,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 39, Name = "502с", Year = 5,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 40, Name = "507м", Year = 5,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 41, Name = "533м", Year = 5,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 42, Name = "546м", Year = 5,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 43, Name = "509м", Year = 5,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 44, Name = "509с", Year = 5,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 45, Name = "601м", Year = 6,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 46, Name = "602м", Year = 6,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 47, Name = "607м", Year = 6,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 48, Name = "603м", Year = 6,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 49, Name = "646м", Year = 6,  StudentsCount = (byte)rand.Next(8, 25), TypeId = Dom.DomainValue.Group },
			new Group { Id = 50, Name = "1 курс (прикладна математика)", TypeId = Dom.DomainValue.Stream }
		};

		public IEnumerable<GroupRelation> GroupRelationData { get; set; } = new List<GroupRelation> {
			new GroupRelation { GroupId = 1, ParentGroupId = 5 },
			new GroupRelation { GroupId = 2, ParentGroupId = 5 },
			new GroupRelation { GroupId = 3, ParentGroupId = 6 },
			new GroupRelation { GroupId = 4, ParentGroupId = 6 },
			new GroupRelation { GroupId = 5, ParentGroupId = 50 },
			new GroupRelation { GroupId = 6, ParentGroupId = 50 },
			new GroupRelation { GroupId = 7, ParentGroupId = 50 },
			new GroupRelation { GroupId = 8, ParentGroupId = 50 },
			new GroupRelation { GroupId = 9, ParentGroupId = 50 },
		};
	}
}