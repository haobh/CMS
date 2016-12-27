namespace ModelEntity.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Module")]
    public partial class Module
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? Status { get; set; }

        public int? DisplayPage { get; set; }
    }
}
