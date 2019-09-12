using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CBSP.DAL
{
    public partial class Sys_User
    {
        public int id { get; set; }
        
        [StringLength(50)]
        [Display(Name = "用户名称")]
        public string name { get; set; }

        [StringLength(50)]
        [Display(Name = "性别")]
        public string sex { get; set; }


        [StringLength(50)]
        [Display(Name = "学历")]
        public string education{ get; set; }


        [StringLength(50)]
        [Display(Name = "专业")]
        public string major { get; set; }

        /*
        [ForeignKey("roleId")]
        public virtual ICollection<Sys_Role> sys_Roles { get; set; }
        */
    }
}