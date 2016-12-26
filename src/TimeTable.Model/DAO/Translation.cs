namespace TimeTable.Model {
	public class Translation : BaseModel {

		public int TranslationCode { get; set; }
		public int LanguageId { get; set; }
		public string Value { get; set; }
	}
}
