using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CBSP.DAL
{
    public partial class Sys_RoleRight
    {
        [Key]
        public int id { get; set; }

        public int roleId { get; set; }

        public int rightId { get; set; }

    }
}