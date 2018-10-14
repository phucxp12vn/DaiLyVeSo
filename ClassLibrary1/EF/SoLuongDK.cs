namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SoLuongDK")]
    public partial class SoLuongDK
    {
        [StringLength(20)]
        public string ID { get; set; }

        [StringLength(20)]
        public string MaDaiLy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDK { get; set; }

        [Column("SoLuongDK")]
        public int? SoLuongDK1 { get; set; }

        public bool? Flag { get; set; }

        public virtual DaiLy DaiLy { get; set; }
    }
}
