/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     4/21/2020 12:44:40 PM                        */
/*==============================================================*/
Create database QLNhaSachFahasa

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
   where r.fkeyid = object_id('CT_CHUONGTRINH_KHUYENMAI') and o.name = 'FK_CT_CHUON_CT_CHUONG_SANPHAM')
alter table CT_CHUONGTRINH_KHUYENMAI
   drop constraint FK_CT_CHUON_CT_CHUONG_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CT_CHUONGTRINH_KHUYENMAI') and o.name = 'FK_CT_CHUON_CT_CHUONG_CHUONGTR')
alter table CT_CHUONGTRINH_KHUYENMAI
   drop constraint FK_CT_CHUON_CT_CHUONG_CHUONGTR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CT_HOADON') and o.name = 'FK_CT_HOADO_CT_HOADON_SANPHAM')
alter table CT_HOADON
   drop constraint FK_CT_HOADO_CT_HOADON_SANPHAM
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
   where r.fkeyid = object_id('CT_PHIEUNHAP') and o.name = 'FK_CT_PHIEU_CT_PHIEUN_SANPHAM')
alter table CT_PHIEUNHAP
   drop constraint FK_CT_PHIEU_CT_PHIEUN_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CT_PHIEUXUAT') and o.name = 'FK_CT_PHIEU_CT_PHIEUX_SANPHAM')
alter table CT_PHIEUXUAT
   drop constraint FK_CT_PHIEU_CT_PHIEUX_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CT_PHIEUXUAT') and o.name = 'FK_CT_PHIEU_CT_PHIEUX_PHIEUXUA')
alter table CT_PHIEUXUAT
   drop constraint FK_CT_PHIEU_CT_PHIEUX_PHIEUXUA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GIABAN') and o.name = 'FK_GIABAN_BAN_SANPHAM')
alter table GIABAN
   drop constraint FK_GIABAN_BAN_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HINHSANPHAM') and o.name = 'FK_HINHSANP_CO_HINH_SANPHAM')
alter table HINHSANPHAM
   drop constraint FK_HINHSANP_CO_HINH_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HOADON') and o.name = 'FK_HOADON_CO_PHUONGTH')
alter table HOADON
   drop constraint FK_HOADON_CO_PHUONGTH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HOADON') and o.name = 'FK_HOADON_RELATIONS_NHANVIEN')
alter table HOADON
   drop constraint FK_HOADON_RELATIONS_NHANVIEN
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
   where r.fkeyid = object_id('PHANLOAISACH') and o.name = 'FK_PHANLOAI__UOC_NHOM_GROUPPHA')
alter table PHANLOAISACH
   drop constraint FK_PHANLOAI__UOC_NHOM_GROUPPHA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHIEUNHAP') and o.name = 'FK_PHIEUNHA_RELATIONS_NHACUNGC')
alter table PHIEUNHAP
   drop constraint FK_PHIEUNHA_RELATIONS_NHACUNGC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHIEUNHAP') and o.name = 'FK_PHIEUNHA_RELATIONS_NHANVIEN')
alter table PHIEUNHAP
   drop constraint FK_PHIEUNHA_RELATIONS_NHANVIEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHIEUXUAT') and o.name = 'FK_PHIEUXUA_RELATIONS_NHANVIEN')
alter table PHIEUXUAT
   drop constraint FK_PHIEUXUA_RELATIONS_NHANVIEN
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
   where r.fkeyid = object_id('SACH') and o.name = 'FK_SACH_RELATIONS_MATHANGK')
alter table SACH
   drop constraint FK_SACH_RELATIONS_MATHANGK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SACH') and o.name = 'FK_SACH_RELATIONS_PHANLOAI')
alter table SACH
   drop constraint FK_SACH_RELATIONS_PHANLOAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SANPHAM') and o.name = 'FK_SANPHAM_LAM_NHASANXU')
alter table SANPHAM
   drop constraint FK_SANPHAM_LAM_NHASANXU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SANPHAM') and o.name = 'FK_SANPHAM_RELATIONS_KHOHANG')
alter table SANPHAM
   drop constraint FK_SANPHAM_RELATIONS_KHOHANG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SANPHAM') and o.name = 'FK_SANPHAM_RELATIONS_MATHANGK')
alter table SANPHAM
   drop constraint FK_SANPHAM_RELATIONS_MATHANGK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USERGROUP') and o.name = 'FK_USERGROU_RELATIONS_NHANVIEN')
alter table USERGROUP
   drop constraint FK_USERGROU_RELATIONS_NHANVIEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VANPHONGPHAM') and o.name = 'FK_VANPHONG_RELATIONS_XUATXU')
alter table VANPHONGPHAM
   drop constraint FK_VANPHONG_RELATIONS_XUATXU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VANPHONGPHAM') and o.name = 'FK_VANPHONG_RELATIONS_MATHANGK')
alter table VANPHONGPHAM
   drop constraint FK_VANPHONG_RELATIONS_MATHANGK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VANPHONGPHAM') and o.name = 'FK_VANPHONG_RELATIONS_PHANLOAI')
alter table VANPHONGPHAM
   drop constraint FK_VANPHONG_RELATIONS_PHANLOAI
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
            and   name  = 'CT_PHIEUNHAP2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CT_PHIEUNHAP.CT_PHIEUNHAP2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CT_PHIEUNHAP')
            and   name  = 'CT_PHIEUNHAP_FK'
            and   indid > 0
            and   indid < 255)
   drop index CT_PHIEUNHAP.CT_PHIEUNHAP_FK
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
            and   name  = 'CT_PHIEUXUAT2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CT_PHIEUXUAT.CT_PHIEUXUAT2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CT_PHIEUXUAT')
            and   name  = 'CT_PHIEUXUAT_FK'
            and   indid > 0
            and   indid < 255)
   drop index CT_PHIEUXUAT.CT_PHIEUXUAT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CT_PHIEUXUAT')
            and   type = 'U')
   drop table CT_PHIEUXUAT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GIABAN')
            and   name  = 'BAN_FK'
            and   indid > 0
            and   indid < 255)
   drop index GIABAN.BAN_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GIABAN')
            and   type = 'U')
   drop table GIABAN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GROUPPHANLOAISACH')
            and   type = 'U')
   drop table GROUPPHANLOAISACH
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HINHSANPHAM')
            and   name  = 'CO_HINH_FK'
            and   indid > 0
            and   indid < 255)
   drop index HINHSANPHAM.CO_HINH_FK
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
            and   name  = 'RELATIONSHIP_23_FK'
            and   indid > 0
            and   indid < 255)
   drop index HOADON.RELATIONSHIP_23_FK
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
           where  id = object_id('NHANVIEN')
            and   type = 'U')
   drop table NHANVIEN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NHASANXUAT')
            and   type = 'U')
   drop table NHASANXUAT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHANLOAISACH')
            and   name  = '_UOC_NHOM_THEO_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHANLOAISACH._UOC_NHOM_THEO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHANLOAISACH')
            and   type = 'U')
   drop table PHANLOAISACH
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHANLOAIVPP')
            and   type = 'U')
   drop table PHANLOAIVPP
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHIEUNHAP')
            and   name  = 'RELATIONSHIP_25_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHIEUNHAP.RELATIONSHIP_25_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHIEUNHAP')
            and   name  = 'RELATIONSHIP_16_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHIEUNHAP.RELATIONSHIP_16_FK
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
            and   name  = 'RELATIONSHIP_24_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHIEUXUAT.RELATIONSHIP_24_FK
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
            and   name  = 'RELATIONSHIP_20_FK'
            and   indid > 0
            and   indid < 255)
   drop index SACH.RELATIONSHIP_20_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SACH')
            and   name  = 'RELATIONSHIP_15_FK'
            and   indid > 0
            and   indid < 255)
   drop index SACH.RELATIONSHIP_15_FK
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
            from  sysobjects
           where  id = object_id('SACH')
            and   type = 'U')
   drop table SACH
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SANPHAM')
            and   name  = 'RELATIONSHIP_19_FK'
            and   indid > 0
            and   indid < 255)
   drop index SANPHAM.RELATIONSHIP_19_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SANPHAM')
            and   name  = 'LAM_FK'
            and   indid > 0
            and   indid < 255)
   drop index SANPHAM.LAM_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SANPHAM')
            and   name  = 'RELATIONSHIP_18_FK'
            and   indid > 0
            and   indid < 255)
   drop index SANPHAM.RELATIONSHIP_18_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SANPHAM')
            and   type = 'U')
   drop table SANPHAM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('THOIGIAN')
            and   type = 'U')
   drop table THOIGIAN
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('USERGROUP')
            and   name  = 'RELATIONSHIP_22_FK'
            and   indid > 0
            and   indid < 255)
   drop index USERGROUP.RELATIONSHIP_22_FK
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
            and   name  = 'RELATIONSHIP_21_FK'
            and   indid > 0
            and   indid < 255)
   drop index VANPHONGPHAM.RELATIONSHIP_21_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VANPHONGPHAM')
            and   name  = 'RELATIONSHIP_17_FK'
            and   indid > 0
            and   indid < 255)
   drop index VANPHONGPHAM.RELATIONSHIP_17_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VANPHONGPHAM')
            and   name  = 'RELATIONSHIP_14_FK'
            and   indid > 0
            and   indid < 255)
   drop index VANPHONGPHAM.RELATIONSHIP_14_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VANPHONGPHAM')
            and   type = 'U')
   drop table VANPHONGPHAM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('XUATXU')
            and   type = 'U')
   drop table XUATXU
go

/*==============================================================*/
/* Table: CHUONGTRINH_KHUYENMAI                                 */
/*==============================================================*/
create table CHUONGTRINH_KHUYENMAI (
   IDCTKM               varchar(20)          not null,
   IDTG                 varchar(20)          null,
   TENCTKM              nvarchar(1024)       not null,
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
   IDSANPHAM            varchar(20)          not null,
   IDCTKM               varchar(20)          not null,
   SOLUONG              int                  null,
   constraint PK_CT_CHUONGTRINH_KHUYENMAI primary key (IDSANPHAM, IDCTKM)
)
go

/*==============================================================*/
/* Index: CT_CHUONGTRINH_KHUYENMAI_FK                           */
/*==============================================================*/
create index CT_CHUONGTRINH_KHUYENMAI_FK on CT_CHUONGTRINH_KHUYENMAI (
IDSANPHAM ASC
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
   IDSANPHAM            varchar(20)          not null,
   IDHOADON             varchar(20)          not null,
   SOLUONG              int                  not null,
   THANHTIEN            money                not null,
   constraint PK_CT_HOADON primary key (IDSANPHAM, IDHOADON)
)
go

/*==============================================================*/
/* Index: CT_HOADON_FK                                          */
/*==============================================================*/
create index CT_HOADON_FK on CT_HOADON (
IDSANPHAM ASC
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
   IDSANPHAM            varchar(20)          not null,
   SOLUONGNHAP          int                  not null,
   constraint PK_CT_PHIEUNHAP primary key (IDHDNHAP, IDSANPHAM)
)
go

/*==============================================================*/
/* Index: CT_PHIEUNHAP_FK                                       */
/*==============================================================*/
create index CT_PHIEUNHAP_FK on CT_PHIEUNHAP (
IDHDNHAP ASC
)
go

/*==============================================================*/
/* Index: CT_PHIEUNHAP2_FK                                      */
/*==============================================================*/
create index CT_PHIEUNHAP2_FK on CT_PHIEUNHAP (
IDSANPHAM ASC
)
go

/*==============================================================*/
/* Table: CT_PHIEUXUAT                                          */
/*==============================================================*/
create table CT_PHIEUXUAT (
   IDSANPHAM            varchar(20)          not null,
   IDXUAT               varchar(20)          not null,
   SOLUONG              int                  not null,
   constraint PK_CT_PHIEUXUAT primary key (IDSANPHAM, IDXUAT)
)
go

/*==============================================================*/
/* Index: CT_PHIEUXUAT_FK                                       */
/*==============================================================*/
create index CT_PHIEUXUAT_FK on CT_PHIEUXUAT (
IDSANPHAM ASC
)
go

/*==============================================================*/
/* Index: CT_PHIEUXUAT2_FK                                      */
/*==============================================================*/
create index CT_PHIEUXUAT2_FK on CT_PHIEUXUAT (
IDXUAT ASC
)
go

/*==============================================================*/
/* Table: GIABAN                                                */
/*==============================================================*/
create table GIABAN (
   IDGIA                varchar(20)          not null,
   IDSANPHAM            varchar(20)          null,
   DONGIABAN            money                not null,
   NGAYCAPNHATGIA       datetime             not null,
   VAT                  int                  not null,
   constraint PK_GIABAN primary key nonclustered (IDGIA)
)
go

/*==============================================================*/
/* Index: BAN_FK                                                */
/*==============================================================*/
create index BAN_FK on GIABAN (
IDSANPHAM ASC
)
go

/*==============================================================*/
/* Table: GROUPPHANLOAISACH                                     */
/*==============================================================*/
create table GROUPPHANLOAISACH (
   IDGROUPPL            varchar(20)          not null,
   TENGROUPTHELOAI      nvarchar(500)        not null,
   constraint PK_GROUPPHANLOAISACH primary key nonclustered (IDGROUPPL)
)
go

/*==============================================================*/
/* Table: HINHSANPHAM                                           */
/*==============================================================*/
create table HINHSANPHAM (
   LINKHINHANH          varchar(900)        not null,
   IDSANPHAM            varchar(20)          null,
   TENHINHANH           nvarchar(1024)       null,
   constraint PK_HINHSANPHAM primary key nonclustered (LINKHINHANH)
)
go

/*==============================================================*/
/* Index: CO_HINH_FK                                            */
/*==============================================================*/
create index CO_HINH_FK on HINHSANPHAM (
IDSANPHAM ASC
)
go

/*==============================================================*/
/* Table: HINHTHUCSACH                                          */
/*==============================================================*/
create table HINHTHUCSACH (
   MAHINHTHUC           varchar(20)          not null,
   HINHTHUC             nvarchar(100)        not null,
   constraint PK_HINHTHUCSACH primary key nonclustered (MAHINHTHUC)
)
go

/*==============================================================*/
/* Table: HOADON                                                */
/*==============================================================*/
create table HOADON (
   IDHOADON             varchar(20)          not null,
   MAKH                 varchar(20)          null,
   MANV                 varchar(20)          null,
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
/* Index: RELATIONSHIP_23_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_23_FK on HOADON (
MANV ASC
)
go

/*==============================================================*/
/* Table: KHACHHANG                                             */
/*==============================================================*/
create table KHACHHANG (
   MAKH                 varchar(20)          not null,
   IDGROUP              varchar(20)          null,
   HOKH                 nvarchar(1024)       not null,
   TENKH                nvarchar(1024)       not null,
   EMAIL                varchar(500)         not null,
   DIENTHOAI            varchar(10)          not null,
   QUOCGIA              nvarchar(1024)       null,
   THANHPHO             nvarchar(1024)       null,
   QUAN                 nvarchar(1024)       null,
   PHUONG               nvarchar(300)        null,
   DIACHINV             nvarchar(1024)       null,
   USERNAMENV           varchar(30)          null,
   PASSWORDNV           varchar(1024)        null,
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
   TENKHO               nvarchar(200)        not null,
   DIACHIKHO            nvarchar(1024)       not null,
   SUCCHUA              int                  null,
   SLHANGTRONGKHO       int                  null,
   constraint PK_KHOHANG primary key nonclustered (MAKHO)
)
go

/*==============================================================*/
/* Table: MATHANGKINHDOANH                                      */
/*==============================================================*/
create table MATHANGKINHDOANH (
   IDLOAI               char(20)             not null,
   LOAIMATHANG          nvarchar(500)        not null,
   constraint PK_MATHANGKINHDOANH primary key nonclustered (IDLOAI)
)
go

/*==============================================================*/
/* Table: NGONNGU                                               */
/*==============================================================*/
create table NGONNGU (
   MANGONNGU            varchar(20)          not null,
   NGONNGU              nvarchar(20)         not null,
   constraint PK_NGONNGU primary key nonclustered (MANGONNGU)
)
go

/*==============================================================*/
/* Table: NHACUNGCAP                                            */
/*==============================================================*/
create table NHACUNGCAP (
   MANCC                varchar(20)          not null,
   TENNCC               nvarchar(200)        not null,
   DIACHINSX            nvarchar(1024)       null,
   EMAIL                varchar(500)         null,
   SDTNV                varchar(11)          null,
   constraint PK_NHACUNGCAP primary key nonclustered (MANCC)
)
go

/*==============================================================*/
/* Table: NHANVIEN                                              */
/*==============================================================*/
create table NHANVIEN (
   MANV                 varchar(20)          not null,
   TENNV                nvarchar(100)        not null,
   USERNAMENV           varchar(30)          null,
   PASSWORDNV           varchar(1024)        null,
   DIACHINV             nvarchar(1024)       null,
   SDTNV                varchar(11)          null,
   constraint PK_NHANVIEN primary key nonclustered (MANV)
)
go

/*==============================================================*/
/* Table: NHASANXUAT                                            */
/*==============================================================*/
create table NHASANXUAT (
   MANSX                varchar(20)          not null,
   TENNSX               nvarchar(500)        not null,
   DIACHINSX            nvarchar(1024)       null,
   THONGTINTHEM         nvarchar(1024)       null,
   constraint PK_NHASANXUAT primary key nonclustered (MANSX)
)
go

/*==============================================================*/
/* Table: PHANLOAISACH                                          */
/*==============================================================*/
create table PHANLOAISACH (
   MAPLSACH             varchar(20)          not null,
   IDGROUPPL            varchar(20)          null,
   TENPLSACH            nvarchar(500)        not null,
   constraint PK_PHANLOAISACH primary key nonclustered (MAPLSACH)
)
go

/*==============================================================*/
/* Index: _UOC_NHOM_THEO_FK                                     */
/*==============================================================*/
create index _UOC_NHOM_THEO_FK on PHANLOAISACH (
IDGROUPPL ASC
)
go

/*==============================================================*/
/* Table: PHANLOAIVPP                                           */
/*==============================================================*/
create table PHANLOAIVPP (
   MAPLVPP              varchar(20)          not null,
   TENPLVPP             char(10)             null,
   constraint PK_PHANLOAIVPP primary key nonclustered (MAPLVPP)
)
go

/*==============================================================*/
/* Table: PHIEUNHAP                                             */
/*==============================================================*/
create table PHIEUNHAP (
   IDHDNHAP             varchar(20)          not null,
   MANCC                varchar(20)          null,
   MANV                 varchar(20)          null,
   NGAYNHAP             datetime             not null,
   TONGSLNHAP           int                  null,
   TONGGIANHAP          money                null,
   constraint PK_PHIEUNHAP primary key nonclustered (IDHDNHAP)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_16_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_16_FK on PHIEUNHAP (
MANCC ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_25_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_25_FK on PHIEUNHAP (
MANV ASC
)
go

/*==============================================================*/
/* Table: PHIEUXUAT                                             */
/*==============================================================*/
create table PHIEUXUAT (
   IDXUAT               varchar(20)          not null,
   MANV                 varchar(20)          null,
   NGAYXUATHD           datetime             not null,
   TONGSLXUAT           int                  null,
   TONGGIAHD            money                null,
   constraint PK_PHIEUXUAT primary key nonclustered (IDXUAT)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_24_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_24_FK on PHIEUXUAT (
MANV ASC
)
go

/*==============================================================*/
/* Table: PHUONGTHUCTHANHTOAN                                   */
/*==============================================================*/
create table PHUONGTHUCTHANHTOAN (
   MAPT                 varchar(20)          not null,
   TENPT                nvarchar(1024)       not null,
   constraint PK_PHUONGTHUCTHANHTOAN primary key nonclustered (MAPT)
)
go

/*==============================================================*/
/* Table: ROLE                                                  */
/*==============================================================*/
create table ROLE (
   IDROLE               varchar(20)          not null,
   TENROLE              nvarchar(500)        not null,
   constraint PK_ROLE primary key nonclustered (IDROLE)
)
go

/*==============================================================*/
/* Table: SACH                                                  */
/*==============================================================*/
create table SACH (
   MASACH               varchar(20)          not null,
   IDLOAI               char(20)             null,
   MANGONNGU            varchar(20)          null,
   MAPLSACH             varchar(20)          null,
   MAHINHTHUC           varchar(20)          null,
   TENSACH              nvarchar(1024)       not null,
   TACGIA               nvarchar(1024)       null,
   GIASACH              money                not null,
   TRONGLUONG           float                null,
   SOTRANG              int                  null,
   KICHTHUOC            nvarchar(1024)       null,
   TOMTAC               nvarchar(1024)       null,
   NHAXUATBAN           nvarchar(1024)       null,
   constraint PK_SACH primary key nonclustered (MASACH)
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
/* Index: RELATIONSHIP_15_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_15_FK on SACH (
IDLOAI ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_20_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_20_FK on SACH (
MAPLSACH ASC
)
go

/*==============================================================*/
/* Table: SANPHAM                                               */
/*==============================================================*/
create table SANPHAM (
   IDSANPHAM            varchar(20)          not null,
   MANSX                varchar(20)          null,
   IDLOAI               char(20)             null,
   MAKHO                varchar(20)          null,
   DONGIA               money                not null,
   NGAYCAPNHAT          datetime             not null,
   constraint PK_SANPHAM primary key nonclustered (IDSANPHAM)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_18_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_18_FK on SANPHAM (
MAKHO ASC
)
go

/*==============================================================*/
/* Index: LAM_FK                                                */
/*==============================================================*/
create index LAM_FK on SANPHAM (
MANSX ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_19_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_19_FK on SANPHAM (
IDLOAI ASC
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
   MANV                 varchar(20)          null,
   TENGROUP             nvarchar(200)        not null,
   constraint PK_USERGROUP primary key nonclustered (IDGROUP)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_22_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_22_FK on USERGROUP (
MANV ASC
)
go

/*==============================================================*/
/* Table: VANPHONGPHAM                                          */
/*==============================================================*/
create table VANPHONGPHAM (
   MASP                 varchar(20)          not null,
   IDLOAI               char(20)             null,
   MAQUOCGIA            char(20)             null,
   MAPLVPP              varchar(20)          null,
   TENSP                nvarchar(1024)       not null,
   TRONGLUONG           float                null,
   KICHTHUOC            nvarchar(1024)       null,
   GIOITHIEUSP          nvarchar(1024)       null,
   CHATLIEU             nvarchar(1024)       null,
   MAUSAC               nvarchar(20)         null,
   constraint PK_VANPHONGPHAM primary key nonclustered (MASP)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_14_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_14_FK on VANPHONGPHAM (
MAQUOCGIA ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_17_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_17_FK on VANPHONGPHAM (
IDLOAI ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_21_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_21_FK on VANPHONGPHAM (
MAPLVPP ASC
)
go

/*==============================================================*/
/* Table: XUATXU                                                */
/*==============================================================*/
create table XUATXU (
   MAQUOCGIA            char(20)             not null,
   TENQUOCGIA           nvarchar(1024)       not null,
   constraint PK_XUATXU primary key nonclustered (MAQUOCGIA)
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
   add constraint FK_CT_CHUON_CT_CHUONG_SANPHAM foreign key (IDSANPHAM)
      references SANPHAM (IDSANPHAM)
go

alter table CT_CHUONGTRINH_KHUYENMAI
   add constraint FK_CT_CHUON_CT_CHUONG_CHUONGTR foreign key (IDCTKM)
      references CHUONGTRINH_KHUYENMAI (IDCTKM)
go

alter table CT_HOADON
   add constraint FK_CT_HOADO_CT_HOADON_SANPHAM foreign key (IDSANPHAM)
      references SANPHAM (IDSANPHAM)
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
   add constraint FK_CT_PHIEU_CT_PHIEUN_SANPHAM foreign key (IDSANPHAM)
      references SANPHAM (IDSANPHAM)
go

alter table CT_PHIEUXUAT
   add constraint FK_CT_PHIEU_CT_PHIEUX_SANPHAM foreign key (IDSANPHAM)
      references SANPHAM (IDSANPHAM)
go

alter table CT_PHIEUXUAT
   add constraint FK_CT_PHIEU_CT_PHIEUX_PHIEUXUA foreign key (IDXUAT)
      references PHIEUXUAT (IDXUAT)
go

alter table GIABAN
   add constraint FK_GIABAN_BAN_SANPHAM foreign key (IDSANPHAM)
      references SANPHAM (IDSANPHAM)
go

alter table HINHSANPHAM
   add constraint FK_HINHSANP_CO_HINH_SANPHAM foreign key (IDSANPHAM)
      references SANPHAM (IDSANPHAM)
go

alter table HOADON
   add constraint FK_HOADON_CO_PHUONGTH foreign key (MAPT)
      references PHUONGTHUCTHANHTOAN (MAPT)
go

alter table HOADON
   add constraint FK_HOADON_RELATIONS_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV)
go

alter table HOADON
   add constraint FK_HOADON_THUOC_KHACHHAN foreign key (MAKH)
      references KHACHHANG (MAKH)
go

alter table KHACHHANG
   add constraint FK_KHACHHAN_SE_TON_TA_USERGROU foreign key (IDGROUP)
      references USERGROUP (IDGROUP)
go

alter table PHANLOAISACH
   add constraint FK_PHANLOAI__UOC_NHOM_GROUPPHA foreign key (IDGROUPPL)
      references GROUPPHANLOAISACH (IDGROUPPL)
go

alter table PHIEUNHAP
   add constraint FK_PHIEUNHA_RELATIONS_NHACUNGC foreign key (MANCC)
      references NHACUNGCAP (MANCC)
go

alter table PHIEUNHAP
   add constraint FK_PHIEUNHA_RELATIONS_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV)
go

alter table PHIEUXUAT
   add constraint FK_PHIEUXUA_RELATIONS_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV)
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
   add constraint FK_SACH_RELATIONS_MATHANGK foreign key (IDLOAI)
      references MATHANGKINHDOANH (IDLOAI)
go

alter table SACH
   add constraint FK_SACH_RELATIONS_PHANLOAI foreign key (MAPLSACH)
      references PHANLOAISACH (MAPLSACH)
go

alter table SANPHAM
   add constraint FK_SANPHAM_LAM_NHASANXU foreign key (MANSX)
      references NHASANXUAT (MANSX)
go

alter table SANPHAM
   add constraint FK_SANPHAM_RELATIONS_KHOHANG foreign key (MAKHO)
      references KHOHANG (MAKHO)
go

alter table SANPHAM
   add constraint FK_SANPHAM_RELATIONS_MATHANGK foreign key (IDLOAI)
      references MATHANGKINHDOANH (IDLOAI)
go

alter table USERGROUP
   add constraint FK_USERGROU_RELATIONS_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV)
go

alter table VANPHONGPHAM
   add constraint FK_VANPHONG_RELATIONS_XUATXU foreign key (MAQUOCGIA)
      references XUATXU (MAQUOCGIA)
go

alter table VANPHONGPHAM
   add constraint FK_VANPHONG_RELATIONS_MATHANGK foreign key (IDLOAI)
      references MATHANGKINHDOANH (IDLOAI)
go

alter table VANPHONGPHAM
   add constraint FK_VANPHONG_RELATIONS_PHANLOAI foreign key (MAPLVPP)
      references PHANLOAIVPP (MAPLVPP)
go

