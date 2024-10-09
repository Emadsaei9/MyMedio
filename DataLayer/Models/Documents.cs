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
        public int TazrighID { get; set; }

        [Display(Name = "(CC)حجم تزریق")]
        [MaxLength(250)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string HajmeTazrigh { get; set; }

        [Display(Name = "(غلظت تزریق")]
        [MaxLength(250)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string GelzatTazrigh { get; set; }

        [Display(Name = "ناباروری")]
        public bool Nabarvari { get; set; }

        [Display(Name = "تزریق مفصلی")]
        public bool TazrigheMafsali { get; set; }

        [Display(Name = "پوست و مو")]
        public bool PostVaMo { get; set; }

        [Display(Name = "ترمیم زخم")]
        public bool TarmimZakhm { get; set; }

        [Display(Name = "بیمار نقص ژنتیک دارد")]
        public bool NaghsJenetik { get; set; }

        [Display(Name = "تزریق Local")]
        public bool Local { get; set; }

        [Display(Name = "تزریق Systemic")]
        public bool Systemic { get; set; }

        [Display(Name = "کمیسیون پژشکی موافق است ")]
        public bool Comision { get; set; }

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

        public virtual Sick Sick { get; set; }
        public Documents()
        {
            
        }
    }
}
