// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

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
    public static class SelectExtensions
    {
        public static MvcHtmlString MyDropDownList(this HtmlHelper htmlHelper, string name, Type ModelType, string displayText) {
            var dataSouce = EnumHelper.GetSelectItem(ModelType, displayText);
            return System.Web.Mvc.Html.SelectExtensions.DropDownList(htmlHelper, name, dataSouce);
        }

        public static MvcHtmlString MyDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression) {
            return MyDropDownListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString MyDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) {
            return MyDropDownListFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString MyDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes) {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
         
            Select select = new Select();
            select.Name = ExpressionHelper.GetExpressionText(expression);   
            select.SelectList = EnumHelper.GetSelectItem(metadata.ModelType, "");

            return SelectHelper(htmlHelper, select, htmlAttributes);
        }

        private static MvcHtmlString SelectHelper(this HtmlHelper htmlHelper, Select select, IDictionary<string, object> htmlAttributes) {

            if (select.SelectList == null) {
                var o = htmlHelper.ViewData.Eval(select.Name);
                IEnumerable<SelectListItem> selectList = o as IEnumerable<SelectListItem>;
                select.SelectList = selectList;
            }

            StringBuilder listItemBuilder = new StringBuilder();
            foreach (SelectListItem item in select.SelectList) {
                listItemBuilder.AppendLine(ListItemToOption(item));
            }

            TagBuilder tagBuilder = new TagBuilder("select") {
                InnerHtml = listItemBuilder.ToString()
            };

            //使用Chosen控件。源码地址：http://harvesthq.github.io/chosen/
            tagBuilder.MergeAttribute("class", "chosen-select");

            tagBuilder.MergeAttributes(htmlAttributes, true);

            return new MvcHtmlString(tagBuilder.ToString());

        }

        internal static string ListItemToOption(SelectListItem item) {
            TagBuilder builder = new TagBuilder("option") {
                InnerHtml = HttpUtility.HtmlEncode(item.Text)
            };
            if (item.Value != null) {
                builder.Attributes["value"] = item.Value;
            }
            if (item.Selected) {
                builder.Attributes["selected"] = "selected";
            }
            return builder.ToString(TagRenderMode.Normal);
        }
    }
    public class Select : HtmlAttributeBase
    {
        public IEnumerable<SelectListItem> SelectList { get; set; }
    }
}
