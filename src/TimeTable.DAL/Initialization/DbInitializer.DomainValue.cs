using System.Collections.Generic;
using TimeTable.Common.AppConstants;
using TimeTable.Model;

namespace TimeTable.DAL {
	public partial class DbInitializer {
	
		public IEnumerable<DomainValueType> DomainValueTypeData { get; set; } = new List<DomainValueType> {
			new DomainValueType { Id = Dom.DomainValueType.DayOfWeek, Name = "DayOfWeek" },
			new DomainValueType { Id = Dom.DomainValueType.Language, Name = "Language" },
			new DomainValueType { Id = Dom.DomainValueType.Subject, Name = "Subject" },
			new DomainValueType { Id = Dom.DomainValueType.TeachersPosition, Name = "TeachersPosition" },
			new DomainValueType { Id = Dom.DomainValueType.WeeksAlternation, Name = "WeeksAlternation" },
			new DomainValueType { Id = Dom.DomainValueType.Group, Name = "Group" }
		};

		public IEnumerable<DomainValue> DomainValueData { get; set; } = new List<DomainValue> {
			new DomainValue { Id = 1, DomainValuedTypeId = Dom.DomainValueType.DayOfWeek, NameCode = Dom.Translation.DomainValue.Monday },
			new DomainValue { Id = 2, DomainValuedTypeId = Dom.DomainValueType.DayOfWeek, NameCode = Dom.Translation.DomainValue.Tuesday },
			new DomainValue { Id = 3, DomainValuedTypeId = Dom.DomainValueType.DayOfWeek, NameCode = Dom.Translation.DomainValue.Wednesday },
			new DomainValue { Id = 4, DomainValuedTypeId = Dom.DomainValueType.DayOfWeek, NameCode = Dom.Translation.DomainValue.Thursday },
			new DomainValue { Id = 5, DomainValuedTypeId = Dom.DomainValueType.DayOfWeek, NameCode = Dom.Translation.DomainValue.Friday },
			new DomainValue { Id = 6, DomainValuedTypeId = Dom.DomainValueType.DayOfWeek, NameCode = Dom.Translation.DomainValue.Saturday },
			new DomainValue { Id = 7, DomainValuedTypeId = Dom.DomainValueType.DayOfWeek, NameCode = Dom.Translation.DomainValue.Sunday },
			new DomainValue { Id = 8, DomainValuedTypeId = Dom.DomainValueType.Language, NameCode = Dom.Translation.DomainValue.English },
			new DomainValue { Id = 9, DomainValuedTypeId = Dom.DomainValueType.Language, NameCode = Dom.Translation.DomainValue.Ukrainian },
			new DomainValue { Id = 10, DomainValuedTypeId = Dom.DomainValueType.Subject, NameCode = Dom.Translation.DomainValue.Lection },
			new DomainValue { Id = 11, DomainValuedTypeId = Dom.DomainValueType.Subject, NameCode = Dom.Translation.DomainValue.Practice },
			new DomainValue { Id = 12, DomainValuedTypeId = Dom.DomainValueType.Subject, NameCode = Dom.Translation.DomainValue.Laboratory },
			new DomainValue { Id = 13, DomainValuedTypeId = Dom.DomainValueType.TeachersPosition, NameCode = Dom.Translation.DomainValue.AssistantProfessor },
			new DomainValue { Id = 14, DomainValuedTypeId = Dom.DomainValueType.TeachersPosition, NameCode = Dom.Translation.DomainValue.AssociateProfessor },
			new DomainValue { Id = 15, DomainValuedTypeId = Dom.DomainValueType.TeachersPosition, NameCode = Dom.Translation.DomainValue.FullProfesor },
			new DomainValue { Id = 16, DomainValuedTypeId = Dom.DomainValueType.WeeksAlternation, NameCode = Dom.Translation.DomainValue.FirstWeek },
			new DomainValue { Id = 17, DomainValuedTypeId = Dom.DomainValueType.WeeksAlternation, NameCode = Dom.Translation.DomainValue.SecondWeek },
			new DomainValue { Id = 18, DomainValuedTypeId = Dom.DomainValueType.WeeksAlternation, NameCode = Dom.Translation.DomainValue.BothWeeks },
			new DomainValue { Id = 19, DomainValuedTypeId = Dom.DomainValueType.Group, NameCode = Dom.Translation.DomainValue.Group },
			new DomainValue { Id = 20, DomainValuedTypeId = Dom.DomainValueType.Group, NameCode = Dom.Translation.DomainValue.Subgroup },
			new DomainValue { Id = 21, DomainValuedTypeId = Dom.DomainValueType.Group, NameCode = Dom.Translation.DomainValue.Stream },
		};
	}
}
