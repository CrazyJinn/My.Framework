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
        public static MvcHtmlString MyDropDownList(this HtmlHelper htmlHelper, string name, Type ModelType, string displayText)
        {
            var dataSouce = EnumHelper.GetSelectItem(ModelType, displayText);
            return System.Web.Mvc.Html.SelectExtensions.DropDownList(htmlHelper, name, dataSouce);
        }
    }
}
