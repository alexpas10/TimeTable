using System;
using TimeTable.Web.Context;

namespace TimeTable.Web.DataAnotation {
	public class MaterialTableColumnAttribute : Attribute {

		public int HeaderCode { get; set; }

		public int Order { get; set; }

		public string HeaderText {
			get {
				return StyleContext.Current.Translations.Get(HeaderCode);
			}
		}
	}
}
