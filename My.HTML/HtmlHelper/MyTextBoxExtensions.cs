using My.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;


namespace System.Web.Mvc
{
    public static class MyTextBoxExtensions
    {
        public static MvcHtmlString MyTextBox(this HtmlHelper htmlHelper, TextBox textBox) {
            return MyTextBox(htmlHelper, textBox, null);
        }

        public static MvcHtmlString MyTextBox(this HtmlHelper htmlHelper, TextBox textBox, object htmlAttributes) {
            return MyTextBox(htmlHelper, textBox, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString MyTextBox(this HtmlHelper htmlHelper, TextBox textBox, IDictionary<string, object> htmlAttributes) {
            return TextBoxHelper(htmlHelper, textBox, htmlAttributes);
        }

        public static MvcHtmlString MyTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression) {
            return MyTextBoxFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString MyTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) {
            return MyTextBoxFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString MyTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes) {

            TextBox textBox = new TextBox();
            textBox.Name = ExpressionHelper.GetExpressionText(expression);

            Type intType = typeof(int);
            Type dateTimeType = typeof(DateTime);
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            foreach (PropertyInfo prop in metadata.ContainerType.GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
                if (prop.Name == metadata.PropertyName) {
                    if (prop.PropertyType == intType) {
                        textBox.TextBoxType = TextBoxType.Int;
                    }
                    else if (prop.PropertyType == dateTimeType) {
                        textBox.TextBoxType = TextBoxType.DateTime;
                    }
                    foreach (object attribute in prop.GetCustomAttributes(true)) {
                        var placeholder = attribute as PlaceholderAttribute;
                        if (placeholder != null) {
                            textBox.PlaceholderStr = placeholder.Msg;
                        }
                        var range = attribute as RangeAttribute;
                        if (range != null) {
                            textBox.RangeMax = (int)range.Maximum;
                            textBox.RangeMin = (int)range.Minimum;
                        }
                    }
                }
            }

            return TextBoxHelper(htmlHelper, textBox, htmlAttributes);
        }

        private static MvcHtmlString TextBoxHelper(this HtmlHelper htmlHelper, TextBox textBox, IDictionary<string, object> htmlAttributes) {

            MyTagBuilder tagBuilder = new MyTagBuilder("input");

            HtmlAttributeBase.MergeHtmlAttributeBase(ref tagBuilder, textBox);

            //默认Type为Text。一般来说这个控件里面都应该是这个
            tagBuilder.MergeAttribute("type", "text");
            switch (textBox.TextBoxType) {
                case TextBoxType.String:

                    break;
                case TextBoxType.Int:
                    tagBuilder.MergeAttribute("class", "spinner input-mini");
                    break;
                case TextBoxType.Decimal:
                    break;
                case TextBoxType.Area:

                    break;
                case TextBoxType.DateTime:

                    tagBuilder.MergeAttribute("class", "input-medium datepick");
                    break;
                default:
                    tagBuilder.MergeAttribute("type", "text");
                    break;
            }
            if (!String.IsNullOrEmpty(textBox.PlaceholderStr)) {
                tagBuilder.MergeAttribute("placeholder", textBox.PlaceholderStr);
            }


            tagBuilder.MergeAttributes(htmlAttributes, true);

            return new MvcHtmlString(tagBuilder.ToString());
        }
    }

    public class TextBox : HtmlAttributeBase
    {
        public int RangeMin { get; set; }
        public int RangeMax { get; set; }

        /// <summary>
        /// Placeholder的信息
        /// </summary>
        public string PlaceholderStr { get; set; }

        public TextBoxType TextBoxType { get; set; }
    }

    /// <summary>
    /// 输入框类型
    /// </summary>
    /// <Create>By Jinn 2013.1.1</Create>
    public enum TextBoxType
    {
        /// <summary>
        /// 字符串输入框
        /// </summary>
        String = 1,
        /// <summary>
        /// 整形输入框
        /// </summary>
        Int = 2,
        /// <summary>
        /// 小数输入框
        /// </summary>
        Decimal = 4,
        /// <summary>
        /// 文本域输入框
        /// </summary>
        Area = 8,
        /// <summary>
        /// 日期输入框
        /// </summary>
        DateTime = 16,
    }
}