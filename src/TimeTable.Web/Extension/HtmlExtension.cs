using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TimeTable.Common;
using TimeTable.Common.AppConstants;
using TimeTable.Web.Context;
using TimeTable.Web.DataAnotation;
using TimeTable.Web.Helpers;
using TimeTable.Web.Manager;
using TimeTable.Web.ViewModel;

namespace TimeTable.Web.Extension {
	public static class HtmlExtension {

		public static IHtmlContent MaterialLabelFor<TModel, TResult>(
			this IHtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, TResult>> expression
		) {
			if (htmlHelper == null) {
				throw new ArgumentNullException(nameof(htmlHelper));
			}

			if (expression == null) {
				throw new ArgumentNullException(nameof(expression));
			}
			var modelExplorer = ExpressionMetadataProvider.FromLambdaExpression(expression, htmlHelper.ViewData, htmlHelper.MetadataProvider);

			string labelMessage = null;
			if (modelExplorer.Metadata.AdditionalValues.ContainsKey(MVC.ModelMetadata.LabelMessage)) {
				labelMessage = modelExplorer.Metadata.AdditionalValues[MVC.ModelMetadata.LabelMessage] as string;
			}

			return htmlHelper.LabelFor(expression, labelText: labelMessage, htmlAttributes: null);
		}

		public static IHtmlContent MaterialTextBoxFor<TModel, TResult>(
			this IHtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, TResult>> expression,
			string ngModel = null,
			IDictionary<string, string> attributes = null
		) {
			if (htmlHelper == null) {
				throw new ArgumentNullException(nameof(htmlHelper));
			}

			if (expression == null) {
				throw new ArgumentNullException(nameof(expression));
			}

			var htmlAttributes = new Dictionary<string, object>();
			var modelExplorer = ExpressionMetadataProvider.FromLambdaExpression(expression, htmlHelper.ViewData, htmlHelper.MetadataProvider);

			if (!attributes.IsNullOrEmpty()) {
				foreach (var item in attributes)
					htmlAttributes.Add(item.Key, item.Value);
			}
			if (!ngModel.IsNullOrEmpty()) {
				htmlAttributes.Add("ng-model", ngModel);
				if (modelExplorer.Model != null) {
					string quote = string.Empty;
					if (modelExplorer.ModelType == typeof(string)) {
						quote = "'";
					}
					htmlAttributes.Add("ng-init", $"{ngModel}={quote}{modelExplorer.Model}{quote}");
				}
			}
			InitHtmlAttributes(modelExplorer, htmlAttributes);

			var htmlBuilder = new HtmlContentBuilder();
			htmlBuilder.SetHtmlContent(htmlHelper.MaterialLabelFor(expression));
			htmlBuilder.AppendHtml(htmlHelper.TextBoxFor(expression, htmlAttributes: htmlAttributes));
			return htmlBuilder;
		}

		public static IHtmlContent MaterialValidationFor<TModel, TResult>(
			this IHtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, TResult>> expression,
			bool enableAngularValidation = true,
			IDictionary<string, string> attributes = null
		) {
			if (htmlHelper == null) {
				throw new ArgumentNullException(nameof(htmlHelper));
			}

			if (expression == null) {
				throw new ArgumentNullException(nameof(expression));
			}

			var htmlAttributes = new Dictionary<string, object>();
			var modelExplorer = ExpressionMetadataProvider.FromLambdaExpression(expression, htmlHelper.ViewData, htmlHelper.MetadataProvider);

			if (!attributes.IsNullOrEmpty()) {
				foreach (var item in attributes)
					htmlAttributes.Add(item.Key, item.Value);
			}

			if (enableAngularValidation) {
				List<string> validationCriteria = new List<string>();
				if (modelExplorer.Metadata.AdditionalValues.ContainsKey(MVC.ModelMetadata.RangeMax)) {
					validationCriteria.Add("'max'");
				}
				if (modelExplorer.Metadata.AdditionalValues.ContainsKey(MVC.ModelMetadata.RangeMin)) {
					validationCriteria.Add("'min'");
				}
				if (modelExplorer.Metadata.AdditionalValues.ContainsKey(MVC.ModelMetadata.MaxLength)) {
					validationCriteria.Add("'maxlength'");
				}
				if (modelExplorer.Metadata.IsRequired) {
					validationCriteria.Add("'required'");
				}
				var validationCriteriaExpression = string.Join(",", validationCriteria);
				if (!validationCriteriaExpression.IsNullOrEmpty()) {
					validationCriteriaExpression = "[" + validationCriteriaExpression + "]";
				}

				htmlAttributes.Add("ng-message-exp", validationCriteriaExpression);
			}

			var htmlBuilder = new HtmlContentBuilder();
			htmlBuilder.AppendHtml(htmlHelper.ValidationMessageFor(expression, null, htmlAttributes: htmlAttributes));
			return htmlBuilder;
		}

		public static IHtmlContent MaterialSelectFor<TModel, TResult>(
			this IHtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, TResult>> expression,
			IEnumerable<SelectItemVM> selectItems,
			string ngModel = null,
			bool multiple = false,
			bool enableAngularValidation = true,
			bool enforceRequired = false,
			IDictionary<string, string> attributes = null
		) {
			if (htmlHelper == null) {
				throw new ArgumentNullException(nameof(htmlHelper));
			}

			if (expression == null) {
				throw new ArgumentNullException(nameof(expression));
			}

			var htmlAttributes = new Dictionary<string, object>();
			var modelExplorer = ExpressionMetadataProvider.FromLambdaExpression(expression, htmlHelper.ViewData, htmlHelper.MetadataProvider);

			if (!attributes.IsNullOrEmpty()) {
				foreach (var item in attributes)
					htmlAttributes.Add(item.Key, item.Value);
			}
			if (!ngModel.IsNullOrEmpty()) {
				htmlAttributes.Add("ng-model", ngModel);
				var ngModelValue = string.Empty;
				if ((!multiple && modelExplorer.Model != null && (int)modelExplorer.Model != default(int))
					|| (multiple && modelExplorer.Metadata.IsCollectionType && (modelExplorer.Model as IEnumerable).Any())) {
					ngModelValue = modelExplorer.Model.ToString();
				} else if (enforceRequired) {
					ngModelValue = selectItems.FirstOrDefault()?.Id.ToString();
				}
				htmlAttributes.Add("ng-init", $"{ngModel}='{ngModelValue}'");
			}

			if (modelExplorer.Metadata.IsRequired) {
				htmlAttributes.Add("required", null);
			}

			var inputHtmlBuilder = new HtmlContentBuilder();
			inputHtmlBuilder.SetHtmlContent(htmlHelper.MaterialLabelFor(expression));
			var tagBuilder = new TagBuilder("md-select");
			tagBuilder.TagRenderMode = TagRenderMode.Normal;
			tagBuilder.Attributes.Add("name", modelExplorer.Metadata.PropertyName);
			string labelMessage = modelExplorer.Metadata.PropertyName;
			if (modelExplorer.Metadata.AdditionalValues.ContainsKey(MVC.ModelMetadata.LabelMessage)) {
				labelMessage = modelExplorer.Metadata.AdditionalValues[MVC.ModelMetadata.LabelMessage] as string;
				tagBuilder.Attributes.Add("placeholder", labelMessage);
			}
			if (multiple) {
				tagBuilder.Attributes.Add("multiple", null);
			}
			foreach (var item in htmlAttributes) {
				tagBuilder.Attributes.Add(item.Key, item.Value?.ToString());
			}
			foreach (var item in selectItems) {
				var mdOptionTagBuilder = new TagBuilder("md-option");
				mdOptionTagBuilder.TagRenderMode = TagRenderMode.Normal;
				mdOptionTagBuilder.Attributes.Add("value", item.Id.ToString());
				var value = (item.Value.IsNullOrEmpty()) ? StyleContext.Current.Translations.Get(item.ValueCode) : item.Value;
				mdOptionTagBuilder.InnerHtml.SetContent(value);
				tagBuilder.InnerHtml.AppendHtml(mdOptionTagBuilder);
			}
			inputHtmlBuilder.AppendHtml(tagBuilder);

			return inputHtmlBuilder;
		}

		private static void InitHtmlAttributes(ModelExplorer modelExplorer, Dictionary<string, object> htmlAttributes) {
			if (modelExplorer.Metadata.AdditionalValues.ContainsKey(MVC.ModelMetadata.RangeMax)) {
				htmlAttributes.Add("max", modelExplorer.Metadata.AdditionalValues[MVC.ModelMetadata.RangeMax].ToString());
			}
			if (modelExplorer.Metadata.AdditionalValues.ContainsKey(MVC.ModelMetadata.RangeMin)) {
				htmlAttributes.Add("min", modelExplorer.Metadata.AdditionalValues[MVC.ModelMetadata.RangeMin].ToString());
			}
			if (modelExplorer.Metadata.AdditionalValues.ContainsKey(MVC.ModelMetadata.MaxLength)) {
				htmlAttributes.Add("maxlength", modelExplorer.Metadata.AdditionalValues[MVC.ModelMetadata.MaxLength].ToString());
			}
			if (modelExplorer.Metadata.IsRequired) {
				htmlAttributes.Add("required", null);
			}
			if (modelExplorer.Metadata.ValidatorMetadata.OfType<MaterialNumberAttribute>().Any()) {
				htmlAttributes.Add("type", "number");
			}
		}
	}
}
