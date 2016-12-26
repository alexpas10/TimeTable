using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeTable.Web.TagHelpers
{
    /// <see cref="ITagHelper"/> implementation targeting &lt;label&gt; elements with an <c>asp-for</c> attribute.
    /// </summary>
    [HtmlTargetElement("tlabel", Attributes = ForAttributeName)]
    public class TLabelTagHelper : TagHelper
    {
        private const string ForAttributeName = "asp-for";

        /// <summary>
        /// Creates a new <see cref="LabelTagHelper"/>.
        /// </summary>
        /// <param name="generator">The <see cref="IHtmlGenerator"/>.</param>
        public TLabelTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        /// <inheritdoc />
        public override int Order
        {
            get
            {
                return -1000;
            }
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        protected IHtmlGenerator Generator { get; }

        /// <summary>
        /// An expression to be evaluated against the current model.
        /// </summary>
        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        /// <inheritdoc />
        /// <remarks>Does nothing if <see cref="For"/> is <c>null</c>.</remarks>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var tagBuilder = Generator.GenerateLabel(
                ViewContext,
                For.ModelExplorer,
                For.Name,
                labelText: null,
                htmlAttributes: null);

            if (tagBuilder != null)
            {
                output.MergeAttributes(tagBuilder);

                // Do not update the content if another tag helper targeting this element has already done so.
                if (!output.IsContentModified)
                {
                    // We check for whitespace to detect scenarios such as:
                    // <label for="Name">
                    // </label>
                    var childContent = await output.GetChildContentAsync();
                    if (childContent.IsEmptyOrWhiteSpace)
                    {
                        // Provide default label text (if any) since there was nothing useful in the Razor source.
                        if (tagBuilder.InnerHtml != null)
                        {
                            output.Content.SetHtmlContent(tagBuilder.InnerHtml);
                        }
                    }
                    else
                    {
                        output.Content.SetHtmlContent(childContent);
                    }
                }
            }
        }
}
}
