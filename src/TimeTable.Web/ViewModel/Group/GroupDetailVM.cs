using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TimeTable.Common.AppConstants;
using TimeTable.Model;
using TimeTable.Web.DataAnotation;

namespace TimeTable.Web.ViewModel {

	public class GroupDetailVM : BaseVM {

		[Required]
		[MaxLength(32)]
		public string Name { get; set; }

		[Range(1, 6)]
		public byte? Year { get; set; }

		[Range(0, byte.MaxValue)]
		public byte? StudentsCount { get; set; }

		public int TypeId { get; set; }
		public ICollection<SelectItemVM> TypeItems { get; set; }

		public ICollection<KeyValue> Subgroups { get; set; }
		public ICollection<KeyValue> ParentGroups { get; set; }
		
		[MaterialMultipleSelect]
		[MaterialDisplay(LabelCode = Dom.Translation.Group.Plural)]
		public int[] SelectedGroups { get; set; }
		public int? ParentGroupId { get; set; }
	}
}