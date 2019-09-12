using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CBSP.DAL
{
    public partial class Sys_UserRole
    {
        public int id { get; set; }

        public int roleId { get; set; }

        public int userId { get; set; }

        /*
        [ForeignKey("userId")]
        public virtual Sys_User sys_User { get; set; }
        */
    }
}