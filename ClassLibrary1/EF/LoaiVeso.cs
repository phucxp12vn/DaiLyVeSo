namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiVeso")]
    public partial class LoaiVeso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiVeso()
        {
            KetQuaSoXoes = new HashSet<KetQuaSoXo>();
            PhatHanhs = new HashSet<PhatHanh>();
        }

        [Key]
        [StringLength(20)]
        public string MaLoaiVeSo { get; set; }

        [StringLength(20)]
        public string Tinh { get; set; }

        public bool? Flag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQuaSoXo> KetQuaSoXoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatHanh> PhatHanhs { get; set; }
    }
}
