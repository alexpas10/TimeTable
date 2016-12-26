namespace TimeTable.Model {
	public class Class : BaseModel {

		public int Number { get; set; }
		public int DayOfWeekId { get; set; }
		public int WeekAlternationId { get; set; }
		public int LoadId { get; set; }
		public int RoomId { get; set; }

		public Load Load { get; set; }
		public Room Room { get; set; }
	}
}
