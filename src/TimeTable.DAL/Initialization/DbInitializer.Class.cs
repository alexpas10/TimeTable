using System.Collections.Generic;
using TimeTable.Common.AppConstants;
using TimeTable.Model;

namespace TimeTable.DAL {
	public partial class DbInitializer {

		public IEnumerable<Class> ClassData { get; set; } = new List<Class> {
			new Class { LoadId = 11, Number = 1, RoomId = 19, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Monday },
			new Class { LoadId = 1, Number = 2, RoomId = 39, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Monday },
			new Class { LoadId = 12, Number = 2, RoomId = 39, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Monday },
			new Class { LoadId = 5, Number = 3, RoomId = 31, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Monday },
			new Class { LoadId = 3, Number = 2, RoomId = 39, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Tuesday },
			new Class { LoadId = 14, Number = 2, RoomId = 39, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Tuesday },
			new Class { LoadId = 6, Number = 3, RoomId = 38, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Tuesday },
			new Class { LoadId = 16, Number = 3, RoomId = 38, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Tuesday },
			new Class { LoadId = 8, Number = 1, RoomId = 39, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Wednesday },
			new Class { LoadId = 18, Number = 1, RoomId = 39, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Wednesday },
			new Class { LoadId = 2, Number = 2, RoomId = 23, WeekAlternationId = Dom.DomainValue.Second, DayOfWeekId = Dom.DomainValue.Wednesday },
			new Class { LoadId = 10, Number = 1, RoomId = 21, WeekAlternationId = Dom.DomainValue.First, DayOfWeekId = Dom.DomainValue.Thursday },
			new Class { LoadId = 20, Number = 1, RoomId = 21, WeekAlternationId = Dom.DomainValue.Second, DayOfWeekId = Dom.DomainValue.Thursday },
			new Class { LoadId = 4, Number = 2, RoomId = 24, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Thursday },
			new Class { LoadId = 15, Number = 2, RoomId = 24, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Thursday },
			new Class { LoadId = 2, Number = 1, RoomId = 28, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Friday },
			new Class { LoadId = 13, Number = 1, RoomId = 28, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Friday },
			new Class { LoadId = 6, Number = 2, RoomId = 33, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Friday },
			new Class { LoadId = 16, Number = 2, RoomId = 33, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Friday },
			new Class { LoadId = 9, Number = 3, RoomId = 11, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Friday },
			new Class { LoadId = 19, Number = 3, RoomId = 11, WeekAlternationId = Dom.DomainValue.Both, DayOfWeekId = Dom.DomainValue.Friday }
		};
	}
}