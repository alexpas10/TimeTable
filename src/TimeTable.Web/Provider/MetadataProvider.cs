using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TimeTable.Web.DataAnotation;
using TimeTable.Web.Manager;
using TimeTable.Web.Binder;

namespace TimeTable.Web.Provider {

	public class MetadataProvider : IDisplayMetadataProvider, IValidationMetadataProvider, IBindingMetadataProvider {
		public void CreateBindingMetadata(BindingMetadataProviderContext context) {
			if (context == null) {
				throw new ArgumentNullException(nameof(context));
			}
			var multipleSelect = context.Attributes.OfType<MaterialMultipleSelectAttribute>().FirstOrDefault();

			if (multipleSelect != null) {
				context.BindingMetadata.BinderType = typeof(MultipleSelectModelBinder);
			}
		}
		public void CreateDisplayMetadata(DisplayMetadataProviderContext context) {
			var attributes = context.Attributes;
			var displayAttribute = attributes.OfType<MaterialDisplayAttribute>().FirstOrDefault();
			var rangeAttribute = attributes.OfType<RangeAttribute>().FirstOrDefault();
			var maxLengthAttribute = attributes.OfType<MaxLengthAttribute>().FirstOrDefault();

			if (displayAttribute != null) {
				context.DisplayMetadata.AdditionalValues.Add(MVC.ModelMetadata.LabelMessage, displayAttribute.LabelMessage);
			}
			if (rangeAttribute != null) {
				context.DisplayMetadata.AdditionalValues.Add(MVC.ModelMetadata.RangeMax, rangeAttribute.Maximum);
				context.DisplayMetadata.AdditionalValues.Add(MVC.ModelMetadata.RangeMin, rangeAttribute.Minimum);
			}
			if (maxLengthAttribute != null) {
				context.DisplayMetadata.AdditionalValues.Add(MVC.ModelMetadata.MaxLength, maxLengthAttribute.Length);
			}
		}

		public void CreateValidationMetadata(ValidationMetadataProviderContext context) {
			var attributes = context.Attributes;

			var materialRequiredAttribute = attributes.OfType<MaterialRequiredAttribute>().FirstOrDefault();
			var materialNumberAttribute = attributes.OfType<MaterialNumberAttribute>().FirstOrDefault();
			context.ValidationMetadata.IsRequired = (materialRequiredAttribute != null);

			if (materialNumberAttribute != null) {
				context.ValidationMetadata.ValidatorMetadata.Add(materialNumberAttribute);
			}
		}
	}
}

