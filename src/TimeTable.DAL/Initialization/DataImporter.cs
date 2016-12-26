using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TimeTable.DAL {

	public static class DataImporter {

		public static ICollection<T> LoadFromJson<T>(string fileName = null) {
			fileName = fileName ?? nameof(T) + ".json";
			var path = Directory.GetParent(Directory.GetCurrentDirectory()) + fileName;
			if (!File.Exists(path)) {
				return null;
			}
			using (StreamReader streamReader = File.OpenText(path)) {
				string json = streamReader.ReadToEnd();
				return JsonConvert.DeserializeObject<List<T>>(json);
			}
		}
	}
}
