using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CBSP.DAL
{
    public partial class Sys_Depart
    {
        [Key]
        public int id { get; set; }

        public int parent_id { get; set; }

        [StringLength(50)]
        [Display(Name = "单位名称")]
        public string name { get; set; }

    }
}