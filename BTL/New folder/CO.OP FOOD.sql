CREATE DATABASE COOP_FOOD
USE COOP_FOOD
GO

----------Bảng NHÂN VIÊN----------
CREATE TABLE NHANVIEN 
(
	MaNV Int PRIMARY KEY NOT NULL DEFAULT 0,
	TenNV Nvarchar(100) NOT NULL Default N'Tên nhân viên',
	GioiTinh Nvarchar(5) NOT NULL,
	NgaySinh Datetime NOT NULL,
	DiaChi Nvarchar(100) NOT NULL,
	CMND Varchar(50) UNIQUE,
	Email Varchar(200) NOT NULL,
	SDT Varchar(20),
	NgayVaoLam Datetime NOT NULL,
	TenCV Nvarchar(100) NOT NULL
)
GO
select*from nhanvien
----------Bảng TÀI KHOẢN----------
CREATE TABLE TAIKHOAN
(
	TenDangNhap Int PRIMARY KEY,
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
	TenKH Nvarchar(200) NOT NULL Default N'Tên khách hàng',
	GioiTinh Nvarchar(5) NOT NULL,
	NgaySinh DateTime NOT NULL,
	DiaChi Nvarchar(100) NOT NULL,
	SDT Varchar(20) NOT NULL,
	TichLuy Int NULL
)
GO

----------Bảng NHÀ CUNG CẤP----------
CREATE TABLE NHACUNGCAP
(
	MaNCC Int PRIMARY KEY NOT NULL DEFAULT 0,
	TenNCC Nvarchar(100) NOT NULL Default N'Tên nhà cung cấp',
	DiaChi Nvarchar(100) NOT NULL,
    SDT Varchar(20) NOT NULL
)
GO

----------Bảng LOẠI SẢN PHẨM----------
CREATE TABLE LOAISANPHAM
(
   MaLSP Int PRIMARY KEY NOT NULL DEFAULT 0,
   TenLSP Nvarchar(100) NOT NULL Default N'Tên loại sản phẩm'
)
GO

----------Bảng SẢN PHẨM----------
CREATE TABLE SANPHAM
(
	MaSP Int PRIMARY KEY NOT NULL DEFAULT 0,
	TenSP Nvarchar(100) NOT NULL Default N'Tên sản phẩm',
	MaLSP Int,
	MaNCC Int,
	SoLuong Int CHECK (SoLuong >= 1) NOT NULL,
	NSX Datetime NOT NULL,
	HSD Datetime NOT NULL,
	NgayNhap Datetime NOT NULL,
	GiaNhap Money NOT NULL,
	GiaBan Money NOT NULL,
	KhuyetMai Float NULL,
----------Khóa ngoại----------
	FOREIGN KEY(MaNCC) REFERENCES dbo.NHACUNGCAP(MaNCC),
	FOREIGN KEY(MaLSP) REFERENCES dbo.LOAISANPHAM(MaLSP)
)
GO

----------Bảng HÓA ĐƠN----------
CREATE TABLE HD
(
	MaHD Int PRIMARY KEY NOT NULL,
	MaNV Int,
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
	SoLuongBan Int CHECK (SoLuongBan >= 1),
	GiaSP Money NOT NULL,
----------Khóa ngoại----------
    FOREIGN KEY(MaHD) 
		REFERENCES dbo.HD(MaHD)
		ON DELETE CASCADE,
	FOREIGN KEY(MaSP) REFERENCES dbo.SANPHAM(MaSP)
)
GO

-----------------------------------------INSERT INTO-------------------------------------------------------
 					 ----------1.Bảng NHÂN VIÊN----------
INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, TenCV)
VALUES (101, N'Nguyễn Đăng An Ninh', N'Nam', '1989/12/20 00:00:00', N'Bình Dương', 272869013, 'ninhlord@gmail.com', 0322558811, '2017/01/01 08:00:00', N'Quản lý');

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, TenCV)
VALUES (102, N'Nguyễn Phạm Thành Hưng', N'Nữ', '1989/05/23 00:00:00', N'Tp.Hồ Chí Minh', 272849014, 'hungless@gmail.com', 0311224455, '2017/02/01 08:00:00', N'Tổ trưởng nghành hàng');

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, TenCV)
VALUES (103, N'Phan Thị Kim Nhung', N'Nữ', '2001/06/26 00:00:00', N'Đồng Nai', 272859033, 'nhungbaoden@gmail.com', 0339861477, '2019/01/01 08:00:00', N'Thủ quỷ hành chính');

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, TenCV)
VALUES (104, N'Kiều Thị Mộng Hiền', N'Nữ', '2002/12/28 00:00:00', N'Phú Yên', 272899067, 'hienga@gmail.com', 0322866772, '2019/01/01 08:00:00', N'Thu ngân-bán hàng');

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, TenCV)
VALUES (105, N'Trần Tấn Quốc', N'Nam', '1995/05/05 00:00:00', N'Hà Nội', 272815935, 'quocque@gmail.com', 0388774455, '2020/05/01 08:00:00', N'Bán hàng-kho');

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, TenCV)
VALUES (106, N'Hoắc Kiến Hoa', N'Nam', '1979/12/26 00:00:00', N'Đồng Tháp', 272833557, 'hoa@gami.com', 0311447788, '2020/05/01 08:00:00', N'Bán hàng-chế biến thực phẩm tươi sống');

						----------2.Bảng ĐĂNG NHẬP----------
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES (201, 123456, 101, N'Quản lý');

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES (202, 123457, 102, N'Nhân viên');

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES (203, 123458, 103, N'Nhân viên');

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES (204, 123459, 104, N'Nhân viên');

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES (205, 123450, 105, N'Nhân viên');

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES (206, 123455, 106, N'Nhân viên');

						----------3.Bảng KHÁCH HÀNG----------
INSERT INTO KHACHHANG (MaKH, TenKH, GioiTinh, NgaySinh, DiaChi, SDT, TichLuy)
VALUES (301, N'Võ Hoài Linh', N'Nam', '1970/12/23 00:00:00', N'Quãng Ngãi', 0347359124, NULL);

INSERT INTO KHACHHANG (MaKH, TenKH, GioiTinh, NgaySinh, DiaChi, SDT, TichLuy)
VALUES (302, N'Đàm Vĩnh Hưng', N'Nam', '1997/06/19 00:00:00', N'Tp Hải Phòng', 0311223335, NUll);

						----------4.Bảng NHÀ CUNG CẤP----------
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

						----------5.Bảng SẢN PHẨM----------
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

						----------6.Bảng SẢN PHẨM----------
INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (601, N'Cà chua', 501, 401, 100, '2022/01/01 00:00:00', '2022/01/10 00:00:00', '2022/01/02 00:00:00', 9000, 12000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (602, N'Rau mồng tơi',501, 401, 100,'2022/01/01 00:00:00', '2022/01/05 00:00:00', '2022/01/02 00:00:00', 9000, 12000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (603, N'Dưa hấu', 502, 401, 100, '2022/01/01 00:00:00', '2022/01/08 00:00:00', '2022/01/02 00:00:00', 11000, 15000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (604, N'Ba rọi heo', 503, 402, 50, '2022/01/01 00:00:00', '2022/01/02 00:00:00', '2022/01/02 00:00:00', 170000, 188000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (605, N'Tôm thẻ', 504, 402, 10, '2022/01/01 00:00:00', '2022/01/02 00:00:00', '2022/01/02 00:00:00', 180000, 240000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (606, N'Há cảo Thanh Long', 505, 402, 50, '2022/01/01 00:00:00', '2022/03/01 00:00:00', '2022/01/02 00:00:00', 24000, 58000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (607, N'Bột ngọt hạt lớn Ajinomoto ', 506, 402, 70, '2022/01/01 00:00:00', '2022/08/01 00:00:00', '2022/01/02 00:00:00', 18000, 34000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (608, N'Tương ớt Chinsu', 606, 502, 100, '2022/01/01 00:00:00', '2022/08/01 00:00:00', '2022/01/02 00:00:00', 18000, 26000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (609, N'Mì Hảo Hảo', 507, 402, 1200, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 2300, 5000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (610, N'Phở bò Vifon', 507, 402, 1200, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 4300, 8000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (611, N'Sting', 508, 403, 3000, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 7000, 11000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (612, N'Bia Tiger', 509, 403, 4000, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 15000, 22000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (613, N'Sữa tươi tiệt trùng Vinamilk 100%', 510, 404, 1000, '2022/01/01 00:00:00', '2022/06/01 00:00:00', '2022/01/02 00:00:00', 4000, 8000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (614, N'Sữa đậu nành Vinamilk hạt óc chó', 510, 404, 1000, '2022/01/01 00:00:00', '2022/06/01 00:00:00', '2022/01/02 00:00:00', 4000, 8000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (615, N'Bánh Choco Pie', 511, 405, 150, '2022/01/01 00:00:00', '2022/08/01 00:00:00', '2022/01/02 00:00:00', 18000, 28000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (616, N'Kẹo cà phê Kopiko', 512, 405, 300, '2022/01/01 00:00:00', '2022/06/01 00:00:00', '2022/01/02 00:00:00', 20000, 35000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (617, N'Nước rửa chén sunlight lô hội', 513, 406, 500, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 55000, 80000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (618, N'Xịt côn trùng Jumbo chanh', 513, 406, 50, '2022/01/01 00:00:00', '2023/01/01 00:00:00', '2022/01/02 00:00:00', 50000, 69000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (619, N'Kem dừa Vinamilk', 514, 404, 1500, '2022/01/01 00:00:00', '2022/03/01 00:00:00', '2022/01/02 00:00:00', 7000, 15000, NULL);

INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan, KhuyetMai)
VALUES (620, N'Sữa chua Vinamilk', 505, 404, 2000, '2022/01/01 00:00:00', '2022/04/01 00:00:00', '2022/01/02 00:00:00', 2300, 6000, NULL);

						----------7.Bảng HÓA ĐƠN----------
INSERT INTO HD (MaHD, MaNV, MaKH, NgayMua, TongTien) VALUES (701, 104, 301, '2022/01/03 08:00:00', NULL);

INSERT INTO HD (MaHD, MaNV, MaKH, NgayMua, TongTien) VALUES (702, 105, 302, '2022/01/03 08:30:00', NULL);

						----------8.Bảng CHI TIẾT HÓA ĐƠN----------
INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan, GiaSP) VALUES (701, 603, 1, 12000);

INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan, GiaSP) VALUES (701, 611, 6, 11000);

INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan, GiaSP) VALUES (701, 618, 1, 69000);

INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan, GiaSP) VALUES (701, 620, 10, 6000);

INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan, GiaSP) VALUES (701, 602, 1, 12000);

INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan, GiaSP) VALUES (702, 605, 1, 240000);

INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan, GiaSP) VALUES (702, 612, 24, 22000);

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
    SELECT A.MaSP, TenSP, NgayMua, A.SoLuongBan, GiaSP
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