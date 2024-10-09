using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class sickGroup
    {

        [Key]
        public int SickGroupID { get; set; }

        [Display(Name = " عنوان گروه بیماری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string GroupTitle { get; set; }

        public virtual List<Sick> Sicks { get; set; }

              public sickGroup()
        {
            
        }
    }
}
