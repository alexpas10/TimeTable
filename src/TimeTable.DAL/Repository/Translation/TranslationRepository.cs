using System.Collections.Generic;
using System.Linq;
using TimeTable.DAL.DBContext;
using TimeTable.DAL.UnitOfWork;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {

	public class TranslationRepository : BaseRepository<EntityDbContext>, ITranslationRepository {

		public TranslationRepository(IUnitOfWork<EntityDbContext> unitOfWork)
			: base(unitOfWork) { }

		public string GetTranslation(int languageId, int translationCodeId) {
			return GetQuery<Translation>().FirstOrDefault(t => t.LanguageId == languageId && t.TranslationCode == translationCodeId)?.Value ?? string.Empty;
		}

		public IDictionary<int, string> GetTranslations(int languageId) {
			return GetQuery<Translation>().Where(t => t.LanguageId == languageId).ToDictionary(t => t.TranslationCode, t => t.Value);
		}
	}
}