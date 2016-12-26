using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using TimeTable.Web.Binder;

namespace TimeTable.Web.Provider {
	public class MultipleSelectModelBinderProvider : IModelBinderProvider {
		public IModelBinder GetBinder(ModelBinderProviderContext context) {
			if (context == null) {
				throw new ArgumentNullException(nameof(context));
			}

			var binderType = typeof(MultipleSelectModelBinder);
			if (context.Metadata.BinderType == binderType) {
				return Activator.CreateInstance(binderType) as IModelBinder;
			}

			return null;
		}
	}

}
