namespace CBSP.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dict_Duty
    {
        public int id { get; set; }

        [StringLength(50)]
        [Display(Name = "职务")]
        public string name { get; set; }

    }
}