using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CBSP.Models
{
    public class AccountModel
    {
        [Required]
        public string 用户名 { get; set; }
        [Required]
        public string 密码 { get; set; }

    }
}