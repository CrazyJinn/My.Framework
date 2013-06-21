using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace My.Common
{
    public static class EnumHelper
    {

        public static IEnumerable<SelectListItem> GetSelectItem(Type type, string model)
        {
            if (type.IsEnum == false) {
                throw new Exception("必须是枚举");
            }

            var itemList = new List<SelectListItem>();
            foreach (var item in Enum.GetValues(type))
            {
                var selectItem = new SelectListItem();
                selectItem.Text = GetDisplayName(type, item);
                selectItem.Value = Convert.ToInt32(item).ToString();
                selectItem.Selected = item.ToString() == model;
                itemList.Add(selectItem);
            }
            return itemList;
        }

        public static string GetDisplayName<TEnum>(TEnum value)
        {
            return GetDisplayName(typeof(TEnum), value);
        }

        public static string GetDisplayName(Type enumType, object value)
        {
            if (enumType == null) throw new ArgumentNullException("enumType");
            if (value == null) throw new ArgumentNullException("value");
            if (!enumType.IsEnum) throw new ArgumentException("enumType must be a enum type.");
            var fieldName = Enum.GetName(enumType, value); //在指定枚举中检索具有指定值的常数的名称
            var fieldInfo = enumType.GetField(fieldName, BindingFlags.Public | BindingFlags.Static); //使用指定绑定约束搜索指定字段
            if (fieldInfo == null) return fieldName;
            var displayAttr = Attribute.GetCustomAttribute(fieldInfo, typeof(DisplayAttribute)) as DisplayAttribute;
            if (displayAttr != null)
            {
                if (displayAttr.ResourceType != null)
                {
                    var r = displayAttr.ResourceType.GetProperty(displayAttr.Name, BindingFlags.Public | BindingFlags.Static);
                    if (r != null)
                    {
                        var result = r.GetValue(null, null);
                        if (result != null)
                        {
                            if (!string.IsNullOrEmpty(result as string))
                            {
                                return result as string;
                            }
                        }
                    }
                    return displayAttr.Name;
                }
                else
                {
                    return displayAttr.Name;
                }
            }
            #region DisPlayName应该是用不到的，先注释
            //var displayNameAttribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DisplayNameAttribute)) as DisplayNameAttribute;
            //if (displayNameAttribute != null)
            //{
            //    return displayNameAttribute.DisplayName;
            //}
            #endregion
            return fieldName;
        }
    }
}
