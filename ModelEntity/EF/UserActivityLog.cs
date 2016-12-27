namespace ModelEntity.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserActivityLog")]
    public partial class UserActivityLog
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string ActionName { get; set; }

        [StringLength(50)]
        public string ActionDate { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string SessionID { get; set; }
    }
}
