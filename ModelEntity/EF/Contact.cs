namespace ModelEntity.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Content { get; set; }

        public bool? Status { get; set; }
    }
}
