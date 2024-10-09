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

        [Key]
        [Display(Name = "شماره پذیرش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int BimarID { get; set; }

        [Display(Name = " عنوان گروه بیماری")]
        [MaxLength(150)]
        public string GroupBimariTitle { get; set; }

        [Display(Name = "گروه بیماری")]
        public int GrohBimariID { get; set; }

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
        public string FamilBimar { get; set; }

        [Display(Name = "کد ملی بیمار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Codemeli { get; set; }

        [Display(Name = "نام پدر بیمار")]
        [MaxLength(250)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NamePedar { get; set; }

        [Display(Name = " وضعیت تاهل ")]
        public string Moteahel { get; set; }

        [Display(Name = "فرزند ")]
        public string Farzand { get; set; }

        [Display(Name = "تعداد فرزند")]
        public string TedadFarzand { get; set; }

        [Display(Name = "رضایت نامه گرفته شد ")]
        public string RezayatName { get; set; }

        [Display(Name = "تصویر رضایت نامه ")]
        public String ImageNameRezayat { get; set; }

        //navigation property
        public SickGroup SickGroup { get; set; }

        public virtual List<Documents> Documentss { get; set; }

        public Sick()
        {

        }
    }
}
