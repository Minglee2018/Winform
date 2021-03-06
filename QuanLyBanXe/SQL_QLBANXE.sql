Create database QuanLyBanXe
use QuanLyBanXe

create table Admin(
	taiKhoan nvarchar(50) not null primary key,
	matKhau nvarchar(50) not null
)
insert into Admin values('Admin','123456')

create table KhachHang(
	maKH nvarchar(15) primary key not null,
	tenKH nvarchar(50) not null,
	gioiTinh nvarchar(10),
	diaChi nvarchar(200) not null,
	sdt nvarchar(20) not null
)
insert into KhachHang values('KH01', N'Trần Quốc Nghĩa', N'Nam', N'Hải Dương', '0981233456')
insert into KhachHang values('KH02', N'Hà Quang Phúc', N'Nam', N'Hà Đông', '019283912')
insert into KhachHang values('KH03', N'Nguyễn Thị Huyền', N'Nữ', N'Hải Phòng', '0981233456')
insert into KhachHang values('KH04', N'Hằng Nguyễn', N'Nữ', N'Hà Nội', '0981233456')
insert into KhachHang values('KH05', N'Huyền Trang', N'Nữ', N'Quảng Ninh', '0981233456')

select * from KhachHang

create table NhanVien(
	maNV nvarchar(15) primary key not null,
	tenNV nvarchar(50) not null,
	gioiTinh nvarchar(10),
	diaChi nvarchar(200) not null,
	sdt nvarchar(20) not null,
	chucVu nvarchar(50),
	ngayVaoLam date,
	matKhau nvarchar(50)
)

insert into NhanVien values('NV01',N'Nguyễn Văn A','Nam', N'Hà Nội', '0986612731', N'Nhân Viên', '2019-09-08', 'demo123')
insert into NhanVien values('NV02',N'Hoàng Thị Lan',N'Nữ', N'Hải Phòng', '0986612731', N'Kế Toán', '2018-10-12', 'demo123')
insert into NhanVien values('NV03',N'Quốc Toàn','Nam', N'Hà Nội', '0986612731', N'Kiểm Toán', '2020-10-08', 'demo123')
insert into NhanVien values('NV04',N'Nguyễn Thị Chi',N'Nữ', N'Phú Thọ', '0986612731', N'Nhân Viên', '2017-06-12', 'demo123')
select * from NhanVien

create table NhaCungCap(
	maNCC nvarchar(15) primary key not null,
	tenNCC nvarchar(50) not null,
	diaChi nvarchar(200) not null,
	sdt nvarchar(20) not null
)

insert into NhaCungCap values('NCC01', N'Honda Việt Nam', N'Hà Nội', '0123456789') 
insert into NhaCungCap values('NCC02', N'Toyota Việt Nam',N'Hồ Chí Minh', '0981273123')
insert into NhaCungCap values('NCC03', N'BMW',N'Sài Gòn', '0123456789')
insert into NhaCungCap values('NCC04', N'Suzuki',N'Hà Nam', '0123426123')



create table LoaiXe(
	maLoaiXe nvarchar(15) primary key not null,
	tenLoaiXe nvarchar(50) not null
)

insert into LoaiXe values('LX01', N'Xe Khách')
insert into LoaiXe values('LX02', N'Xe Du Lịch')
insert into LoaiXe values('LX03', N'Xe Tải')
insert into LoaiXe values('LX04', N'Xe chuyên dụng')

create table Xe(
	maXe nvarchar(15) primary key not null,
	maLoaiXe nvarchar(15) not null,
	maNCC nvarchar(15) not null,
	tenXe nvarchar(50) not null,
	giaNhap Float,
	giaBan Float,
	mau varchar(20),
	dungTich Float,
	tinhTrang nvarchar(50),
	constraint FK_maLoaiXe foreign key(maLoaiXe) references LoaiXe(maLoaiXe) ON DELETE CASCADE,
	constraint FK_maNCC_Xe foreign key(maNCC) references NhaCungCap(maNCC) ON DELETE CASCADE
)

insert into Xe values('X01', 'LX01','NCC02','Bugatti Divo',120000,232000, N'Cam', 3.4,N'Mới')
insert into Xe values('X02', 'LX03','NCC01','Mercedes-Maybach Exelero',450000,820000,N'Xanh', 2.4,N'Cũ')
insert into Xe values('X03', 'LX02','NCC04','Rolls-Royce Sweptail',620000,750000,N'Vàng', 5.6,N'Mới')
insert into Xe values('X04', 'LX01','NCC03','Bugatti Divo',230000,502000,N'Đen', 2.4,N'Mới')
insert into Xe values('X05', 'LX03','NCC02','Lamborghini Veneno',153000,450000,N'Tím', 1.4,N'Cũ')

select * from Xe

create table BaoHanh(
	maPhieuBH nvarchar(15) primary key not null,
	maNV nvarchar(15) not null,
	maKH nvarchar(15) not null,
	maXe nvarchar(15) not null,
	TGBH nvarchar(50),
	ngayMua date,
	constraint FK_maNV_BH foreign key(maNV) references NhanVien(maNV) ON DELETE CASCADE,
	constraint FK_maKH_BH foreign key(maKH) references KhachHang(maKH) ON DELETE CASCADE,
	constraint FK_maXe_BH foreign key(maXe) references Xe(maXe) ON DELETE CASCADE
)
insert into BaoHanh values('PH01','NV02','KH01','X02',N'12 tháng', '2022-01-08')
insert into BaoHanh values('PH02','NV01','KH03','X01',N'36 tháng', '2023-09-14')
insert into BaoHanh values('PH03','NV03','KH02','X04',N'24 tháng', '2021-07-15')
select * from BaoHanh
select * from HoaDonXuat, ChiTietHDXuat Where HoaDonXuat.maHDX = ChiTietHDXuat.maHDX

create table HoaDonNhap(
	maHDN nvarchar(15) primary key not null,
	maNV nvarchar(15) not null,
	maNCC nvarchar(15) not null,
	ngayNhap date,
	constraint FK_manv_N foreign key(maNV) references NhanVien(maNV) ON DELETE CASCADE,
	constraint FK_mancc foreign key(maNCC) references NhaCungCap(maNCC) ON DELETE CASCADE
)
insert into HoaDonNhap values('HDN01','NV01','NCC02','2020-08-09')
insert into HoaDonNhap values('HDN02','NV02','NCC03','2019-1-18')
insert into HoaDonNhap values('HDN03','NV01','NCC01','2022-12-11')
insert into HoaDonNhap values('HDN04','NV03','NCC04','2021-08-12')
insert into HoaDonNhap values('HDN05','NV04','NCC01','2021-10-12')
select * from HoaDonNhap

create table ChiTietHDNhap(	
	maHDN nvarchar(15) not null,
	maXe nvarchar(15) not null,
	soLuong Integer not null,
	thueVAT Float,
	thanhTien Float,
	constraint PK_ChiTietHDN primary key(maHDN,maXe),
	constraint FK_maHDN foreign key(maHDN) references HoaDonNhap(maHDN),
	constraint FK_maXeN foreign key(maXe) references Xe(maXe) ON DELETE CASCADE
)
insert into ChiTietHDNhap values('HDN01','X02',12,0.3, 7020000)
insert into ChiTietHDNhap values('HDN02','X03',20,0.4, 17360000)
insert into ChiTietHDNhap values('HDN03','X01',8,0.5,1440000)
insert into ChiTietHDNhap values('HDN04','X02',10,0.6,7200000)
insert into ChiTietHDNhap values('HDN05','X04',10,0.4,3220000)

select * from Xe
select * from ChiTietHDNhap

create table HoaDonXuat(
	maHDX nvarchar(15) primary key not null,
	maNV nvarchar(15) not null,
	maKH nvarchar(15) not null,
	ngayXuat date
	constraint FK_manv_X foreign key(maNV) references NhanVien(maNV) ON DELETE CASCADE,
	constraint FK_makh foreign key(maKH) references KhachHang(maKH) ON DELETE CASCADE
)

insert into HoaDonXuat values('HDX01','NV01','KH02','2023-12-12')
insert into HoaDonXuat values('HDX02','NV02','KH03','2024-09-09')
insert into HoaDonXuat values('HDX03','NV01','KH01','2022-1-08')
insert into HoaDonXuat values('HDX04','NV04','KH02','2021-7-15')
insert into HoaDonXuat values('HDX05','NV03','KH04','2023-9-14')
select * from HoaDonXuat

create table ChiTietHDXuat(	
	maHDX nvarchar(15) not null,
	maXe nvarchar(15) not null,
	soLuong Integer not null,
	thueVAT Float,
	thanhTien Float,
	constraint PK_ChiTietHDX primary key(maHDX,maXe),
	constraint FK_maHDX foreign key(maHDX) references HoaDonXuat(maHDX) ON DELETE CASCADE,
	constraint FK_maXeX foreign key(maXe) references Xe(maXe) ON DELETE CASCADE
)
insert into ChiTietHDXuat values('HDX01','X03',1,0.5,1125000)
insert into ChiTietHDXuat values('HDX02','X02',2,0.4,2296000)
insert into ChiTietHDXuat values('HDX04','X04',1,0.6,803200)
insert into ChiTietHDXuat values('HDX03','X01',1,0.4,324800)
insert into ChiTietHDXuat values('HDX05','X02',2,0.3,2132000)
select * from ChiTietHDXuat


select * from Admin
select * from BaoHanh
select * from ChiTietHDNhap
select * from HoaDonNhap
select * from HoaDonXuat
select * from ChiTietHDXuat
select * from KhachHang
select * from LoaiXe
select * from NhaCungCap
select * from NhanVien
select * from Xe

SELECT HoaDonXuat.maHDX, ChiTietHDXuat.maXe, maNV, maKH,ngayXuat from HoaDonXuat, ChiTietHDXuat WHERE HoaDonXuat.maHDX = ChiTietHDXuat.maHDX AND maNV = 'NV01'

select * from BaoHanh
select * from HoaDonXuat
select * from ChiTietHDXuat

select * from HoaDonXuat, ChiTietHDXuat, BaoHanh Where HoaDonXuat.maHDX = ChiTietHDXuat.maHDX AND
BaoHanh.maXe = ChiTietHDXuat.maXe AND HoaDonXuat.maNV = 'NV01';

delete from KhachHang where maKH='KH01'
delete from NhanVien where maNV='NV01'
delete from Xe where maXe='X01'
delete from NhaCungCap where maNCC='NCC01'