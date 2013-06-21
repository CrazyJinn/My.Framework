
namespace System.Web.Mvc
{

    /// <summary>
    /// 包含用于创建 HTML 元素的类和属性。此类用于编写帮助器，例如那些可在 System.Web.Helpers 命名空间中找到的帮助器。
    /// 不可再次进行编码
    /// </summary>
    public class MyTagBuilder : TagBuilder, IHtmlString
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagName"></param>
        public MyTagBuilder(string tagName)
            : base(tagName) {
        }


        public MyTagBuilder OnClick(string functionName) {
            this.MergeAttribute("onclick", functionName);
            return this;
        }

        public MyTagBuilder OnMouseMove(string functionName) {
            this.MergeAttribute("onmousemove", functionName);
            return this;
        }

        public MyTagBuilder OnFocus(string functionName) {
            this.MergeAttribute("onfocus", functionName);
            return this;
        }

        public MyTagBuilder OnChange(string functionName) {
            this.MergeAttribute("onchange", functionName);
            return this;
        }

        public MyTagBuilder OnBlur(string functionName) {
            this.MergeAttribute("onblur", functionName);
            return this;
        }

        public MyTagBuilder OnKeyUp(string functionName) {
            this.MergeAttribute("onkeyup", functionName);
            return this;
        }

        /// <summary>
        /// 当按下回车时触发事件
        /// </summary>
        /// <Create>By Jinn 2012.1.30</Create>
        public MyTagBuilder OnEnter(string functionName) {
            this.MergeAttribute("onkeydown", "if(event.keyCode==13){+" + functionName + "}");
            return this;
        }

        public MyTagBuilder DisTrim() {
            this.MergeAttribute("trim", "false", true);
            return this;
        }


        //public override string ToString() {
        //    return base.ToString();
        //}

        public string ToHtmlString() {
            return base.ToString();
        }
    }
}
