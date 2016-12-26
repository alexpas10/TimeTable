using System.Collections.Generic;
using TimeTable.Common.AppConstants;
using TimeTable.DAL.Repository;

namespace TimeTable.Web.Manager {
	public class TranslationManager : ITranslationManager {

		private ITranslationRepository _translationRepository;
		private IDictionary<int, string> _translations;

		public TranslationManager(ITranslationRepository translationRepository) {
			_translationRepository = translationRepository;
		}

		public string Get(int id) {
			if (_translations == null) {
				_translations = _translationRepository.GetTranslations(Dom.DomainValue.English);
			}

			string translation = string.Empty;
			if (_translations.ContainsKey(id)) {
				translation = _translations[id];
			}

			return translation;
		}

	}
}
