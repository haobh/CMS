namespace ModelEntity.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Album")]
    public partial class Album
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string MetaTitle { get; set; }

        [StringLength(50)]
        public string Images { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? Order { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string MetaKeywords { get; set; }

        [StringLength(50)]
        public string MetaDescription { get; set; }

        public bool? Status { get; set; }
    }
}
