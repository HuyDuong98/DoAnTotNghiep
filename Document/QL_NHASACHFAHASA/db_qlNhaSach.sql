/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     4/19/2020 11:32:17 AM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CHUONGTRINH_KHUYENMAI') and o.name = 'FK_CHUONGTR_CHO_THOIGIAN')
alter table CHUONGTRINH_KHUYENMAI
   drop constraint FK_CHUONGTR_CHO_THOIGIAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CREDENTIAL') and o.name = 'FK_CREDENTI_CREDENTIA_USERGROU')
alter table CREDENTIAL
   drop constraint FK_CREDENTI_CREDENTIA_USERGROU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CREDENTIAL') and o.name = 'FK_CREDENTI_CREDENTIA_ROLE')
alter table CREDENTIAL
   drop constraint FK_CREDENTI_CREDENTIA_ROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CT_CHUONGTRINH_KHUYENMAI') and o.name = 'FK_CT_CHUON_CT_CHUONG_MATHANGK')
alter table CT_CHUONGTRINH_KHUYENMAI
   drop constraint FK_CT_CHUON_CT_CHUONG_MATHANGK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CT_CHUONGTRINH_KHUYENMAI') and o.name = 'FK_CT_CHUON_CT_CHUONG_CHUONGTR')
alter table CT_CHUONGTRINH_KHUYENMAI
   drop constraint FK_CT_CHUON_CT_CHUONG_CHUONGTR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CT_HOADON') and o.name = 'FK_CT_HOADO_CT_HOADON_MATHANGK')
alter table CT_HOADON
   drop constraint FK_CT_HOADO_CT_HOADON_MATHANGK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CT_HOADON') and o.name = 'FK_CT_HOADO_CT_HOADON_HOADON')
alter table CT_HOADON
   drop constraint FK_CT_HOADO_CT_HOADON_HOADON
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CT_PHIEUNHAP') and o.name = 'FK_CT_PHIEU_CT_PHIEUN_PHIEUNHA')
alter table CT_PHIEUNHAP
   drop constraint FK_CT_PHIEU_CT_PHIEUN_PHIEUNHA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CT_PHIEUNHAP') and o.name = 'FK_CT_PHIEU_CT_PHIEUN_MATHANGK')
alter table CT_PHIEUNHAP
   drop constraint FK_CT_PHIEU_CT_PHIEUN_MATHANGK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CT_PHIEUXUAT') and o.name = 'FK_CT_PHIEU_CT_PHIEUX_MATHANGK')
alter table CT_PHIEUXUAT
   drop constraint FK_CT_PHIEU_CT_PHIEUX_MATHANGK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CT_PHIEUXUAT') and o.name = 'FK_CT_PHIEU_CT_PHIEUX_PHIEUXUA')
alter table CT_PHIEUXUAT
   drop constraint FK_CT_PHIEU_CT_PHIEUX_PHIEUXUA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HINHSANPHAM') and o.name = 'FK_HINHSANP_SE_CO_THE_SACH')
alter table HINHSANPHAM
   drop constraint FK_HINHSANP_SE_CO_THE_SACH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HINHSANPHAM') and o.name = 'FK_HINHSANP_SE_KEM_TH_VANPHONG')
alter table HINHSANPHAM
   drop constraint FK_HINHSANP_SE_KEM_TH_VANPHONG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HOADON') and o.name = 'FK_HOADON_CO_PHUONGTH')
alter table HOADON
   drop constraint FK_HOADON_CO_PHUONGTH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HOADON') and o.name = 'FK_HOADON_CUA_KHOHANG')
alter table HOADON
   drop constraint FK_HOADON_CUA_KHOHANG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HOADON') and o.name = 'FK_HOADON_THUOC_KHACHHAN')
alter table HOADON
   drop constraint FK_HOADON_THUOC_KHACHHAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('KHACHHANG') and o.name = 'FK_KHACHHAN_SE_TON_TA_USERGROU')
alter table KHACHHANG
   drop constraint FK_KHACHHAN_SE_TON_TA_USERGROU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHANLOAI') and o.name = 'FK_PHANLOAI__UOC_NHOM_GROUPPHA')
alter table PHANLOAI
   drop constraint FK_PHANLOAI__UOC_NHOM_GROUPPHA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHIEUNHAP') and o.name = 'FK_PHIEUNHA_THUOC_VE_KHOHANG')
alter table PHIEUNHAP
   drop constraint FK_PHIEUNHA_THUOC_VE_KHOHANG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHIEUXUAT') and o.name = 'FK_PHIEUXUA_SE_CO_KHOHANG')
alter table PHIEUXUAT
   drop constraint FK_PHIEUXUA_SE_CO_KHOHANG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SACH') and o.name = 'FK_SACH_CHIA_NGONNGU')
alter table SACH
   drop constraint FK_SACH_CHIA_NGONNGU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SACH') and o.name = 'FK_SACH_CHIA_THEO_HINHTHUC')
alter table SACH
   drop constraint FK_SACH_CHIA_THEO_HINHTHUC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SACH') and o.name = 'FK_SACH_CUNG_CAP_NHACUNGC')
alter table SACH
   drop constraint FK_SACH_CUNG_CAP_NHACUNGC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SACH') and o.name = 'FK_SACH_SAN_XUAT_NHASANXU')
alter table SACH
   drop constraint FK_SACH_SAN_XUAT_NHASANXU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SACH') and o.name = 'FK_SACH_SE_CHUA_MATHANGK')
alter table SACH
   drop constraint FK_SACH_SE_CHUA_MATHANGK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SACH') and o.name = 'FK_SACH_SE__UOC_PHANLOAI')
alter table SACH
   drop constraint FK_SACH_SE__UOC_PHANLOAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SACH') and o.name = 'FK_SACH__UOC_CHIA_GIABAN')
alter table SACH
   drop constraint FK_SACH__UOC_CHIA_GIABAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VANPHONGPHAM') and o.name = 'FK_VANPHONG_CHUA_MATHANGK')
alter table VANPHONGPHAM
   drop constraint FK_VANPHONG_CHUA_MATHANGK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VANPHONGPHAM') and o.name = 'FK_VANPHONG_LIEN_KET__NHACUNGC')
alter table VANPHONGPHAM
   drop constraint FK_VANPHONG_LIEN_KET__NHACUNGC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VANPHONGPHAM') and o.name = 'FK_VANPHONG_SAN_XUAT__NHASANXU')
alter table VANPHONGPHAM
   drop constraint FK_VANPHONG_SAN_XUAT__NHASANXU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CHUONGTRINH_KHUYENMAI')
            and   name  = 'CHO_FK'
            and   indid > 0
            and   indid < 255)
   drop index CHUONGTRINH_KHUYENMAI.CHO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CHUONGTRINH_KHUYENMAI')
            and   type = 'U')
   drop table CHUONGTRINH_KHUYENMAI
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CREDENTIAL')
            and   name  = 'CREDENTIAL2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CREDENTIAL.CREDENTIAL2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CREDENTIAL')
            and   name  = 'CREDENTIAL_FK'
            and   indid > 0
            and   indid < 255)
   drop index CREDENTIAL.CREDENTIAL_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CREDENTIAL')
            and   type = 'U')
   drop table CREDENTIAL
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CT_CHUONGTRINH_KHUYENMAI')
            and   name  = 'CT_CHUONGTRINH_KHUYENMAI2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CT_CHUONGTRINH_KHUYENMAI.CT_CHUONGTRINH_KHUYENMAI2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CT_CHUONGTRINH_KHUYENMAI')
            and   name  = 'CT_CHUONGTRINH_KHUYENMAI_FK'
            and   indid > 0
            and   indid < 255)
   drop index CT_CHUONGTRINH_KHUYENMAI.CT_CHUONGTRINH_KHUYENMAI_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CT_CHUONGTRINH_KHUYENMAI')
            and   type = 'U')
   drop table CT_CHUONGTRINH_KHUYENMAI
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CT_HOADON')
            and   name  = 'CT_HOADON2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CT_HOADON.CT_HOADON2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CT_HOADON')
            and   name  = 'CT_HOADON_FK'
            and   indid > 0
            and   indid < 255)
   drop index CT_HOADON.CT_HOADON_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CT_HOADON')
            and   type = 'U')
   drop table CT_HOADON
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CT_PHIEUNHAP')
            and   name  = 'CHITIETPHIEUNHAP2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CT_PHIEUNHAP.CHITIETPHIEUNHAP2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CT_PHIEUNHAP')
            and   name  = 'CHITIETPHIEUNHAP_FK'
            and   indid > 0
            and   indid < 255)
   drop index CT_PHIEUNHAP.CHITIETPHIEUNHAP_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CT_PHIEUNHAP')
            and   type = 'U')
   drop table CT_PHIEUNHAP
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CT_PHIEUXUAT')
            and   name  = 'CHITIETPHIEUXUAT2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CT_PHIEUXUAT.CHITIETPHIEUXUAT2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CT_PHIEUXUAT')
            and   name  = 'CHITIETPHIEUXUAT_FK'
            and   indid > 0
            and   indid < 255)
   drop index CT_PHIEUXUAT.CHITIETPHIEUXUAT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CT_PHIEUXUAT')
            and   type = 'U')
   drop table CT_PHIEUXUAT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GIABAN')
            and   type = 'U')
   drop table GIABAN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GROUPPHANLOAI')
            and   type = 'U')
   drop table GROUPPHANLOAI
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HINHSANPHAM')
            and   name  = 'SE_KEM_THEO_FK'
            and   indid > 0
            and   indid < 255)
   drop index HINHSANPHAM.SE_KEM_THEO_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HINHSANPHAM')
            and   name  = 'SE_CO_THEO_FK'
            and   indid > 0
            and   indid < 255)
   drop index HINHSANPHAM.SE_CO_THEO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HINHSANPHAM')
            and   type = 'U')
   drop table HINHSANPHAM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HINHTHUCSACH')
            and   type = 'U')
   drop table HINHTHUCSACH
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HOADON')
            and   name  = 'CUA_FK'
            and   indid > 0
            and   indid < 255)
   drop index HOADON.CUA_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HOADON')
            and   name  = 'CO_FK'
            and   indid > 0
            and   indid < 255)
   drop index HOADON.CO_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HOADON')
            and   name  = 'THUOC_FK'
            and   indid > 0
            and   indid < 255)
   drop index HOADON.THUOC_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HOADON')
            and   type = 'U')
   drop table HOADON
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('KHACHHANG')
            and   name  = 'SE_TON_TAI_FK'
            and   indid > 0
            and   indid < 255)
   drop index KHACHHANG.SE_TON_TAI_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('KHACHHANG')
            and   type = 'U')
   drop table KHACHHANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('KHOHANG')
            and   type = 'U')
   drop table KHOHANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MATHANGKINHDOANH')
            and   type = 'U')
   drop table MATHANGKINHDOANH
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NGONNGU')
            and   type = 'U')
   drop table NGONNGU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NHACUNGCAP')
            and   type = 'U')
   drop table NHACUNGCAP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NHASANXUAT')
            and   type = 'U')
   drop table NHASANXUAT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHANLOAI')
            and   name  = '_UOC_NHOM_THEO_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHANLOAI._UOC_NHOM_THEO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHANLOAI')
            and   type = 'U')
   drop table PHANLOAI
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHIEUNHAP')
            and   name  = 'THUOC_VE_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHIEUNHAP.THUOC_VE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHIEUNHAP')
            and   type = 'U')
   drop table PHIEUNHAP
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHIEUXUAT')
            and   name  = 'SE_CO_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHIEUXUAT.SE_CO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHIEUXUAT')
            and   type = 'U')
   drop table PHIEUXUAT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHUONGTHUCTHANHTOAN')
            and   type = 'U')
   drop table PHUONGTHUCTHANHTOAN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ROLE')
            and   type = 'U')
   drop table ROLE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SACH')
            and   name  = '_UOC_CHIA_THEO_FK'
            and   indid > 0
            and   indid < 255)
   drop index SACH._UOC_CHIA_THEO_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SACH')
            and   name  = 'SAN_XUAT_FK'
            and   indid > 0
            and   indid < 255)
   drop index SACH.SAN_XUAT_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SACH')
            and   name  = 'CUNG_CAP_FK'
            and   indid > 0
            and   indid < 255)
   drop index SACH.CUNG_CAP_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SACH')
            and   name  = 'CHIA_THEO_FK'
            and   indid > 0
            and   indid < 255)
   drop index SACH.CHIA_THEO_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SACH')
            and   name  = 'CHIA_FK'
            and   indid > 0
            and   indid < 255)
   drop index SACH.CHIA_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SACH')
            and   name  = 'SE__UOC_FK'
            and   indid > 0
            and   indid < 255)
   drop index SACH.SE__UOC_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SACH')
            and   name  = 'SE_CHUA_FK'
            and   indid > 0
            and   indid < 255)
   drop index SACH.SE_CHUA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SACH')
            and   type = 'U')
   drop table SACH
go

if exists (select 1
            from  sysobjects
           where  id = object_id('THOIGIAN')
            and   type = 'U')
   drop table THOIGIAN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USERGROUP')
            and   type = 'U')
   drop table USERGROUP
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VANPHONGPHAM')
            and   name  = 'SAN_XUAT_RA_FK'
            and   indid > 0
            and   indid < 255)
   drop index VANPHONGPHAM.SAN_XUAT_RA_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VANPHONGPHAM')
            and   name  = 'LIEN_KET_VOI_FK'
            and   indid > 0
            and   indid < 255)
   drop index VANPHONGPHAM.LIEN_KET_VOI_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VANPHONGPHAM')
            and   name  = 'CHUA_FK'
            and   indid > 0
            and   indid < 255)
   drop index VANPHONGPHAM.CHUA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VANPHONGPHAM')
            and   type = 'U')
   drop table VANPHONGPHAM
go

/*==============================================================*/
/* Table: CHUONGTRINH_KHUYENMAI                                 */
/*==============================================================*/
create table CHUONGTRINH_KHUYENMAI (
   IDCTKM               char(10)             not null,
   IDTG                 varchar(20)          null,
   TENCTKM              char(10)             not null,
   constraint PK_CHUONGTRINH_KHUYENMAI primary key nonclustered (IDCTKM)
)
go

/*==============================================================*/
/* Index: CHO_FK                                                */
/*==============================================================*/
create index CHO_FK on CHUONGTRINH_KHUYENMAI (
IDTG ASC
)
go

/*==============================================================*/
/* Table: CREDENTIAL                                            */
/*==============================================================*/
create table CREDENTIAL (
   IDGROUP              varchar(20)          not null,
   IDROLE               varchar(20)          not null,
   constraint PK_CREDENTIAL primary key (IDGROUP, IDROLE)
)
go

/*==============================================================*/
/* Index: CREDENTIAL_FK                                         */
/*==============================================================*/
create index CREDENTIAL_FK on CREDENTIAL (
IDGROUP ASC
)
go

/*==============================================================*/
/* Index: CREDENTIAL2_FK                                        */
/*==============================================================*/
create index CREDENTIAL2_FK on CREDENTIAL (
IDROLE ASC
)
go

/*==============================================================*/
/* Table: CT_CHUONGTRINH_KHUYENMAI                              */
/*==============================================================*/
create table CT_CHUONGTRINH_KHUYENMAI (
   ID                   varchar(20)          not null,
   IDCTKM               char(10)             not null,
   SOLUONG              int                  null,
   constraint PK_CT_CHUONGTRINH_KHUYENMAI primary key (ID, IDCTKM)
)
go

/*==============================================================*/
/* Index: CT_CHUONGTRINH_KHUYENMAI_FK                           */
/*==============================================================*/
create index CT_CHUONGTRINH_KHUYENMAI_FK on CT_CHUONGTRINH_KHUYENMAI (
ID ASC
)
go

/*==============================================================*/
/* Index: CT_CHUONGTRINH_KHUYENMAI2_FK                          */
/*==============================================================*/
create index CT_CHUONGTRINH_KHUYENMAI2_FK on CT_CHUONGTRINH_KHUYENMAI (
IDCTKM ASC
)
go

/*==============================================================*/
/* Table: CT_HOADON                                             */
/*==============================================================*/
create table CT_HOADON (
   ID                   varchar(20)          not null,
   IDHOADON             varchar(20)          not null,
   SOLUONG              int                  not null,
   THANHTIEN            money                not null,
   constraint PK_CT_HOADON primary key (ID, IDHOADON)
)
go

/*==============================================================*/
/* Index: CT_HOADON_FK                                          */
/*==============================================================*/
create index CT_HOADON_FK on CT_HOADON (
ID ASC
)
go

/*==============================================================*/
/* Index: CT_HOADON2_FK                                         */
/*==============================================================*/
create index CT_HOADON2_FK on CT_HOADON (
IDHOADON ASC
)
go

/*==============================================================*/
/* Table: CT_PHIEUNHAP                                          */
/*==============================================================*/
create table CT_PHIEUNHAP (
   IDHDNHAP             varchar(20)          not null,
   ID                   varchar(20)          not null,
   SOLUONGNHAP          int                  not null,
   constraint PK_CT_PHIEUNHAP primary key (IDHDNHAP, ID)
)
go

/*==============================================================*/
/* Index: CHITIETPHIEUNHAP_FK                                   */
/*==============================================================*/
create index CHITIETPHIEUNHAP_FK on CT_PHIEUNHAP (
IDHDNHAP ASC
)
go

/*==============================================================*/
/* Index: CHITIETPHIEUNHAP2_FK                                  */
/*==============================================================*/
create index CHITIETPHIEUNHAP2_FK on CT_PHIEUNHAP (
ID ASC
)
go

/*==============================================================*/
/* Table: CT_PHIEUXUAT                                          */
/*==============================================================*/
create table CT_PHIEUXUAT (
   ID                   varchar(20)          not null,
   IDXUAT               varchar(20)          not null,
   SOLUONG              int                  not null,
   constraint PK_CT_PHIEUXUAT primary key (ID, IDXUAT)
)
go

/*==============================================================*/
/* Index: CHITIETPHIEUXUAT_FK                                   */
/*==============================================================*/
create index CHITIETPHIEUXUAT_FK on CT_PHIEUXUAT (
ID ASC
)
go

/*==============================================================*/
/* Index: CHITIETPHIEUXUAT2_FK                                  */
/*==============================================================*/
create index CHITIETPHIEUXUAT2_FK on CT_PHIEUXUAT (
IDXUAT ASC
)
go

/*==============================================================*/
/* Table: GIABAN                                                */
/*==============================================================*/
create table GIABAN (
   IDGIA                varchar(20)          not null,
   GIAGIABAN            money                not null,
   NGAYCAPNHATGIA       datetime             not null,
   VAT                  int                  not null,
   constraint PK_GIABAN primary key nonclustered (IDGIA)
)
go

/*==============================================================*/
/* Table: GROUPPHANLOAI                                         */
/*==============================================================*/
create table GROUPPHANLOAI (
   IDGROUPPL            varchar(20)          not null,
   TENGROUPTHELOAI      varchar(500)         not null,
   constraint PK_GROUPPHANLOAI primary key nonclustered (IDGROUPPL)
)
go

/*==============================================================*/
/* Table: HINHSANPHAM                                           */
/*==============================================================*/
create table HINHSANPHAM (
   LINKHINHANH          varchar(900)        not null,
   MASACH               varchar(20)          null,
   MASP                 varchar(20)          null,
   TENHINHANH           varchar(200)         null,
   constraint PK_HINHSANPHAM primary key nonclustered (LINKHINHANH)
)
go

/*==============================================================*/
/* Index: SE_CO_THEO_FK                                         */
/*==============================================================*/
create index SE_CO_THEO_FK on HINHSANPHAM (
MASACH ASC
)
go

/*==============================================================*/
/* Index: SE_KEM_THEO_FK                                        */
/*==============================================================*/
create index SE_KEM_THEO_FK on HINHSANPHAM (
MASP ASC
)
go

/*==============================================================*/
/* Table: HINHTHUCSACH                                          */
/*==============================================================*/
create table HINHTHUCSACH (
   MAHINHTHUC           varchar(20)          not null,
   HINHTHUC             varchar(100)         not null,
   constraint PK_HINHTHUCSACH primary key nonclustered (MAHINHTHUC)
)
go

/*==============================================================*/
/* Table: HOADON                                                */
/*==============================================================*/
create table HOADON (
   IDHOADON             varchar(20)          not null,
   MAKH                 varchar(20)          null,
   MAKHO                varchar(20)          null,
   MAPT                 varchar(20)          null,
   NGAYLAPHD            datetime             not null,
   TONGTIEN             money                not null,
   constraint PK_HOADON primary key nonclustered (IDHOADON)
)
go

/*==============================================================*/
/* Index: THUOC_FK                                              */
/*==============================================================*/
create index THUOC_FK on HOADON (
MAKH ASC
)
go

/*==============================================================*/
/* Index: CO_FK                                                 */
/*==============================================================*/
create index CO_FK on HOADON (
MAPT ASC
)
go

/*==============================================================*/
/* Index: CUA_FK                                                */
/*==============================================================*/
create index CUA_FK on HOADON (
MAKHO ASC
)
go

/*==============================================================*/
/* Table: KHACHHANG                                             */
/*==============================================================*/
create table KHACHHANG (
   MAKH                 varchar(20)          not null,
   IDGROUP              varchar(20)          null,
   HOKH                 varchar(200)         not null,
   TENKH                varchar(200)         not null,
   EMAIL                varchar(500)         not null,
   DIENTHOAI            varchar(10)          not null,
   QUOCGIA              varchar(500)         not null,
   THANHPHO             varchar(300)         not null,
   QUAN                 varchar(300)         null,
   PHUONG               varchar(300)         not null,
   DIACHI               varchar(1024)        not null,
   USERNAME             varchar(20)          null,
   PASSWORD             char(20)             null,
   constraint PK_KHACHHANG primary key nonclustered (MAKH)
)
go

/*==============================================================*/
/* Index: SE_TON_TAI_FK                                         */
/*==============================================================*/
create index SE_TON_TAI_FK on KHACHHANG (
IDGROUP ASC
)
go

/*==============================================================*/
/* Table: KHOHANG                                               */
/*==============================================================*/
create table KHOHANG (
   MAKHO                varchar(20)          not null,
   TENKHO               varchar(200)         not null,
   DIACHIKHO            varchar(1024)        not null,
   SUCCHUA              int                  null,
   SLHANGTRONGKHO       int                  null,
   constraint PK_KHOHANG primary key nonclustered (MAKHO)
)
go

/*==============================================================*/
/* Table: MATHANGKINHDOANH                                      */
/*==============================================================*/
create table MATHANGKINHDOANH (
   ID                   varchar(20)          not null,
   TENMATHANG           varchar(500)         not null,
   constraint PK_MATHANGKINHDOANH primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: NGONNGU                                               */
/*==============================================================*/
create table NGONNGU (
   MANGONNGU            varchar(20)          not null,
   NGONNGU              varchar(20)          not null,
   constraint PK_NGONNGU primary key nonclustered (MANGONNGU)
)
go

/*==============================================================*/
/* Table: NHACUNGCAP                                            */
/*==============================================================*/
create table NHACUNGCAP (
   MANCC                varchar(20)          not null,
   TENNCC               varchar(200)         not null,
   DIACHINSX            varchar(1024)        null,
   EMAIL                varchar(500)         null,
   SDT                  varchar(11)          null,
   constraint PK_NHACUNGCAP primary key nonclustered (MANCC)
)
go

/*==============================================================*/
/* Table: NHASANXUAT                                            */
/*==============================================================*/
create table NHASANXUAT (
   MANSX                varchar(20)          not null,
   TENNSX               varchar(500)         not null,
   DIACHINSX            varchar(1024)        null,
   THONGTINTHEM         varchar(1024)        null,
   constraint PK_NHASANXUAT primary key nonclustered (MANSX)
)
go

/*==============================================================*/
/* Table: PHANLOAI                                              */
/*==============================================================*/
create table PHANLOAI (
   MAPL                 varchar(20)          not null,
   IDGROUPPL            varchar(20)          null,
   TENPL                varchar(500)         not null,
   constraint PK_PHANLOAI primary key nonclustered (MAPL)
)
go

/*==============================================================*/
/* Index: _UOC_NHOM_THEO_FK                                     */
/*==============================================================*/
create index _UOC_NHOM_THEO_FK on PHANLOAI (
IDGROUPPL ASC
)
go

/*==============================================================*/
/* Table: PHIEUNHAP                                             */
/*==============================================================*/
create table PHIEUNHAP (
   IDHDNHAP             varchar(20)          not null,
   MAKHO                varchar(20)          null,
   NGAYNHAP             datetime             not null,
   TONGSLNHAP           int                  null,
   TONGGIANHAP          money                null,
   constraint PK_PHIEUNHAP primary key nonclustered (IDHDNHAP)
)
go

/*==============================================================*/
/* Index: THUOC_VE_FK                                           */
/*==============================================================*/
create index THUOC_VE_FK on PHIEUNHAP (
MAKHO ASC
)
go

/*==============================================================*/
/* Table: PHIEUXUAT                                             */
/*==============================================================*/
create table PHIEUXUAT (
   IDXUAT               varchar(20)          not null,
   MAKHO                varchar(20)          null,
   NGAYXUATHD           datetime             not null,
   TONGSLXUAT           int                  null,
   TONGGIAHD            money                null,
   constraint PK_PHIEUXUAT primary key nonclustered (IDXUAT)
)
go

/*==============================================================*/
/* Index: SE_CO_FK                                              */
/*==============================================================*/
create index SE_CO_FK on PHIEUXUAT (
MAKHO ASC
)
go

/*==============================================================*/
/* Table: PHUONGTHUCTHANHTOAN                                   */
/*==============================================================*/
create table PHUONGTHUCTHANHTOAN (
   MAPT                 varchar(20)          not null,
   TENPT                varchar(300)         not null,
   constraint PK_PHUONGTHUCTHANHTOAN primary key nonclustered (MAPT)
)
go

/*==============================================================*/
/* Table: ROLE                                                  */
/*==============================================================*/
create table ROLE (
   IDROLE               varchar(20)          not null,
   TENROLE              varchar(500)         not null,
   constraint PK_ROLE primary key nonclustered (IDROLE)
)
go

/*==============================================================*/
/* Table: SACH                                                  */
/*==============================================================*/
create table SACH (
   MASACH               varchar(20)          not null,
   MAPL                 varchar(20)          null,
   MANGONNGU            varchar(20)          null,
   ID                   varchar(20)          null,
   MANSX                varchar(20)          null,
   MANCC                varchar(20)          null,
   IDGIA                varchar(20)          null,
   MAHINHTHUC           varchar(20)          null,
   TENSACH              varchar(200)         not null,
   TACGIA               varchar(100)         null,
   GIASACH              money                not null,
   TRONGLUONG           float                null,
   SOTRANG              int                  null,
   KICHTHUOC            varchar(200)         null,
   TOMTAC               varchar(500)         null,
   constraint PK_SACH primary key nonclustered (MASACH)
)
go

/*==============================================================*/
/* Index: SE_CHUA_FK                                            */
/*==============================================================*/
create index SE_CHUA_FK on SACH (
ID ASC
)
go

/*==============================================================*/
/* Index: SE__UOC_FK                                            */
/*==============================================================*/
create index SE__UOC_FK on SACH (
MAPL ASC
)
go

/*==============================================================*/
/* Index: CHIA_FK                                               */
/*==============================================================*/
create index CHIA_FK on SACH (
MANGONNGU ASC
)
go

/*==============================================================*/
/* Index: CHIA_THEO_FK                                          */
/*==============================================================*/
create index CHIA_THEO_FK on SACH (
MAHINHTHUC ASC
)
go

/*==============================================================*/
/* Index: CUNG_CAP_FK                                           */
/*==============================================================*/
create index CUNG_CAP_FK on SACH (
MANCC ASC
)
go

/*==============================================================*/
/* Index: SAN_XUAT_FK                                           */
/*==============================================================*/
create index SAN_XUAT_FK on SACH (
MANSX ASC
)
go

/*==============================================================*/
/* Index: _UOC_CHIA_THEO_FK                                     */
/*==============================================================*/
create index _UOC_CHIA_THEO_FK on SACH (
IDGIA ASC
)
go

/*==============================================================*/
/* Table: THOIGIAN                                              */
/*==============================================================*/
create table THOIGIAN (
   IDTG                 varchar(20)          not null,
   TGBATDAU             datetime             not null,
   TGKETTHUC            datetime             not null,
   constraint PK_THOIGIAN primary key nonclustered (IDTG)
)
go

/*==============================================================*/
/* Table: USERGROUP                                             */
/*==============================================================*/
create table USERGROUP (
   IDGROUP              varchar(20)          not null,
   TENGROUP             varchar(200)         not null,
   constraint PK_USERGROUP primary key nonclustered (IDGROUP)
)
go

/*==============================================================*/
/* Table: VANPHONGPHAM                                          */
/*==============================================================*/
create table VANPHONGPHAM (
   MASP                 varchar(20)          not null,
   MANCC                varchar(20)          null,
   MANSX                varchar(20)          null,
   ID                   varchar(20)          null,
   DONGIAVPP            money                not null,
   TRONGLUONG           float                null,
   KICHTHUOC            varchar(200)         null,
   TENSP                varchar(500)         not null,
   GIOITHIEUSP          varchar(1024)        null,
   CHATLIEU             varchar(200)         null,
   constraint PK_VANPHONGPHAM primary key nonclustered (MASP)
)
go

/*==============================================================*/
/* Index: CHUA_FK                                               */
/*==============================================================*/
create index CHUA_FK on VANPHONGPHAM (
ID ASC
)
go

/*==============================================================*/
/* Index: LIEN_KET_VOI_FK                                       */
/*==============================================================*/
create index LIEN_KET_VOI_FK on VANPHONGPHAM (
MANCC ASC
)
go

/*==============================================================*/
/* Index: SAN_XUAT_RA_FK                                        */
/*==============================================================*/
create index SAN_XUAT_RA_FK on VANPHONGPHAM (
MANSX ASC
)
go

alter table CHUONGTRINH_KHUYENMAI
   add constraint FK_CHUONGTR_CHO_THOIGIAN foreign key (IDTG)
      references THOIGIAN (IDTG)
go

alter table CREDENTIAL
   add constraint FK_CREDENTI_CREDENTIA_USERGROU foreign key (IDGROUP)
      references USERGROUP (IDGROUP)
go

alter table CREDENTIAL
   add constraint FK_CREDENTI_CREDENTIA_ROLE foreign key (IDROLE)
      references ROLE (IDROLE)
go

alter table CT_CHUONGTRINH_KHUYENMAI
   add constraint FK_CT_CHUON_CT_CHUONG_MATHANGK foreign key (ID)
      references MATHANGKINHDOANH (ID)
go

alter table CT_CHUONGTRINH_KHUYENMAI
   add constraint FK_CT_CHUON_CT_CHUONG_CHUONGTR foreign key (IDCTKM)
      references CHUONGTRINH_KHUYENMAI (IDCTKM)
go

alter table CT_HOADON
   add constraint FK_CT_HOADO_CT_HOADON_MATHANGK foreign key (ID)
      references MATHANGKINHDOANH (ID)
go

alter table CT_HOADON
   add constraint FK_CT_HOADO_CT_HOADON_HOADON foreign key (IDHOADON)
      references HOADON (IDHOADON)
go

alter table CT_PHIEUNHAP
   add constraint FK_CT_PHIEU_CT_PHIEUN_PHIEUNHA foreign key (IDHDNHAP)
      references PHIEUNHAP (IDHDNHAP)
go

alter table CT_PHIEUNHAP
   add constraint FK_CT_PHIEU_CT_PHIEUN_MATHANGK foreign key (ID)
      references MATHANGKINHDOANH (ID)
go

alter table CT_PHIEUXUAT
   add constraint FK_CT_PHIEU_CT_PHIEUX_MATHANGK foreign key (ID)
      references MATHANGKINHDOANH (ID)
go

alter table CT_PHIEUXUAT
   add constraint FK_CT_PHIEU_CT_PHIEUX_PHIEUXUA foreign key (IDXUAT)
      references PHIEUXUAT (IDXUAT)
go

alter table HINHSANPHAM
   add constraint FK_HINHSANP_SE_CO_THE_SACH foreign key (MASACH)
      references SACH (MASACH)
go

alter table HINHSANPHAM
   add constraint FK_HINHSANP_SE_KEM_TH_VANPHONG foreign key (MASP)
      references VANPHONGPHAM (MASP)
go

alter table HOADON
   add constraint FK_HOADON_CO_PHUONGTH foreign key (MAPT)
      references PHUONGTHUCTHANHTOAN (MAPT)
go

alter table HOADON
   add constraint FK_HOADON_CUA_KHOHANG foreign key (MAKHO)
      references KHOHANG (MAKHO)
go

alter table HOADON
   add constraint FK_HOADON_THUOC_KHACHHAN foreign key (MAKH)
      references KHACHHANG (MAKH)
go

alter table KHACHHANG
   add constraint FK_KHACHHAN_SE_TON_TA_USERGROU foreign key (IDGROUP)
      references USERGROUP (IDGROUP)
go

alter table PHANLOAI
   add constraint FK_PHANLOAI__UOC_NHOM_GROUPPHA foreign key (IDGROUPPL)
      references GROUPPHANLOAI (IDGROUPPL)
go

alter table PHIEUNHAP
   add constraint FK_PHIEUNHA_THUOC_VE_KHOHANG foreign key (MAKHO)
      references KHOHANG (MAKHO)
go

alter table PHIEUXUAT
   add constraint FK_PHIEUXUA_SE_CO_KHOHANG foreign key (MAKHO)
      references KHOHANG (MAKHO)
go

alter table SACH
   add constraint FK_SACH_CHIA_NGONNGU foreign key (MANGONNGU)
      references NGONNGU (MANGONNGU)
go

alter table SACH
   add constraint FK_SACH_CHIA_THEO_HINHTHUC foreign key (MAHINHTHUC)
      references HINHTHUCSACH (MAHINHTHUC)
go

alter table SACH
   add constraint FK_SACH_CUNG_CAP_NHACUNGC foreign key (MANCC)
      references NHACUNGCAP (MANCC)
go

alter table SACH
   add constraint FK_SACH_SAN_XUAT_NHASANXU foreign key (MANSX)
      references NHASANXUAT (MANSX)
go

alter table SACH
   add constraint FK_SACH_SE_CHUA_MATHANGK foreign key (ID)
      references MATHANGKINHDOANH (ID)
go

alter table SACH
   add constraint FK_SACH_SE__UOC_PHANLOAI foreign key (MAPL)
      references PHANLOAI (MAPL)
go

alter table SACH
   add constraint FK_SACH__UOC_CHIA_GIABAN foreign key (IDGIA)
      references GIABAN (IDGIA)
go

alter table VANPHONGPHAM
   add constraint FK_VANPHONG_CHUA_MATHANGK foreign key (ID)
      references MATHANGKINHDOANH (ID)
go

alter table VANPHONGPHAM
   add constraint FK_VANPHONG_LIEN_KET__NHACUNGC foreign key (MANCC)
      references NHACUNGCAP (MANCC)
go

alter table VANPHONGPHAM
   add constraint FK_VANPHONG_SAN_XUAT__NHASANXU foreign key (MANSX)
      references NHASANXUAT (MANSX)
go

