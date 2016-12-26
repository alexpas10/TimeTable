using System;
using System.Text;
using TimeTable.Common.AppConstants;
using TimeTable.Web.Context;

namespace TimeTable.Web.Extension {
	public static class StyleFormat {
		public static string FormattedRoomName(string buildingName, string roomName, string placesCount = null) {
			StringBuilder sb = new StringBuilder(162);
			if (!string.IsNullOrWhiteSpace(buildingName)) {
				sb.Append(buildingName);
			}

			if (!string.IsNullOrWhiteSpace(roomName)) {
				sb.Append(" - ").Append(roomName);
			}

			if (!string.IsNullOrWhiteSpace(placesCount)) {
				var label = StyleContext.Current.Translations.Get(Dom.Translation.Room.PlacesCount);
				sb.Append($" ({label}: {placesCount})");
			}

			if (string.IsNullOrWhiteSpace(sb.ToString())) {
				sb.Append("Unknown");
			}
			return sb.ToString();
		}

		public static string FormattedGroupName(string name, string studentsCount = null) {
			StringBuilder sb = new StringBuilder(162);
			if (!string.IsNullOrWhiteSpace(name)) {
				sb.Append(name);
			}

			if (!string.IsNullOrWhiteSpace(studentsCount)) {
				var label = StyleContext.Current.Translations.Get(Dom.Translation.Group.StudentsCount);
				sb.Append($" ({label}: {studentsCount})");
			}

			if (string.IsNullOrWhiteSpace(sb.ToString())) {
				sb.Append("Unknown");
			}
			return sb.ToString();
		}

		public static string FormattedLoadName(string teacherName, string subjectName, string subjectTypeName, string groupName = null) {
			StringBuilder sb = new StringBuilder(162);
			if (!string.IsNullOrWhiteSpace(teacherName)) {
				sb.Append(teacherName);
			}

			if (!string.IsNullOrWhiteSpace(subjectName)) {
				sb.Append($" - {subjectName}");
			}

			if (!string.IsNullOrWhiteSpace(subjectTypeName)) {
				sb.Append($" ({subjectTypeName})");
			}

			if (!string.IsNullOrWhiteSpace(groupName)) {
				sb.Append($" - {groupName}");
			}

			if (string.IsNullOrWhiteSpace(sb.ToString())) {
				sb.Append("Unknown");
			}
			return sb.ToString();
		}

	}
}
