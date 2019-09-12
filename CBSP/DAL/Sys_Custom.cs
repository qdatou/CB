using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CBSP.DAL
{
    public partial class Sys_Custom
    {
        public int id { get; set; }
        
        [StringLength(50)]
        [Display(Name = "客户名称")]
        public string name { get; set; }

    }
}