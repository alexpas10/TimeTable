namespace TimeTable.Web.Manager {

	public static class MVC {

		public static class Controller {

			public static class Common {
				public const string Index = "index";
			}

			public static class Home {
				public const string Name = "home";
				public const string About = "about";
				public const string List = Common.Index;
			}

			public static class Account {
				public const string Name = "account";
				public const string Login = "login";
				public const string LogOff = "logoff";
				public const string Register = "register";
			}

			public static class Manage {
				public const string Name = "manage";
				public const string Index = Common.Index;
				public const string SetPassword = "setpassword";
				public const string ChangePassword = "changepassword";
				public const string RemoveLogin = "removelogin";
			}

			public static class Room {
				public const string Name = "room";
				public const string Create = "create";
				public const string Delete = "delete";
				public const string Details = "details";
				public const string List = Common.Index;
			}

			public static class Group {
				public const string Name = "group";
				public const string Create = "create";
				public const string Delete = "delete";
				public const string Details = "details";
				public const string List = Common.Index;
			}

			public static class Subject {
				public const string Name = "subject";
				public const string Create = "create";
				public const string Delete = "delete";
				public const string Details = "details";
				public const string List = Common.Index;
			}

			public static class Teacher {
				public const string Name = "teacher";
				public const string Create = "create";
				public const string Delete = "delete";
				public const string Details = "details";
				public const string List = Common.Index;
			}

			public static class Load {
				public const string Name = "load";
				public const string Create = "create";
				public const string Delete = "delete";
				public const string Details = "details";
				public const string List = Common.Index;
			}

			public static class Class {
				public const string Name = "class";
				public const string Create = "create";
				public const string Delete = "delete";
				public const string Details = "details";
				public const string List = Common.Index;
			}
		}

		public static class ViewData {
			public const string TabId = "TabId";
		}

		public static class View {

			public static class Room {
				public const string Details = "Details";
				public const string Create = "_Create";
			}

			public static class Group {
				public const string Details = "Details";
				public const string Create = "_Create";
			}

			public static class Subject {
				public const string Details = "Details";
				public const string Create = "_Create";
			}
			public static class Load {
				public const string Details = "Load";
				public const string Create = "_Create";
			}

			public static class Class {
				public const string Details = "Class";
				public const string Create = "_Create";
			}

			public static class Teacher {
				public const string Details = "Details";
				public const string DetailView = "_DetailView";
				public const string DetailEdit = "_DetailEdit";
				public const string Create = "_Create";
				public const string LoadsTab = "_LoadsTab";
			}

			public static class Shared {
				public const string DeleteConfirmation = "UI/_DeleteConfirmation";
				public const string Login = "_Login";
				public const string Toast = "UI/_Toast";
			}
		}


		public static class ModelMetadata {

			public const string LabelMessage = "LabelMessage";
			public const string MaxLength = "MaxLength";
			public const string Number = "Number";
			public const string RangeMin = "RangeMin";
			public const string RangeMax = "RangeMax";
			public const string Required = "Required";
			public const string ValidationMessage = "ValidationMessage";
		}
	}
}