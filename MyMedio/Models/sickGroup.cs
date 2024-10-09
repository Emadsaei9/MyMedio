using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SickGroup
    {


        [Key]
        public int GrohBimariID { get; set; }

        [Display(Name = " عنوان گروه بیماری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string GroupBimariTitle { get; set; }

        //navigation property

        public virtual List<Sick> Sicks { get; set; }

        public SickGroup()
        {

        }
    }
}
