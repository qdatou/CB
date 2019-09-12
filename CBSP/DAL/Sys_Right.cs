using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CBSP.DAL
{
    public partial class Sys_Right
    {
        [Key]
        public int id { get; set; }

        public int parent_id { get; set; }

        [StringLength(50)]
        [Display(Name = "功能名称")]
        public string name { get; set; }

        [StringLength(50)]
        [Display(Name = "链接")]
        public string url { get; set; }

        [StringLength(50)]
        [Display(Name = "图标")]
        public string icon { get; set; }
    }
}