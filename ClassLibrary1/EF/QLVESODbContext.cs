namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLVESODbContext : DbContext
    {
        public QLVESODbContext()
            : base("name=QLVESO")
        {
        }

        public virtual DbSet<DaiLy> DaiLies { get; set; }
        public virtual DbSet<Giai> Giais { get; set; }
        public virtual DbSet<KetQuaSoXo> KetQuaSoXoes { get; set; }
        public virtual DbSet<LoaiVeso> LoaiVesoes { get; set; }
        public virtual DbSet<PhatHanh> PhatHanhs { get; set; }
        public virtual DbSet<PhieuChi> PhieuChis { get; set; }
        public virtual DbSet<PhieuThu> PhieuThus { get; set; }
        public virtual DbSet<SoLuongDK> SoLuongDKs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DaiLy>()
                .Property(e => e.MaDaiLy)
                .IsUnicode(false);

            modelBuilder.Entity<DaiLy>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<DaiLy>()
                .HasMany(e => e.PhatHanhs)
                .WithRequired(e => e.DaiLy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Giai>()
                .Property(e => e.MaGiai)
                .IsUnicode(false);

            modelBuilder.Entity<Giai>()
                .Property(e => e.SoTienNhan)
                .HasPrecision(19, 3);

            modelBuilder.Entity<KetQuaSoXo>()
                .Property(e => e.MaLoaiVeSo)
                .IsUnicode(false);

            modelBuilder.Entity<KetQuaSoXo>()
                .Property(e => e.MaGiai)
                .IsUnicode(false);

            modelBuilder.Entity<KetQuaSoXo>()
                .Property(e => e.SoTrung)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiVeso>()
                .Property(e => e.MaLoaiVeSo)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiVeso>()
                .HasMany(e => e.PhatHanhs)
                .WithRequired(e => e.LoaiVeso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhatHanh>()
                .Property(e => e.MaDaiLy)
                .IsUnicode(false);

            modelBuilder.Entity<PhatHanh>()
                .Property(e => e.MaLoaiVeSo)
                .IsUnicode(false);

            modelBuilder.Entity<PhatHanh>()
                .Property(e => e.DoanhThuDPH)
                .HasPrecision(19, 3);

            modelBuilder.Entity<PhatHanh>()
                .Property(e => e.HoaHong)
                .HasPrecision(2, 0);

            modelBuilder.Entity<PhatHanh>()
                .Property(e => e.TienThanhToan)
                .HasPrecision(19, 3);

            modelBuilder.Entity<PhieuChi>()
                .Property(e => e.MaPhieuChi)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuChi>()
                .Property(e => e.SoTien)
                .HasPrecision(19, 3);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.MaPhieuThu)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.MaDaiLy)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.SoTienNop)
                .HasPrecision(19, 3);

            modelBuilder.Entity<SoLuongDK>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<SoLuongDK>()
                .Property(e => e.MaDaiLy)
                .IsUnicode(false);
        }
    }
}
