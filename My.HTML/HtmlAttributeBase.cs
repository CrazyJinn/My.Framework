using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc
{
    public class HtmlAttributeBase
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public bool IsDisable { get; set; }

        /// <summary>
        /// 向TagBuilder中添加基本的元素属性:ID\Name\Value\IsDisable
        /// </summary>
        internal static void MergeHtmlAttributeBase(ref MyTagBuilder tagBuilder, HtmlAttributeBase htmlAttribute) {

            if (String.IsNullOrEmpty(htmlAttribute.Name)) {
                throw new Exception();
            }
            //如果有ID就用ID，没有就用Name来作为ID
            if (!String.IsNullOrEmpty(htmlAttribute.ID)) {
                tagBuilder.GenerateId(htmlAttribute.ID);
            }
            else {
                tagBuilder.GenerateId(htmlAttribute.Name);
            }
            tagBuilder.MergeAttribute("name", htmlAttribute.Name, true);
            tagBuilder.MergeAttribute("value", htmlAttribute.Value, true);
            if (htmlAttribute.IsDisable) {
                tagBuilder.MergeAttribute("disabled", "disabled");
            }
        }
    }
}
