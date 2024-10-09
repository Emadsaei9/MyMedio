using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Documents
    {

        [Key]
        [Display(Name = "کد تزریق")]
        public int TazrighID { get; set; }

        [Display(Name = "کد بیمار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int BimarID { get; set; }

        [Display(Name = "(CC)حجم تزریق")]
        [MaxLength(250)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string HajmeTazrigh { get; set; }

        [Display(Name = "(غلظت تزریق")]
        [MaxLength(250)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string GelzatTazrigh { get; set; }

        [Display(Name = " نقص ژنتیک ")]
        public string NaghsJenetik { get; set; }

        [Display(Name = "نوع تزریق")]
        public string NoeTazrigh { get; set; }

        [Display(Name = "نظر کمیسیون پزشکی ")]
        public string Comision { get; set; }

        [Display(Name = "علت تزیریق")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string ElatTzrigh { get; set; }

        [Display(Name = "سابقه بیماری قبلی  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string SabegheGhabli { get; set; }

        [Display(Name = "سابقه درمان ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string SabegheDarman { get; set; }

        [Display(Name = "سابقه بیماری خانوادگی  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string SabegheFamily { get; set; }

        [Display(Name = "شرح حال بعد از تزریق")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string SharhHal { get; set; }

        //navigation property

        public Sick Sick { get; set; }
        public Documents()
        {

        }
    }
}
