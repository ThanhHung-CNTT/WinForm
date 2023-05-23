CREATE DATABASE COOP_FOOD
go
USE COOP_FOOD
GO

----------Bảng CHỨC VỤ----------
CREATE TABLE CHUCVU
(
	MaCV Int PRIMARY KEY NOT NULL DEFAULT 0,
	TenCV Nvarchar(100) NOT NULL DEFAULT N'Tên chức vụ',
	Luong Money
)
GO

----------Bảng NHÂN VIÊN----------
CREATE TABLE NHANVIEN 
(
	MaNV Int PRIMARY KEY NOT NULL DEFAULT 0,
	TenNV Nvarchar(100) NOT NULL DEFAULT N'Tên nhân viên',
	GioiTinh Nvarchar(5) NOT NULL,
	NgaySinh Datetime NOT NULL,
	DiaChi Nvarchar(100) NOT NULL,
	CMND Varchar(50) UNIQUE,
	Email Varchar(200) NOT NULL,
	SDT Varchar(20) NOT NULL,
	NgayVaoLam Datetime NOT NULL,
	MucLuong Money NOT NULL,
	MaCV Int NOT NULL
----------Khóa ngoại----------
	FOREIGN KEY(MaCV) REFERENCES dbo.CHUCVU(MaCV)
)
GO

----------Bảng TÀI KHOẢN----------
CREATE TABLE TAIKHOAN
(
	TenDangNhap Varchar(20) PRIMARY KEY,
	MatKhau Varchar(20) NOT NULL,
	MaNV Int NOT NULL,
	PhanQuyen Nvarchar(100),
----------Khóa ngoại----------
    FOREIGN KEY(MaNV) 
		REFERENCES dbo.NHANVIEN(MaNV)
		ON DELETE CASCADE
)
GO

----------Bảng KHÁCH HÀNG----------
CREATE TABLE KHACHHANG
(
	MaKH Int PRIMARY KEY NOT NULL DEFAULT 0,
	TenKH Nvarchar(200) NOT NULL DEFAULT N'Tên khách hàng',
	GioiTinh Nvarchar(5) NOT NULL,
	NgaySinh DateTime NOT NULL,
	DiaChi Nvarchar(100) NULL,
	SDT Varchar(20) NOT NULL,
	TichLuy Int NULL
)
GO

----------Bảng NHÀ CUNG CẤP----------
CREATE TABLE NHACUNGCAP
(
	MaNCC Int PRIMARY KEY NOT NULL DEFAULT 0,
	TenNCC Nvarchar(100) NOT NULL DEFAULT N'Tên nhà cung cấp',
	DiaChi Nvarchar(100) NOT NULL,
    SDT Varchar(20) NOT NULL
)
GO

----------Bảng LOẠI SẢN PHẨM----------
CREATE TABLE LOAISANPHAM
(
   MaLSP Int PRIMARY KEY NOT NULL DEFAULT 0,
   TenLSP Nvarchar(100) NOT NULL DEFAULT N'Tên loại sản phẩm'
)
GO

----------Bảng ĐƠN VỊ TÍNH----------
CREATE TABLE DONVITINH
(
   MaDVT Int PRIMARY KEY NOT NULL DEFAULT 0,
   TenDV Nvarchar(50) NOT NULL DEFAULT N'Tên đơn vị tính'
)
GO

----------Bảng SẢN PHẨM----------
CREATE TABLE SANPHAM
(
	MaSP Int PRIMARY KEY NOT NULL DEFAULT 0,
	TenSP Nvarchar(100) NOT NULL DEFAULT N'Tên sản phẩm',
	MaDVT Int NULL,
	MaLSP Int NOT NULL,
	MaNCC Int NOT NULL,
	SoLuong Int CHECK (SoLuong >= 1) NOT NULL,
	NSX Datetime NOT NULL,
	HSD Datetime NOT NULL,
	NgayNhap Datetime NOT NULL,
	GiaNhap Money NOT NULL,
	GiaBan Money NULL,
	KhuyetMai Float NULL,
----------Khóa ngoại----------
	FOREIGN KEY(MaNCC) REFERENCES dbo.NHACUNGCAP(MaNCC),
	FOREIGN KEY(MaLSP) REFERENCES dbo.LOAISANPHAM(MaLSP),
	FOREIGN KEY(MaDVT) REFERENCES dbo.DONVITINH(MaDVT)
)
GO

----------Bảng HÓA ĐƠN----------
CREATE TABLE HD
(
	MaHD Int PRIMARY KEY NOT NULL,
	MaNV Int NOT NULL,
	MaKH Int NULL,
	NgayMua Datetime NOT NULL,
	TongTien Money NULL,
----------Khóa ngoại----------
    FOREIGN KEY(MaNV) 
		REFERENCES dbo.NHANVIEN(MaNV)
		ON DELETE CASCADE,
	FOREIGN KEY(MaKH) REFERENCES dbo.KHACHHANG(MaKH)
)
GO 

----------Bảng CHI TIẾT HÓA ĐƠN----------
CREATE TABLE CT_HD
(
	MaHD Int,
	MaSP Int,
	SoLuongBan Int CHECK (SoLuongBan >= 1)
----------Khóa ngoại----------
    FOREIGN KEY(MaHD) 
		REFERENCES dbo.HD(MaHD)
		ON DELETE CASCADE,
	FOREIGN KEY(MaSP) 
		REFERENCES dbo.SANPHAM(MaSP)
		ON DELETE CASCADE,
)
GO

-----------------------------------------INSERT INTO-------------------------------------------------------
                        ----------1.Bảng CHỨC VỤ----------
INSERT INTO CHUCVU (MaCV, TenCV, Luong) VALUES (101, N'Quản lý', 10000000);

INSERT INTO CHUCVU (MaCV, TenCV, Luong) VALUES (102, N'Tổ trưởng nghành hàng', 8000000);

INSERT INTO CHUCVU (MaCV, TenCV, Luong) VALUES (103, N'Thủ quỷ hành chính', 8000000);

INSERT INTO CHUCVU (MaCV, TenCV, Luong) VALUES (104, N'Thu ngân-bán hàng', 6000000);

INSERT INTO CHUCVU (MaCV, TenCV, Luong) VALUES (105, N'Bán hàng-kho', 6000000);

INSERT INTO CHUCVU (MaCV, TenCV, Luong) VALUES (106, N'Bán hàng-chế biến thực phẩm tươi sống', 6000000);

						----------2.Bảng NHÂN VIÊN----------
INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MucLuong, MaCV)
VALUES (201, N'Nguyễn Đăng An Ninh', N'Nam', '1989/12/20', N'Bình Dương', 272869013, 'ninhlord@gmail.com', 0322558811, '2017/01/01', 15000000, 101);

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MucLuong, MaCV)
VALUES (202, N'Nguyễn Phạm Thành Hưng', N'Nữ', '1989/05/23', N'Tp.Hồ Chí Minh', 272849014, 'hungless@gmail.com', 0311224455, '2017/02/01', 16000000, 102);

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MucLuong, MaCV)
VALUES (203, N'Phan Thị Kim Nhung', N'Nữ', '2001/06/26', N'Đồng Nai', 272859033, 'nhungbaoden@gmail.com', 0339861477, '2019/01/01', 17000000, 103);

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MucLuong, MaCV)
VALUES (204, N'Kiều Thị Mộng Hiền', N'Nữ', '2002/12/28', N'Phú Yên', 272899067, 'hienga@gmail.com', 0322866772, '2019/01/01', 18000000, 104);

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MucLuong, MaCV)
VALUES (205, N'Trần Tấn Quốc', N'Nam', '1995/05/05', N'Hà Nội', 272815935, 'quocque@gmail.com', 0388774455, '2020/05/01', 19000000, 105);

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MucLuong, MaCV)
VALUES (206, N'Hoắc Kiến Hoa', N'Nam', '1979/12/26', N'Đồng Tháp', 272833557, 'hoa@gami.com', 0311447788, '2020/05/01', 12000000, 106);


						----------3.Bảng ĐĂNG NHẬP----------
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES ('QL201', 123456, 201, N'Quản lý');

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES ('NV202', 123457, 202, N'Nhân viên');

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES ('NV203', 123458, 203, N'Nhân viên');

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES ('NV204', 123459, 204, N'Nhân viên');

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES ('NV205', 123450, 205, N'Nhân viên');

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES ('NV206', 123455, 206, N'Nhân viên');

						----------4.Bảng KHÁCH HÀNG----------
INSERT INTO KHACHHANG (MaKH, TenKH, GioiTinh, NgaySinh, DiaChi, SDT, TichLuy)
VALUES (301, N'Võ Hoài Linh', N'Nam', '1970/12/23 00:00:00', N'Quãng Ngãi', 0347359124, NULL);

INSERT INTO KHACHHANG (MaKH, TenKH, GioiTinh, NgaySinh, DiaChi, SDT, TichLuy)
VALUES (302, N'Đàm Vĩnh Hưng', N'Nam', '1997/06/19 00:00:00', N'Tp Hải Phòng', 0311223335, NUll);

						----------5.Bảng NHÀ CUNG CẤP----------
INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChi, SDT)
VALUES (401, N'Công Ty Thực Phẩm Đồng Xanh', N'Tp.Hồ Chí Minh', 0936685268);

INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChi, SDT)
VALUES (402, N'Công Ty Thực Phẩm Thành Công ', N'Tp.Hồ Chí Minh', 0989464878);

INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChi, SDT)
VALUES (403, N'Công ty cổ phần Bia - Rượu - Nước giải khát Hà Nội', N'Hà Nội', 0243845843);

INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChi, SDT)
VALUES (404, N'Công Ty Cp Sữa Việt Nam Vinamilk', N'Tp.Hồ Chí Minh', 02838237077);

INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChi, SDT)
VALUES (405, N'Công ty TNHH Bánh Kẹo Hải Hà', N'Hà Nội', 02438632956);

INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChi, SDT)
VALUES (406, N'Công Ty TNHH Thương Mại Và Dịch Vụ Thảo Chương Phát', N'Tp.Hồ Chí Minh', 0961855868);

						----------6.Bảng LOẠI SẢN PHẨM----------
INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (501, N'Rau củ quả');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (502, N'Trái cây');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (503, N'Thịt');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (504, N'Hải sản');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (505, N'Thực phẩm đông-mát');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (506, N'Gia vị');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (507, N'Thực phẩm đóng gói');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (508, N'Nước tăng lực');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (509, N'Đồ uống có cồn thực phẩm');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (510, N'Sữa');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (511, N'Bánh ngọt');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (512, N'Kẹo');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (513, N'Hóa phẩm tẩy rửa');

INSERT INTO LOAISANPHAM(MaLSP, TenLSP) VALUES (514, N'Kem');

						----------7.Bảng DƠN VỊ TÍNH----------
INSERT INTO DONVITINH (MaDVT, TenDV) VALUES (901, N'gr');

INSERT INTO DONVITINH (MaDVT, TenDV) VALUES (902, N'kg');

INSERT INTO DONVITINH (MaDVT, TenDV) VALUES (903, N'chai');

INSERT INTO DONVITINH (MaDVT, TenDV) VALUES (904, N'lon');

INSERT INTO DONVITINH (MaDVT, TenDV) VALUES (905, N'hộp');

INSERT INTO DONVITINH (MaDVT, TenDV) VALUES (906, N'bịch');

INSERT INTO DONVITINH (MaDVT, TenDV) VALUES (907, N'gói');

INSERT INTO DONVITINH (MaDVT, TenDV) VALUES (908, N'thùng');

INSERT INTO DONVITINH (MaDVT, TenDV) VALUES (909, N'ly');

INSERT INTO DONVITINH (MaDVT, TenDV) VALUES (910, N'que');

INSERT INTO DONVITINH (MaDVT, TenDV) VALUES (911, N'lốc');


						----------8.Bảng SẢN PHẨM----------
INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (601, N'Cà chua', 902, 501, 401, 100, '2022/01/01 00:00:00', '2022/01/10 00:00:00', '2022/01/02 00:00:00', 9000, 12000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (602, N'Rau mồng tơi', 902, 501, 401, 100,'2022/01/01 00:00:00', '2022/01/05 00:00:00', '2022/01/02 00:00:00', 9000, 12000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (603, N'Dưa hấu', 902, 502, 401, 100, '2022/01/01 00:00:00', '2022/01/08 00:00:00', '2022/01/02 00:00:00', 11000, 15000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (604, N'Ba rọi heo', 902, 503, 402, 50, '2022/01/01 00:00:00', '2022/01/02 00:00:00', '2022/01/02 00:00:00', 170000, 188000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (605, N'Tôm thẻ', 901, 504, 402, 10, '2022/01/01 00:00:00', '2022/01/02 00:00:00', '2022/01/02 00:00:00', 18000, 24000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (606, N'Há cảo Thanh Long', 906, 505, 402, 50, '2022/01/01 00:00:00', '2022/03/01 00:00:00', '2022/01/02 00:00:00', 24000, 58000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (607, N'Bột ngọt hạt lớn Ajinomoto 1kg', 906, 506, 402, 70, '2022/01/01 00:00:00', '2022/08/01 00:00:00', '2022/01/02 00:00:00', 10000, 15000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (608, N'Bột ngọt hạt lớn Ajinomoto 1kg', 908, 506, 402, 70, '2022/01/01 00:00:00', '2022/08/01 00:00:00', '2022/01/02 00:00:00', 120000, 160000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (609, N'Tương ớt Chinsu 250gr', 903, 506, 402, 100, '2022/01/01 00:00:00', '2022/08/01 00:00:00', '2022/01/02 00:00:00', 11000, 16000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (610, N'Tương ớt Chinsu 250gr', 908, 506, 402, 100, '2022/01/01 00:00:00', '2022/08/01 00:00:00', '2022/01/02 00:00:00', 264000, 290000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (611, N'Mì Hảo Hảo', 907, 507, 402, 1200, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 3500, 5000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (612, N'Mì Hảo Hảo', 908, 507, 402, 1200, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 84000, 100000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (613, N'Phở bò Vifon', 907, 507, 402, 1200, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 4500, 7000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (614, N'Phở bò Vifon', 908, 507, 402, 1200, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 108000, 148000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (615, N'Sting dâu lon 320ml', 904, 508, 403, 3000, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 7000, 1000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (616, N'Sting dâu lon 320ml', 908, 508, 403, 3000, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 84000, 128000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (617, N'Sting dâu lon 320ml', 911, 508, 403, 3000, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 42000, 64000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (618, N'Bia Tiger Crystal lon 330ml', 904, 509, 403, 4000, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 15000, 20000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (619, N'Bia Tiger Crystal lon 330ml', 908, 509, 403, 4000, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 360000, 410000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (620, N'Bia Tiger Crystal lon 330ml', 911, 509, 403, 4000, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 90000, 112000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (621, N'Sữa tươi tiệt trùng Vinamilk 100% hộp 180ml', 905, 510, 404, 1000, '2022/01/01 00:00:00', '2022/06/01 00:00:00', '2022/01/02 00:00:00', 5500, 8000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (622, N'Sữa tươi tiệt trùng Vinamilk 100% hộp 180ml', 908, 510, 404, 1000, '2022/01/01 00:00:00', '2022/06/01 00:00:00', '2022/01/02 00:00:00', 264000, 366000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (623, N'Sữa tươi tiệt trùng Vinamilk 100% hộp 180ml', 911, 510, 404, 1000, '2022/01/01 00:00:00', '2022/06/01 00:00:00', '2022/01/02 00:00:00', 22000, 28000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (624, N'Bánh Choco-Pie 20 cái', 905, 511, 405, 150, '2022/01/01 00:00:00', '2022/08/01 00:00:00', '2022/01/02 00:00:00', 70000, 88000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (625, N'Kẹo cà phê KOPIKO 135gr', 907, 512, 405, 300, '2022/01/01 00:00:00', '2022/06/01 00:00:00', '2022/01/02 00:00:00', 10500, 15500, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (626, N'Nước rửa chén sunlight lô hội 600ml', 903, 513, 406, 500, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 10000, 15000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (627, N'Nước rửa chén sunlight lô hội 600ml', 908, 513, 406, 500, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 24000, 300900, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (628, N'Xịt côn trùng Jumbo chanh', 903, 513, 406, 50, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 65000, 80000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (629, N'Kem dừa Vinamilk 100ml', 909, 514, 404, 1500, '2022/01/01 00:00:00', '2022/03/01 00:00:00', '2022/01/02 00:00:00', 7000, 10000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (630, N'Kem dừa Vinamilk 100ml', 909, 514, 404, 1500, '2022/01/01 00:00:00', '2022/03/01 00:00:00', '2022/01/02 00:00:00', 84000, 104000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (631, N'Sữa chua Vinamilk', 905, 505, 404, 2000, '2022/01/01 00:00:00', '2022/04/01 00:00:00', '2022/01/02 00:00:00', 5000, 7000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (632, N'Sữa chua Vinamilk', 911, 505, 404, 2000, '2022/01/01 00:00:00', '2022/04/01 00:00:00', '2022/01/02 00:00:00', 20000, 26000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (633, N'Sữa chua Vinamilk', 908, 505, 404, 2000, '2022/01/01 00:00:00', '2022/04/01 00:00:00', '2022/01/02 00:00:00', 240000, 279000, NULL);

						----------9.Bảng HÓA ĐƠN----------
INSERT INTO HD (MaHD, MaNV, MaKH, NgayMua, TongTien) VALUES (701, 204, 301, '2022/01/03 08:00:00', NULL);

INSERT INTO HD (MaHD, MaNV, MaKH, NgayMua, TongTien) VALUES (702, 205, 302, '2022/01/03 08:30:00', NULL);

						----------10.Bảng CHI TIẾT HÓA ĐƠN----------
INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan) VALUES (701, 603, 1);

INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan) VALUES (701, 611, 6);

INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan) VALUES (701, 618, 1);

INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan) VALUES (701, 620, 10);

INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan) VALUES (701, 602, 1);

INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan) VALUES (702, 605, 1);

INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan) VALUES (702, 612, 24);

-----------------------------------------STORED PROCEDURE--------------------------------------------------
						----------1.Proc Tài Khoản----------
CREATE PROC [dbo].[SP_TAIKHOAN]
@TenDangNhap Int,
@MatKhau Varchar(20)
AS
BEGIN
    SELECT * FROM dbo.TAIKHOAN
	WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau
END

						----------2.Proc Báo Cáo Thống Kê----------
----a,Báo cáo doanh thu sản phẩm theo ngày---
CREATE PROC [dbo].[SP_BCDTTheoNgay]
    @Ngay Datetime
AS
BEGIN
DECLARE @Ngay Datetime
    SELECT A.MaSP, TenSP, NgayMua, TongTien, A.SoLuongBan, GiaSP
	FROM CT_HD AS A, SANPHAM AS B, HD AS C
	WHERE A.MaSP = B.MaSP AND A.MaHD = C.MaHD AND NgayMua >= @Ngay
END

-----------------------------------------TRIGGER-----------------------------------------------------------
---1.Check giá của sản phẩm phải lớn hơn 0---
CREATE TRIGGER TGCheckgiaSP ON SANPHAM FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @Gia Money
	SELECT @Gia = GiaBan 
	FROM inserted
	IF(@Gia <= 0)
	BEGIN
	 PRINT N'Giá của dịch vụ phải lớn hơn 0'
	 ROLLBACK TRAN
	END
END
select * from khachhang
---2.Check tuổi nhân viên phải đủ 18 tuổi---
CREATE TRIGGER TGCheckTuoiNV ON NHANVIEN FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @Tuoi Int
	SET @Tuoi = (SELECT (YEAR(GETDATE())-Year(NHANVIEN.NgaySinh)) FROM NHANVIEN, Inserted  WHERE NHANVIEN.MaNV = Inserted.MaNV)
	IF(@Tuoi<18)
	BEGIN 
	PRINT N' Nhân viên chưa đủ 18 tuổi '
	ROLLBACK TRAN
	END
END

-------
SELECT * FROM SANPHAM

WHERE TenSP LIKE "a%";

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END

SELECT * FROM nhacungcap WHERE dbo.fuConvertToUnsign1(tenNCC) LIKE N'%' + dbo.fuConvertToUnsign1(N'cong') + '%'