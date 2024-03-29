﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CBSP.Models
{
    public class SysUserModel
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
        public string education { get; set; }


        [StringLength(50)]
        [Display(Name = "专业")]
        public string major { get; set; }


        [Required]
        [Display(Name = "职务")]
        public IEnumerable<string> dutyId { get; set; }

        [Required]
        [Display(Name = "角色")]
        public IEnumerable<string> roleId { get; set; }

    }
}