using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TimeTable.DAL.Repository;
using TimeTable.Model;

namespace TimeTable.DAL {

	public partial class DbInitializer {

		private IRepository<DbContext> _repository;

		private static Random rand = new Random();

		public IRepository<DbContext> Repository {
			get {
				return _repository;
			}

			set {
				_repository = value;
			}
		}

		#region Helper enums
		enum Subjects {
			Мат_аналіз = 1,
			Програмування,
			Іноземна,
			Дискретна_математика,
			Алгебра_і_геометрія,
			Історія_України,
			Олімп_задачі_з_інформатики,
			Основи_інформаційних_техн_,
			Лінійна_алгебра,
			Пакети_прикладних_програм,
			Матем_логіка_та_теорія_алгоритмів,
			Громадське_здоров_я_та_медицина,
			Обчислювальна_геометрія_та_комп_графіка,
			Об_єкто_орієнтоване_програмування,
			Розробка_UI_UX_дизайну,
			Диф_рівняння,
			Комп_ютерна_математика,
			Основи_інформаційної_безпеки,
			ПЗОС,
			Алгебра_і_теорія_чисел,
			Методика_соціально_виховної_роботи_в_сучасній_школі,
			Програмування_та_підтримка_веб_застосувань,
			Економіка_основи_бух_обліку,
			Спеціалізовані_мови_програмування,
			Мод_жорст_сист_на_ЕОМ,
			Рівняння_з_частинними_похідними,
			Педагогічна_психологія,
			ТЙМС,
			Методи_обчислень,
			Рівняння_математичної_фізики,
			Visual_Basic_та_його_діалекти,
			Технології_програмування_на_Java,
			Інформаційні_технології_в_економіці,
			Основи_Internet_технологій,
			Сучасні_СУБД,
			Психологія_та_МСВР,
			Економіка,
			Інф_техн_в_сист_аналізі,
			Комп_ютерне_моделювання_природних_процесів,
			Диференціальна_геометрія_і_топологія,
			Комплексний_аналіз,
			Основи_теорії_груп,
			Теорія_міри_та_інтеграла,
			Узагальнення_функції_та_їх_застосування_у_МФ,
			Загальна_теорія_функцій,
			Проектування_програмних_систем,
			Програмування_мовою_Python,
			Математична_економіка,
			Випадкові_процеси,
			Методи_оптимізації,
			Інф_технології_управління,
			Математичне_моделювання_та_системний_аналіз,
			Прикладний_статистичний_аналіз,
			Інформаційні_системи_обліку,
			Статистичне_моделювання,
			Front_end_робробка_веб_додатків,
			Теорія_керування,
			Інф_системи_менеджменту_та_маркетингу,
			Методика_викладання_математики_та_інформатики,
			Платформи_корпоративних_інформаційних_систем,
			Теорія_програмування,
			Гіперкомплексні_системи,
			Елементарна_математика_та_методика_викладання,
			Геометричні_перетворення,
			Математична_логіка,
			Математична_статистика_з_елементами_теорії_випадкових_процесів,
			КЗ_для_ПР_2_го_порядку,
			ЕКЗ_2_го_П,
			ГБП,
			Теоретична_механіка,
			ТВП,
			Захист_інформації_в_БД,
			Індивід_робота_СЗІ,
			Розробка_крос_платформенних_додатків,
			Системи_захисту_інформації,
			Інформаційний_менеджмент_проектів,
			Технологія_розробки_РБД,
			Комунікації_та_теорія_конфліктів,
			Java_технології_клієнт_серверних_систем,
			ММДС,
			ККПтаМН,
			ВРМПН,
			Технології_робробки_ІС,
			Теорія_і_практика_бізнес_планування,
			Сіткове_планування,
			МТІМСуЗММ,
			ЕР_та_М_його_М,
			Методика_викладання_математики_та_інформатики_у_ВНЗ,
			РПД_для_МП,
			Охорона_праці_в_галузі,
			Програмні_засоби_управління_проектами,
			Розробка_пр_додатків_для_мобільних_пристроїв,
			КЗІБ,
			Педагогіка_та_психологія_у_ВШ,
			Моделі_виживання,
			СЙЗОК_та_їх_Р_на_ПК,
			Стохастичне_моделювання,
			Математика_фінансів,
			Стат_мод_у_ризик_страхув,
			Сучасні_комп_моделі_ринку_цінних_паперів,
			КСППР,
			Стохастичне_прогнозування_на_ПК,
			Науковий_семінар,
			Аналітична_геометрія,
			Операційні_системи_та_системне_програмування,
			Бази_данних_та_Інформаційні_системи
		}
		enum Teachers {
			Городецький = 1,
			Житарюк,
			Сікора,
			Боднарук,
			МартинюкО,
			Колісник,
			МартинюкС,
			Мироник,
			ЛучкоВС,
			Матійчук,
			ЛенюкМ,
			Петришин,
			Пукальський,
			Блажевський,
			Лусте,
			Перун,
			ЛенюкО,
			ЛучкоВМ,
			Мельничук,
			Тупкало,
			Ісарюк,
			Черевко,
			Піддубна,
			Кушнірчук,
			Готинчан,
			Клевчук,
			Пасічник,
			Івасюк,
			Караванова,
			Матвій,
			Фратавчан,
			Нестеренко,
			Горбатенко,
			Перцов,
			Ілліка,
			Шкільнюк,
			Строєв,
			Дорош,
			Малик,
			Ясинський,
			Антонюк,
			Дорошенко,
			Лукашів,
			Юрченко,
			МаслюченкоВ,
			МаслюченкоО,
			Михайлюк,
			Попов,
			ЛінчукС,
			ЛінчукЮ,
			Бігун,
			Данилюк,
			Краснокутська,
			Любарщук,
			Маценко,
			Мельник,
			Романенко,
			Скутар,
			Сопронюк,
			Філіпчук,
			Чикрій,
			Шепетюк,
			Юрійчук,
			Фотій,
			Звоздецький,
			Карлова,
			Сергеєва,
			Довгей,
			Собчук,
			Гуцул,
			Літовченко
		}
		#endregion

		public DbInitializer(IRepository<DbContext> repository) {
			Repository = repository;
		}

		public void InitializeSet<TEntity>(IEnumerable<TEntity> entities, bool afresh = true) where TEntity : BaseModel {
			if (afresh) {
				Repository.DeleteRange<TEntity>(t => true);
				Repository.UnitOfWork.SaveChanges();
				Repository.AddRange(entities);
			} else {
				foreach (var item in entities) {
					Repository.AddOrUpdate(item);
					Console.WriteLine($"Processing item Id: {item.Id}");
				}
			}
			Repository.UnitOfWork.SaveChanges();
		}

		public void InitializeAll(bool afresh = true) {

			using (var transaction = Repository.UnitOfWork.DbContext.Database.BeginTransaction()) {
				try {
					InitializeSet(TranslationCodeData, afresh);
					InitializeSet(TranslationData, afresh);
					InitializeSet(PageData, afresh);
					InitializeSet(DomainValueTypeData, afresh);
					InitializeSet(DomainValueData, afresh);
					InitializeSet(BuildingData, afresh);
					InitializeSet(RoomData, afresh);
					InitializeSet(SubjectData, afresh);
					InitializeSet(TeacherData, afresh);
					InitializeSet(SubjectTeacherData, afresh);
					InitializeSet(GroupData, afresh);
					InitializeSet(GroupRelationData, afresh);
					InitializeSet(LoadData, afresh);
					InitializeSet(ClassData, afresh);

					transaction.Commit();
				} catch (Exception) {
					transaction.Rollback();
				}
			}
		}

		public void UpdateTable(string tableName, bool afresh = false) {
			switch (tableName) {
				case nameof(TranslationCode):
					InitializeSet(TranslationCodeData, afresh);
					break;
				case nameof(Translation):
					InitializeSet(TranslationData, true);
					break;
				case nameof(Page):
					InitializeSet(PageData, afresh);
					break;
				case nameof(DomainValue):
					InitializeSet(DomainValueData, afresh);
					break;
				case nameof(DomainValueType):
					InitializeSet(DomainValueTypeData, afresh);
					break;
				case nameof(Building):
					InitializeSet(BuildingData, afresh);
					break;
				case nameof(Room):
					InitializeSet(RoomData, afresh);
					break;
				case nameof(Subject):
					InitializeSet(SubjectData, afresh);
					break;
				case nameof(Teacher):
					InitializeSet(TeacherData, afresh);
					break;
				case nameof(SubjectTeacher):
					InitializeSet(SubjectTeacherData, afresh);
					break;
				case nameof(Group):
					InitializeSet(GroupData, afresh);
					break;
				case nameof(GroupRelation):
					InitializeSet(GroupRelationData, afresh);
					break;
				case nameof(Load):
					InitializeSet(LoadData, afresh);
					break;
				case nameof(Class):
					InitializeSet(ClassData, afresh);
					break;

				default:
					break;
			}
		}

		public async void InitializeIdentity(DbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) {
			if (!await roleManager.RoleExistsAsync("Admin")) {
				var role = new IdentityRole();
				role.Name = "Admin";
				await roleManager.CreateAsync(role);

				var user = new ApplicationUser() {
					UserName = "admin@gmail.com",
					Email = "admin@gmail.com",
				};
				string userPWD = "@Bcd0007";

				var checkUser = await userManager.CreateAsync(user, userPWD);

				if (checkUser.Succeeded) {
					await userManager.AddToRoleAsync(user, "Admin");
				}
			}
		}
	}
}