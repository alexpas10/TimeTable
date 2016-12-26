using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TimeTable.Model;
using TimeTable.Web.DataAnotation;

namespace TimeTable.Web.ViewModel {

	public class ClassCreateVM : BaseVM {

		[MaterialRequired]
		public int? Number { get; set; }

		[MaterialRequired]
		public int? DayOfWeekId { get; set; }

		[MaterialRequired]
		public int? WeekAlternationId { get; set; }

		[MaterialRequired]
		public int? LoadId { get; set; }
		
		[MaterialRequired]
		public int? RoomId { get; set; }
		
		[MaterialRequired]
		public int? GroupId { get; set; }
		public string GroupFormattedName { get; set; }

		public ICollection<SelectItemVM> Rooms { get; set; }
		public ICollection<SelectItemVM> Loads { get; set; }
		public ICollection<SelectItemVM> WeekAlternations { get; set; }
		public ICollection<SelectItemVM> Days { get; set; }
	}
}