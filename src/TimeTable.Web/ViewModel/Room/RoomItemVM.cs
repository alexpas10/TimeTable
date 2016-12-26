using System.ComponentModel.DataAnnotations;

namespace TimeTable.Web.ViewModel {

	public class RoomItemVM : BaseVM {

		public string Name { get; set; }
		public int PlacesCount { get; set; }
		public string BuildingName { get; set; }
		public int TypeNameCode { get; set; }
		public string TypeName { get; set; }
	}
}