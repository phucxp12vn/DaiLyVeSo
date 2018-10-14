namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KetQuaSoXo")]
    public partial class KetQuaSoXo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(20)]
        public string MaLoaiVeSo { get; set; }

        [StringLength(20)]
        public string MaGiai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySo { get; set; }

        [StringLength(10)]
        public string SoTrung { get; set; }

        public bool? Flag { get; set; }

        public virtual Giai Giai { get; set; }

        public virtual LoaiVeso LoaiVeso { get; set; }
    }
}
