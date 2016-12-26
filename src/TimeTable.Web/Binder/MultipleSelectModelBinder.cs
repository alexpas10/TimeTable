using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;
using TimeTable.Common;

namespace TimeTable.Web.Binder {
	public class MultipleSelectModelBinder : IModelBinder {

		public Task BindModelAsync(ModelBindingContext bindingContext) {

			if (bindingContext == null) {
				throw new ArgumentNullException(nameof(bindingContext));
			}

			var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			if (valueProviderResult == ValueProviderResult.None) {
				return TaskCache.CompletedTask;
			}

			try {
				if (!string.IsNullOrEmpty(valueProviderResult.Values)) {
					int[] result = valueProviderResult.Values.ToString().SplitToInts(',');
					bindingContext.Result = ModelBindingResult.Success(result);
				}
				return TaskCache.CompletedTask;
			} catch (Exception exception) {
				bindingContext.ModelState.TryAddModelError(
					bindingContext.ModelName,
					exception,
					bindingContext.ModelMetadata);
				return TaskCache.CompletedTask;
			}
		}
	}
}
