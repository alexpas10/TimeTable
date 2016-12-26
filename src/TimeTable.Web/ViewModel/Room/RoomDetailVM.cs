using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TimeTable.Common.AppConstants;
using TimeTable.Web.DataAnotation;

namespace TimeTable.Web.ViewModel {
	public class RoomDetailVM : BaseVM {

		[MaxLength(32)]
		[MaterialRequired]
		[MaterialDisplay(LabelCode = Dom.Translation.Room.Name)]
		public string Name { get; set; }

		[MaterialRequired]
		[MaterialNumber]
		[Range(0, byte.MaxValue)]
		[MaterialDisplay(LabelCode = Dom.Translation.Room.PlacesCount)]
		public byte PlacesCount { get; set; }

		[MaterialRequired]
		[MaterialDisplay(LabelCode = Dom.Translation.Room.Building)]
		public int BuildingId { get; set; }
		public string BuildingName { get; set; }
		public ICollection<SelectItemVM> BuildingItems { get; set; }

		[MaterialRequired]
		[MaterialDisplay(LabelCode = Dom.Translation.Common.Type)]
		public int? TypeId { get; set; }
		public int TypeNameCode { get; set; }

		[MaterialDisplay(LabelCode = Dom.Translation.Common.Type)]
		public string TypeName { get; set; }
		public ICollection<SelectItemVM> TypeItems { get; set; }
	}
}
