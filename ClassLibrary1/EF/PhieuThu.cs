namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuThu")]
    public partial class PhieuThu
    {
        [Key]
        [StringLength(20)]
        public string MaPhieuThu { get; set; }

        [StringLength(20)]
        public string MaDaiLy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNop { get; set; }

        public decimal? SoTienNop { get; set; }

        public bool? Flag { get; set; }

        public virtual DaiLy DaiLy { get; set; }
    }
}
