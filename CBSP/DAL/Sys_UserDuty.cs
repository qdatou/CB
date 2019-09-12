using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CBSP.DAL
{
    public partial class Sys_UserDuty
    {
        public int id { get; set; }

        public int dutyId { get; set; }

        public int userId { get; set; }

    }
}