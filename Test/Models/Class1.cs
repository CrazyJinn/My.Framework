using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using My.Common;

namespace Test.Models
{
    public class Class1
    {
        [Required]
        public Guid ID { get; set; }

        [ScaffoldColumn(false)]
        [Placeholder("String1")]
        [MinLength(2)]
        [MaxLength(4)]
        public string string1 { get; set; }

        [Required]
        [Display(Name = "String2")]
        [RegularExpression("\\d{3}")]
        [Placeholder("String2")]
        public string string2 { get; set; }

        [Required]
        [Range(1, 10)]
        public int int1 { get; set; }

        [Display(Name = "ScheduledInfo")]
        public EnumTest enum1 { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Placeholder("Enter Money")]
        public decimal money { get; set; }

        [Required]
        public bool booltry { get; set; }
    }

    public enum EnumTest
    {
        [Display(Name = "Please select one")]
        Unkonw = 0,
        [Display(Name = "Test1")]
        test1 = 1,
        [Display(Name = "Test2")]
        test2 = 2,
        [Display(Name = "Test3")]
        test3 = 3,
    }
}