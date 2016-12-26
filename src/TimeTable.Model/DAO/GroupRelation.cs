namespace TimeTable.Model {
	public class GroupRelation : BaseModel {
		public int GroupId { get; set; }
		public int ParentGroupId { get; set; }

		public Group Group { get; set; }
		public Group ParentGroup { get; set; }
	}
}
