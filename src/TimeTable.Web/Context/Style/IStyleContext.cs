using TimeTable.Model;
using TimeTable.Web.Manager;

namespace TimeTable.Web.Context {
	public interface IStyleContext {

		Page Page { get; }
		void InitPage(int pageId);

		ITranslationManager Translations { get; }
	}
}