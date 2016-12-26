using System;
using TimeTable.Web.Context;

namespace TimeTable.Web.DataAnotation {

	public class MaterialDisplayAttribute : Attribute {
		public int LabelCode { get; set; }

		public string LabelMessage {
			get {
				return StyleContext.Current.Translations.Get(LabelCode);
			}
		}
	}
}