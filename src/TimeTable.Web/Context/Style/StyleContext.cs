using TimeTable.DAL.Repository;
using TimeTable.Model;
using TimeTable.Web.Manager;

namespace TimeTable.Web.Context {

	public class StyleContext : IStyleContext {
		private Page _page;

		private ITranslationManager _translationManager;
		private IPageRepository _pageRepository;

		public static IStyleContext Current { get; set; }

		public ITranslationManager Translations {
			get {
				return _translationManager;
			}
		}

		public Page Page {
			get {
				return _page;
			}
		}

		public StyleContext(ITranslationManager translationManager, IPageRepository pageRepository) {
			_translationManager = translationManager;
			_pageRepository = pageRepository;
		}

		public void InitPage(int pageId) {
			_page = _pageRepository.GetPage(pageId);
		}

	}
}
