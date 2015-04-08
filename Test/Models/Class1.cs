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
        [Key]
        public Guid hahahah { get; set; }

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
        请选择 = 0,
        测试1 = 1,
        [Display(Name = "Test2")]
        测试2 = 2,
        [Display(Name = "Test3")]
        测试3 = 3,
    }
}