using System.Collections.Generic;
using TimeTable.DAL.DBContext;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {
	public interface ITranslationRepository : IRepository<EntityDbContext> {

		//[Cache(Category = CacheManager.CategoryName.Translation, DurationInSec = CacheManager.InfiniteDuration)]
		IDictionary<int, string> GetTranslations(int languageId);

		string GetTranslation(int languageId, int translationCodeId);
	}
}
