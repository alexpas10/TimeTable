using System.ComponentModel.DataAnnotations;

namespace TimeTable.Web.ViewModel {

	public class GroupCreateVM : BaseVM {

		[Required]
		[MaxLength(32)]
		public string Name { get; set; }

		[Range(1, 6)]
		public byte Year { get; set; }

		[Range(0, byte.MaxValue)]
		public byte StudentsCount { get; set; }
	}
}