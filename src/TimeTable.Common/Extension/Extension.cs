using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTable.Common {

	public static class CollectionExtensions {

		public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) {
			return collection == null || !collection.Any();
		}

		public static bool Any(this IEnumerable source) {
			bool any = false;
			if (source != null) {
				IEnumerator enumerator = source.GetEnumerator();
				if (enumerator.MoveNext())
					any = true;
			}
			return any;
		}

		public static string ToJSONString(this int[] array) {
			return array != null ? "[" + string.Join(",", array) + "]" : string.Empty;
		}
	}

	public static class StringExtestions {

		public static int[] SplitToInts(this string value, char separator) {
			string[] strArray;
			int[] intArray = new int[0];
			if (!string.IsNullOrEmpty(value)) {
				strArray = value.Split(separator);
				intArray = new int[strArray.Length];
				for (int i = 0; i < strArray.Length; i++) {
					intArray[i] = int.Parse(strArray[i]);
				}
			}
			return intArray;
		}
	}

	public static class Format {

		public static string FormattedFullName(string surname, string name, string patronymic) {
			StringBuilder sb = new StringBuilder(162);
			if (!string.IsNullOrWhiteSpace(surname)) {
				sb.Append(surname);
			}

			if (!string.IsNullOrWhiteSpace(name)) {
				sb.Append(' ').Append(name);
			}

			if (!string.IsNullOrWhiteSpace(patronymic)) {
				sb.Append(' ').Append(patronymic);
			}

			if (string.IsNullOrWhiteSpace(sb.ToString())) {
				sb.Append("Unknown");
			}
			return sb.ToString();
		}

		public static string FormattedShortName(string surname, string name, string patronymic) {
			StringBuilder sb = new StringBuilder(162);
			if (!string.IsNullOrWhiteSpace(surname)) {
				sb.Append(surname);
			}

			if (!string.IsNullOrWhiteSpace(name)) {
				sb.Append(' ').Append(name[0]).Append('.');
			}

			if (!string.IsNullOrWhiteSpace(patronymic)) {
				sb.Append(' ').Append(patronymic[0]).Append('.');
			}

			if (string.IsNullOrWhiteSpace(sb.ToString())) {
				sb.Append("Unknown");
			}
			return sb.ToString();
		}

		public static string FormattedTeacherName(string positionName, string surname, string name, string patronymic) {
			StringBuilder sb = new StringBuilder(162);
			if (!string.IsNullOrWhiteSpace(positionName)) {
				sb.Append(positionName);
			}
			string shortName = FormattedShortName(surname, name, patronymic);
			if (!string.IsNullOrWhiteSpace(shortName)) {
				sb.Append(' ').Append(shortName);
			}
			if (string.IsNullOrWhiteSpace(sb.ToString())) {
				sb.Append("Unknown");
			}
			return sb.ToString();
		}


		public static string ToViewMode(this string value) {
			return (value.IsNullOrEmpty()) ? "-" : value;
		}

		public static string ToViewMode(this int? value) {
			return (value.HasValue) ? value.ToString() : "-";
		}

		public static string ToViewMode(this byte? value) {
			return (value.HasValue) ? value.ToString() : "-";
		}
	}
}