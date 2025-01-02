using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DATALAYER
{
    public partial class QLNHANSU : DbContext
    {
        public QLNHANSU()
            : base("name=QLNHANSU")
        {
        }

        public virtual DbSet<BANGCONG> BANGCONGs { get; set; }
        public virtual DbSet<BAOHIEM> BAOHIEMs { get; set; }
        public virtual DbSet<BOPHAN> BOPHANs { get; set; }
        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }
        public virtual DbSet<CONGTY> CONGTies { get; set; }
        public virtual DbSet<DANTOC> DANTOCs { get; set; }
        public virtual DbSet<HOPDONG> HOPDONGs { get; set; }
        public virtual DbSet<KHENTHUONG_KYLUAT> KHENTHUONG_KYLUAT { get; set; }
        public virtual DbSet<LOAICA> LOAICAs { get; set; }
        public virtual DbSet<LOAICONG> LOAICONGs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHANVIEN_PHU> NHANVIEN_PHU { get; set; }
        public virtual DbSet<PHONGBAN> PHONGBANs { get; set; }
        public virtual DbSet<PHUCAP> PHUCAPs { get; set; }
        public virtual DbSet<QUYENHAN> QUYENHANs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<TANGCA> TANGCAs { get; set; }
        public virtual DbSet<TONGIAO> TONGIAOs { get; set; }
        public virtual DbSet<TRINHDO> TRINHDOes { get; set; }
        public virtual DbSet<UNGLUONG> UNGLUONGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BANGCONG>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<BAOHIEM>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<HOPDONG>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<KHENTHUONG_KYLUAT>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.BANGCONGs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN_PHU>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<TANGCA>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<UNGLUONG>()
                .Property(e => e.MANV)
                .IsUnicode(false);
        }
    }
}
