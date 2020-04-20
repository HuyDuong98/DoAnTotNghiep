namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLNhaSachFahasaDBContext : DbContext
    {
        public QLNhaSachFahasaDBContext()
            : base("name=QLNhaSachFahasa")
        {
        }

        public virtual DbSet<CHUONGTRINH_KHUYENMAI> CHUONGTRINH_KHUYENMAI { get; set; }
        public virtual DbSet<CT_CHUONGTRINH_KHUYENMAI> CT_CHUONGTRINH_KHUYENMAI { get; set; }
        public virtual DbSet<CT_HOADON> CT_HOADON { get; set; }
        public virtual DbSet<CT_PHIEUNHAP> CT_PHIEUNHAP { get; set; }
        public virtual DbSet<CT_PHIEUXUAT> CT_PHIEUXUAT { get; set; }
        public virtual DbSet<GIABAN> GIABANs { get; set; }
        public virtual DbSet<GROUPPHANLOAI> GROUPPHANLOAIs { get; set; }
        public virtual DbSet<HINHSANPHAM> HINHSANPHAMs { get; set; }
        public virtual DbSet<HINHTHUCSACH> HINHTHUCSACHes { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<KHOHANG> KHOHANGs { get; set; }
        public virtual DbSet<MATHANGKINHDOANH> MATHANGKINHDOANHs { get; set; }
        public virtual DbSet<NGONNGU> NGONNGUs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHASANXUAT> NHASANXUATs { get; set; }
        public virtual DbSet<PHANLOAI> PHANLOAIs { get; set; }
        public virtual DbSet<PHIEUNHAP> PHIEUNHAPs { get; set; }
        public virtual DbSet<PHIEUXUAT> PHIEUXUATs { get; set; }
        public virtual DbSet<PHUONGTHUCTHANHTOAN> PHUONGTHUCTHANHTOANs { get; set; }
        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<THOIGIAN> THOIGIANs { get; set; }
        public virtual DbSet<USERGROUP> USERGROUPs { get; set; }
        public virtual DbSet<VANPHONGPHAM> VANPHONGPHAMs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHUONGTRINH_KHUYENMAI>()
                .Property(e => e.IDCTKM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHUONGTRINH_KHUYENMAI>()
                .Property(e => e.IDTG)
                .IsUnicode(false);

            modelBuilder.Entity<CHUONGTRINH_KHUYENMAI>()
                .Property(e => e.TENCTKM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHUONGTRINH_KHUYENMAI>()
                .HasMany(e => e.CT_CHUONGTRINH_KHUYENMAI)
                .WithRequired(e => e.CHUONGTRINH_KHUYENMAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CT_CHUONGTRINH_KHUYENMAI>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<CT_CHUONGTRINH_KHUYENMAI>()
                .Property(e => e.IDCTKM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT_HOADON>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<CT_HOADON>()
                .Property(e => e.IDHOADON)
                .IsUnicode(false);

            modelBuilder.Entity<CT_HOADON>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CT_PHIEUNHAP>()
                .Property(e => e.IDHDNHAP)
                .IsUnicode(false);

            modelBuilder.Entity<CT_PHIEUNHAP>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<CT_PHIEUXUAT>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<CT_PHIEUXUAT>()
                .Property(e => e.IDXUAT)
                .IsUnicode(false);

            modelBuilder.Entity<GIABAN>()
                .Property(e => e.IDGIA)
                .IsUnicode(false);

            modelBuilder.Entity<GIABAN>()
                .Property(e => e.GIAGIABAN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GROUPPHANLOAI>()
                .Property(e => e.IDGROUPPL)
                .IsUnicode(false);

            modelBuilder.Entity<GROUPPHANLOAI>()
                .Property(e => e.TENGROUPTHELOAI)
                .IsUnicode(false);

            modelBuilder.Entity<HINHSANPHAM>()
                .Property(e => e.LINKHINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<HINHSANPHAM>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<HINHSANPHAM>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<HINHSANPHAM>()
                .Property(e => e.TENHINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<HINHTHUCSACH>()
                .Property(e => e.MAHINHTHUC)
                .IsUnicode(false);

            modelBuilder.Entity<HINHTHUCSACH>()
                .Property(e => e.HINHTHUC)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.IDHOADON)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAKHO)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAPT)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.TONGTIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CT_HOADON)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.IDGROUP)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.HOKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TENKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.QUOCGIA)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.THANHPHO)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.QUAN)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.PHUONG)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DIACHI)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.PASSWORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHOHANG>()
                .Property(e => e.MAKHO)
                .IsUnicode(false);

            modelBuilder.Entity<KHOHANG>()
                .Property(e => e.TENKHO)
                .IsUnicode(false);

            modelBuilder.Entity<KHOHANG>()
                .Property(e => e.DIACHIKHO)
                .IsUnicode(false);

            modelBuilder.Entity<MATHANGKINHDOANH>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<MATHANGKINHDOANH>()
                .Property(e => e.TENMATHANG)
                .IsUnicode(false);

            modelBuilder.Entity<MATHANGKINHDOANH>()
                .HasMany(e => e.CT_CHUONGTRINH_KHUYENMAI)
                .WithRequired(e => e.MATHANGKINHDOANH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MATHANGKINHDOANH>()
                .HasMany(e => e.CT_HOADON)
                .WithRequired(e => e.MATHANGKINHDOANH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MATHANGKINHDOANH>()
                .HasMany(e => e.CT_PHIEUNHAP)
                .WithRequired(e => e.MATHANGKINHDOANH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MATHANGKINHDOANH>()
                .HasMany(e => e.CT_PHIEUXUAT)
                .WithRequired(e => e.MATHANGKINHDOANH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGONNGU>()
                .Property(e => e.MANGONNGU)
                .IsUnicode(false);

            modelBuilder.Entity<NGONNGU>()
                .Property(e => e.NGONNGU1)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MANCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.TENNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.DIACHINSX)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHASANXUAT>()
                .Property(e => e.MANSX)
                .IsUnicode(false);

            modelBuilder.Entity<NHASANXUAT>()
                .Property(e => e.TENNSX)
                .IsUnicode(false);

            modelBuilder.Entity<NHASANXUAT>()
                .Property(e => e.DIACHINSX)
                .IsUnicode(false);

            modelBuilder.Entity<NHASANXUAT>()
                .Property(e => e.THONGTINTHEM)
                .IsUnicode(false);

            modelBuilder.Entity<PHANLOAI>()
                .Property(e => e.MAPL)
                .IsUnicode(false);

            modelBuilder.Entity<PHANLOAI>()
                .Property(e => e.IDGROUPPL)
                .IsUnicode(false);

            modelBuilder.Entity<PHANLOAI>()
                .Property(e => e.TENPL)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.IDHDNHAP)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.MAKHO)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.TONGGIANHAP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PHIEUNHAP>()
                .HasMany(e => e.CT_PHIEUNHAP)
                .WithRequired(e => e.PHIEUNHAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .Property(e => e.IDXUAT)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .Property(e => e.MAKHO)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .Property(e => e.TONGGIAHD)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PHIEUXUAT>()
                .HasMany(e => e.CT_PHIEUXUAT)
                .WithRequired(e => e.PHIEUXUAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHUONGTHUCTHANHTOAN>()
                .Property(e => e.MAPT)
                .IsUnicode(false);

            modelBuilder.Entity<PHUONGTHUCTHANHTOAN>()
                .Property(e => e.TENPT)
                .IsUnicode(false);

            modelBuilder.Entity<ROLE>()
                .Property(e => e.IDROLE)
                .IsUnicode(false);

            modelBuilder.Entity<ROLE>()
                .Property(e => e.TENROLE)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MAPL)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MANGONNGU)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MANSX)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MANCC)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.IDGIA)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MAHINHTHUC)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.TENSACH)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.TACGIA)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.GIASACH)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SACH>()
                .Property(e => e.KICHTHUOC)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.TOMTAC)
                .IsUnicode(false);

            modelBuilder.Entity<THOIGIAN>()
                .Property(e => e.IDTG)
                .IsUnicode(false);

            modelBuilder.Entity<USERGROUP>()
                .Property(e => e.IDGROUP)
                .IsUnicode(false);

            modelBuilder.Entity<USERGROUP>()
                .Property(e => e.TENGROUP)
                .IsUnicode(false);

            modelBuilder.Entity<USERGROUP>()
                .HasMany(e => e.ROLEs)
                .WithMany(e => e.USERGROUPs)
                .Map(m => m.ToTable("CREDENTIAL").MapLeftKey("IDGROUP").MapRightKey("IDROLE"));

            modelBuilder.Entity<VANPHONGPHAM>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<VANPHONGPHAM>()
                .Property(e => e.MANCC)
                .IsUnicode(false);

            modelBuilder.Entity<VANPHONGPHAM>()
                .Property(e => e.MANSX)
                .IsUnicode(false);

            modelBuilder.Entity<VANPHONGPHAM>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<VANPHONGPHAM>()
                .Property(e => e.DONGIAVPP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VANPHONGPHAM>()
                .Property(e => e.KICHTHUOC)
                .IsUnicode(false);

            modelBuilder.Entity<VANPHONGPHAM>()
                .Property(e => e.TENSP)
                .IsUnicode(false);

            modelBuilder.Entity<VANPHONGPHAM>()
                .Property(e => e.GIOITHIEUSP)
                .IsUnicode(false);

            modelBuilder.Entity<VANPHONGPHAM>()
                .Property(e => e.CHATLIEU)
                .IsUnicode(false);
        }


        //public System.Data.Entity.DbSet<QLNhaSachFahasaDBContext.Models.LoginModel> LoginModels { get; set; }
    }
}
