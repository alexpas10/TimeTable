using System.ComponentModel.DataAnnotations;

namespace TimeTable.Web.API.ViewModel {
	public class RoomCreateVM : BaseVM {

		[Required]
		[MaxLength(32, ErrorMessage = "Maximum lenght exceeded")]
		public string Name { get; set; }

		[Range(0, 500)]
		public byte PlacesCount { get; set; }

		[Required(ErrorMessage = "Building is required")]
		public int BuildingId { get; set; }
		
		[Required]
		public int TypeId { get; set; }
	}
}
