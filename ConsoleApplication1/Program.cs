using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.Mvc;
using Microsoft.VisualStudio.Web.Mvc.UserInterface;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args) {
            foreach (PropertyInfo prop in typeof(Test).GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
                foreach (object attribute in prop.GetCustomAttributes(true)) {
                    if (attribute is RegularExpressionAttribute) {
                        var a = attribute as RegularExpressionAttribute;
                        Console.Write(a.ErrorMessage);
                    }
                }
            }

            Console.ReadLine();

        }
    }
    public class Test
    {
        [RegularExpression(@"((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)")]
        public string Tel { get; set; }
    }
}
