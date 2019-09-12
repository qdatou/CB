namespace CBSP.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sys_Role
    {
        public int id { get; set; }

        [StringLength(50)]
        [Display(Name = "角色名称")]
        public string name { get; set; }


    }
}