using System;

namespace My.Common
{
    /// <summary>
    /// 为页面输入控件提供Placeholder的消息
    /// </summary>
    public class PlaceholderAttribute : Attribute
    {
        public string Msg { get; set; }

        public PlaceholderAttribute(string msg) {
            this.Msg = msg;
        }
    }
}
