namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLNhaSachFahasaDBContext : DbContext
    {
        public QLNhaSachFahasaDBContext()
            : base("name=QLNhaSachFahasaDBContext")
        {
        }

        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual DbSet<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }
        public virtual DbSet<CHITIETPHIEUXUAT> CHITIETPHIEUXUATs { get; set; }
        public virtual DbSet<CHUONGTRINH_KHUYENMAI> CHUONGTRINH_KHUYENMAI { get; set; }
        public virtual DbSet<CT_CHUONGTRINH_KHUYENMAI> CT_CHUONGTRINH_KHUYENMAI { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<GIABAN> GIABANs { get; set; }
        public virtual DbSet<HINHTHUCSACH> HINHTHUCSACHes { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<MANHINHTRANGCHU> MANHINHTRANGCHUs { get; set; }
        public virtual DbSet<NGONNGU> NGONNGUs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHASANXUAT> NHASANXUATs { get; set; }
        public virtual DbSet<NHOMNGUOIDUNG> NHOMNGUOIDUNGs { get; set; }
        public virtual DbSet<PHANLOAI> PHANLOAIs { get; set; }
        public virtual DbSet<PHIEUNHAP> PHIEUNHAPs { get; set; }
        public virtual DbSet<PHIEUXUAT> PHIEUXUATs { get; set; }
        public virtual DbSet<PHUONGTHUCTHANHTOAN> PHUONGTHUCTHANHTOANs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<THOIGIAN> THOIGIANs { get; set; }
        public virtual DbSet<VAITRO> VAITROes { get; set; }
        public virtual DbSet<XUATXU> XUATXUs { get; set; }
        public virtual DbSet<CAPQUYEN> CAPQUYENs { get; set; }
        public virtual DbSet<HINHANH> HINHANHs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.MASANPHAM)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.MAHOADON)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CHITIETPHIEUNHAP>()
                .Property(e => e.MAHOADONNHAP)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETPHIEUNHAP>()
                .Property(e => e.MASANPHAM)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETPHIEUXUAT>()
                .Property(e => e.MASANPHAM)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETPHIEUXUAT>()
                .Property(e => e.MAPHIEUXUAT)
                .IsUnicode(false);

            modelBuilder.Entity<CHUONGTRINH_KHUYENMAI>()
                .Property(e => e.MACHUONGTRINHKHUYENMAI)
                .IsUnicode(false);

            modelBuilder.Entity<CHUONGTRINH_KHUYENMAI>()
                .Property(e => e.MATHOIGIAN)
                .IsUnicode(false);

            modelBuilder.Entity<CHUONGTRINH_KHUYENMAI>()
                .HasMany(e => e.CT_CHUONGTRINH_KHUYENMAI)
                .WithRequired(e => e.CHUONGTRINH_KHUYENMAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CT_CHUONGTRINH_KHUYENMAI>()
                .Property(e => e.MASANPHAM)
                .IsUnicode(false);

            modelBuilder.Entity<CT_CHUONGTRINH_KHUYENMAI>()
                .Property(e => e.MACHUONGTRINHKHUYENMAI)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MAHOADON)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MAKHACHHANG)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.NGUOICAPNHAT)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MAPHUONGTHUCTHANHTOAN)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.DONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIABAN>()
                .Property(e => e.MAGIA)
                .IsUnicode(false);

            modelBuilder.Entity<GIABAN>()
                .Property(e => e.MASANPHAM)
                .IsUnicode(false);

            modelBuilder.Entity<GIABAN>()
                .Property(e => e.DONGIABAN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GIABAN>()
                .Property(e => e.NGUOICAPNHAT)
                .IsUnicode(false);

            modelBuilder.Entity<HINHTHUCSACH>()
                .Property(e => e.MAHINHTHUC)
                .IsUnicode(false);

            modelBuilder.Entity<HINHTHUCSACH>()
                .HasMany(e => e.SANPHAMs)
                .WithOptional(e => e.HINHTHUCSACH)
                .HasForeignKey(e => e.HINHTHUC);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MAKHACHHANG)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MANHOMNGUOIDUNG)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TENDANGNHAPKHACHHANG)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MATKHAUKHACHHANG)
                .IsUnicode(false);

            modelBuilder.Entity<MANHINHTRANGCHU>()
                .Property(e => e.MAITEM)
                .IsUnicode(false);

            modelBuilder.Entity<NGONNGU>()
                .Property(e => e.MANGONNGU)
                .IsUnicode(false);

            modelBuilder.Entity<NGONNGU>()
                .HasMany(e => e.SANPHAMs)
                .WithOptional(e => e.NGONNGU1)
                .HasForeignKey(e => e.NGONNGU);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MANHACUNGCAP)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.TENDANGNHAPNHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MATKHAUNHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANHOMNGUOIDUNG)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.CMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.DONHANGs)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.NGUOICAPNHAT);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.DONHANGs1)
                .WithOptional(e => e.NHANVIEN1)
                .HasForeignKey(e => e.NGUOICAPNHAT);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.GIABANs)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.NGUOICAPNHAT);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUNHAPs)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.MANHANVIEN);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUNHAPs1)
                .WithOptional(e => e.NHANVIEN1)
                .HasForeignKey(e => e.MANHANVIEN);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUNHAPs2)
                .WithOptional(e => e.NHANVIEN2)
                .HasForeignKey(e => e.MANHANVIEN);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.SANPHAMs)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.NGUOITAO);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.SANPHAMs1)
                .WithOptional(e => e.NHANVIEN1)
                .HasForeignKey(e => e.NGUOICAPNHAT);

            modelBuilder.Entity<NHASANXUAT>()
                .Property(e => e.MANHASANXUAT)
                .IsUnicode(false);

            modelBuilder.Entity<NHASANXUAT>()
                .HasMany(e => e.SANPHAMs)
                .WithOptional(e => e.NHASANXUAT1)
                .HasForeignKey(e => e.NHASANXUAT);

            modelBuilder.Entity<NHOMNGUOIDUNG>()
                .Property(e => e.MANHOMNGUOIDUNG)
                .IsUnicode(false);

            modelBuilder.Entity<PHANLOAI>()
                .Property(e => e.MAPHANLOAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHANLOAI>()
                .Property(e => e.MAPHANLOAICHA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHANLOAI>()
                .HasMany(e => e.SANPHAMs)
                .WithOptional(e => e.PHANLOAI1)
                .HasForeignKey(e => e.PHANLOAI);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.MAHOADONNHAP)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.MANHACUNGCAP)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.TONGGIANHAP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PHIEUNHAP>()
                .HasMany(e => e.CHITIETPHIEUNHAPs)
                .WithRequired(e => e.PHIEUNHAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .Property(e => e.MAPHIEUXUAT)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .Property(e => e.TONGGIAXUAT)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PHIEUXUAT>()
                .HasMany(e => e.CHITIETPHIEUXUATs)
                .WithRequired(e => e.PHIEUXUAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHUONGTHUCTHANHTOAN>()
                .Property(e => e.MAPHUONGTHUCTHANHTOAN)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MASANPHAM)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.PHANLOAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.NGONNGU)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.HINHTHUC)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.DONGIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.QUOCGIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.NHASANXUAT)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.NGUOITAO)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.NGUOICAPNHAT)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETPHIEUNHAPs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETPHIEUXUATs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CT_CHUONGTRINH_KHUYENMAI)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THOIGIAN>()
                .Property(e => e.MATHOIGIAN)
                .IsUnicode(false);

            modelBuilder.Entity<VAITRO>()
                .Property(e => e.MAVAITRO)
                .IsUnicode(false);

            modelBuilder.Entity<XUATXU>()
                .Property(e => e.MAQUOCGIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<XUATXU>()
                .HasMany(e => e.SANPHAMs)
                .WithOptional(e => e.XUATXU)
                .HasForeignKey(e => e.QUOCGIA);

            modelBuilder.Entity<CAPQUYEN>()
                .Property(e => e.MANHOMNGUOIDUNG)
                .IsUnicode(false);

            modelBuilder.Entity<CAPQUYEN>()
                .Property(e => e.MAVAITRO)
                .IsUnicode(false);

            modelBuilder.Entity<HINHANH>()
                .Property(e => e.LINKHINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<HINHANH>()
                .Property(e => e.MASANPHAM)
                .IsUnicode(false);
        }
    }
}
