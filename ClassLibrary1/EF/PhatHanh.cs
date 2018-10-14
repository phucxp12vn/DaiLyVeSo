namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhatHanh")]
    public partial class PhatHanh
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MaDaiLy { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaLoaiVeSo { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhan { get; set; }

        public int? SLBan { get; set; }

        public decimal? DoanhThuDPH { get; set; }

        public decimal? HoaHong { get; set; }

        public decimal? TienThanhToan { get; set; }

        public bool? Flag { get; set; }

        public virtual DaiLy DaiLy { get; set; }

        public virtual LoaiVeso LoaiVeso { get; set; }
    }
}
