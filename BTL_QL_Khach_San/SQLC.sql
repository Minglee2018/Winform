/*
Created		10/03/2019
Modified		14/03/2019
Project		
Model		
Company		
Author		
Version		
Database		MS SQL 7 
*/

use master
go

create database BTL
go

use BTL
go



Create table [NhanVien] (
	[maNV] Nvarchar(10) NOT NULL,
	[tenNV] Nvarchar(30) NULL,
	[diaChi] Nvarchar(50) NULL,
	[SDT] Nvarchar(10) NULL,
	[chucVu] Nvarchar(30) NULL,
	[ngaySinh] Datetime NULL,
	[gioiTinh] Bit NULL,
	[taiKhoan] Char(30) NULL,
	[matKhau] Char(30) NULL,
Primary Key  ([maNV])
) 
go

Create table [Phong] (
	[soPhong] Integer NOT NULL,
	[loaiPhong] Nvarchar(30) NULL,
	[tinhTrang] Bit NULL,
	[gia] Money NULL,
Primary Key  ([soPhong])
) 
go

Create table [NV_Phong] (
	[maNV] Nvarchar(10) NOT NULL,
	[soPhong] Integer NOT NULL,
Primary Key  ([maNV],[soPhong])
) 
go

Create table [DichVu] (
	[maDV] Nvarchar(10) NOT NULL,
	[tenDV] Nvarchar(30) NULL,
	[moTa] Nvarchar(100) NULL,
	[donGia] Money NULL,
Primary Key  ([maDV])
) 
go

Create table [NV_DV] (
	[maNV] Nvarchar(10) NOT NULL,
	[maDV] Nvarchar(10) NOT NULL,
Primary Key  ([maNV],[maDV])
) 
go

Create table [KhachHang] (
	[CMT] Integer NOT NULL,
	[tenKH] Nvarchar(30) NULL,
	[SDT] Nvarchar(10) NULL,
	[diaChi] Nvarchar(50) NULL,
	[gioiTinh] Bit NULL,
	[ngaySinh] Datetime NULL,
Primary Key  ([CMT])
) 
go

Create table [HoaDon] (
	[maHD] int IDENTITY NOT NULL ,
	[CMT] Integer NOT NULL,
	[soPhong] Integer NOT NULL,
	[ngayVao] Datetime NULL,
	[ngayRa] Datetime NULL,
	[thanhToan] Bit NULL,
Primary Key  ([maHD])
) 
go


Create table [DatDV] (
	[maDV] Nvarchar(10) NOT NULL,
	[maHD] int  NOT NULL,
	[soluong] Integer NULL,
Primary Key  ([maDV],[maHD]),
FOREIGN KEY ([maHD]) REFERENCES [HoaDon]([maHD]),
FOREIGN KEY ([maDV]) REFERENCES [DichVu]([maDV])
) 
go

Alter table [NV_Phong] add  foreign key([maNV]) references [NhanVien] ([maNV]) 
go
Alter table [NV_DV] add  foreign key([maNV]) references [NhanVien] ([maNV]) 
go
Alter table [NV_Phong] add  foreign key([soPhong]) references [Phong] ([soPhong]) 
go
Alter table [HoaDon] add  foreign key([soPhong]) references [Phong] ([soPhong]) 
go
Alter table [NV_DV] add  foreign key([maDV]) references [DichVu] ([maDV]) 
go
Alter table [HoaDon] add  foreign key([CMT]) references [KhachHang] ([CMT]) 
go


Set quoted_identifier on
go

Set quoted_identifier off
go



INSERT INTO dbo.Phong
        ( soPhong, loaiPhong, tinhTrang, gia )
VALUES  ( 0, -- soPhong - int
          N'Vip', -- loaiPhong - nvarchar(30)
          0, -- tinhTrang - bit
          1000 -- gia - money
          )
		  INSERT INTO dbo.Phong
        ( soPhong, loaiPhong, tinhTrang, gia )
VALUES  ( 1, -- soPhong - int
          N'Thường', -- loaiPhong - nvarchar(30)
          0, -- tinhTrang - bit
          2000 -- gia - money
          )
		  		  INSERT INTO dbo.Phong
        ( soPhong, loaiPhong, tinhTrang, gia )
VALUES  ( 3, -- soPhong - int
          N'Thường', -- loaiPhong - nvarchar(30)
          0, -- tinhTrang - bit
          2000 -- gia - money
          )
 INSERT INTO dbo.Phong VALUES (2,N'Vip',0,5000) 
INSERT INTO dbo.NhanVien VALUES ('1',N'Nguyễn Văn Thành',N'Hà Nội','987654321',N'Quản lý','19980219',1,'adminThanh','admin')
INSERT INTO dbo.NhanVien VALUES ('2',N'Nguyễn Văn Tứ',N'Hà Nội','123456789',N'Quản lý','19980219',1,'adminTu','admin')
INSERT INTO dbo.NhanVien VALUES ('3',N'Lã Thanh Nam',N'Hà Nội','671234567',N'Quản lý','19980219',1,'adminNam','admin')
INSERT INTO dbo.NhanVien VALUES ('4',N'Nguyễn Văn Bình',N'Ha Noi','0000000000',N'Nhân viên','19980219',1,'binhnv','admin')

INSERT INTO dbo.DichVu
        ( maDV, tenDV, moTa, donGia )
VALUES  ( N'1', -- maDV - nvarchar(10)
          N'Nước ngọt', -- tenDV - nvarchar(30)
          N'Đồ uống', -- moTa - nvarchar(100)
          15000  -- donGia - money
          )
INSERT INTO dbo.DichVu
        ( maDV, tenDV, moTa, donGia )
VALUES  ( N'2', -- maDV - nvarchar(10)
          N'Ăn sáng', -- tenDV - nvarchar(30)
          N'Ăn bữa sáng', -- moTa - nvarchar(100)
          50000  -- donGia - money
          )
GO
INSERT INTO dbo.DichVu
        ( maDV, tenDV, moTa, donGia )
VALUES  ( N'3', -- maDV - nvarchar(10)
          N'Ăn trưa', -- tenDV - nvarchar(30)
          N'Ăn bữa trưa', -- moTa - nvarchar(100)
          100000  -- donGia - money
          )
GO
INSERT INTO dbo.DichVu
        ( maDV, tenDV, moTa, donGia )
VALUES  ( N'4', -- maDV - nvarchar(10)
          N'Ăn tối', -- tenDV - nvarchar(30)
          N'Ăn bữa tối', -- moTa - nvarchar(100)
          100000  -- donGia - money
          )
GO

 


INSERT INTO dbo.KhachHang VALUES (1141460126,N'Lã Thanh Nam','0963885507',N'Phú Thọ',1,'19980219')
INSERT INTO dbo.KhachHang VALUES (132300748,N'Lã Thanh Nam 1','0963885507',N'Phú Thọ',1,'19980219')




CREATE PROC ThemDV1(@maDV nvarchar(10),@soLuong int,@soPhong int)
AS
BEGIN
	DECLARE @maHD INT  
 	SELECT @maHD = maHD FROM dbo.HoaDon WHERE thanhToan=0 AND soPhong=@soPhong	
	IF(EXISTS(SELECT * FROM dbo.DatDV WHERE maDV=@maDV AND maHD=@maHD))
	UPDATE dbo.DatDV SET soluong=soluong+@soLuong WHERE maDV=@maDV AND maHD=@maHD
	else
	INSERT INTO dbo.DatDV
	        ( maDV, maHD, soluong )
	VALUES  ( @maDV, -- maDV - nvarchar(10)
	          @maHD, -- maHD - int
	          @soLuong -- soluong - int
	          )
END

CREATE PROC XoaDV1(@soPhong int,@maDV NVARCHAR(10))
AS
BEGIN
	DECLARE @maHD INT
 	SELECT @maHD = maHD FROM dbo.HoaDon WHERE thanhToan=0 AND soPhong=@soPhong
	DELETE dbo.DatDV WHERE maDV=@maDV AND maHD = @maHD
END



select * from HoaDon
select * from Phong
select * from DichVu