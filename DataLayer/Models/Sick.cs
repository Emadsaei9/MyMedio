using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Sick
    {
        
        [Display(Name = "شماره پذیرش")]
        public int sickID { get; set; }

        [Key]
        public int SickGroupID { get; set; }

        [Display(Name = "کاربر")]
        public string KarbarID { get; set; }

        [Display(Name = "تاریخ پذیرش")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "نام بیمار")]
        [MaxLength(250)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NameBimar { get; set; }

        [Display(Name = "نام خانوادگی بیمار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250)]
        public string Family { get; set; }

        [Display(Name = "کد ملی بیمار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Codemeli { get; set; }

        [Display(Name = "نام پدر بیمار")]
        [MaxLength(250)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NamePedar { get; set; }

        [Display(Name = "متاهل")]
        public bool Moteahel { get; set; }

        [Display(Name = "مجرد")]
        public bool Mojarad { get; set; }

        [Display(Name = "فرزند دارد؟")]
        public bool Farzand { get; set; }

        [Display(Name = "تعداد فرزند")]
        public string TedadFarzand { get; set; }

        [Display(Name = "رضایت نامه گرفته شد ")]
        public bool RezayatName { get; set; }

        [Display(Name = "تصویر رضایت نامه ")]
        public string ImageNameRezayat { get; set; }


        public virtual List<sickGroup> SickGroups { get; set; }

        public virtual List<Documents> Documents { get; set; }

        public Sick() 
        {
        }
    }
}
