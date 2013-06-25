using My.Common;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc.Properties;

namespace System.Web.Mvc
{
    public static class MyCheckBoxExtensions
    {
        public static MvcHtmlString MyCheckBox(this HtmlHelper htmlHelper, CheckBox checkBox) {
            return MyCheckBox(htmlHelper, checkBox, null);
        }

        public static MvcHtmlString MyCheckBox(this HtmlHelper htmlHelper, CheckBox checkBox, object htmlAttributes) {
            return MyCheckBox(htmlHelper, checkBox, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString MyCheckBox(this HtmlHelper htmlHelper, CheckBox checkBox, IDictionary<string, object> htmlAttributes) {
            return CheckBoxHelper(htmlHelper, checkBox, htmlAttributes);
        }

        public static MvcHtmlString MyCheckBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression) {
            return MyCheckBoxFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString MyCheckBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) {
            return MyCheckBoxFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString MyCheckBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes) {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            CheckBox checkBox = new CheckBox();
            checkBox.Name = ExpressionHelper.GetExpressionText(expression);
            return CheckBoxHelper(htmlHelper, checkBox, htmlAttributes);
        }

        private static MvcHtmlString CheckBoxHelper(this HtmlHelper htmlHelper, CheckBox checkBox, IDictionary<string, object> htmlAttributes) {

            MyTagBuilder tagBuilder = new MyTagBuilder("input");

            HtmlAttributeBase.MergeHtmlAttributeBase(ref tagBuilder, checkBox);

            tagBuilder.MergeAttribute("type", "checkbox");
            tagBuilder.MergeAttributes(htmlAttributes, true);

            return new MvcHtmlString(tagBuilder.ToString());
        }
    }

    public class CheckBox : HtmlAttributeBase
    {

    }
}
