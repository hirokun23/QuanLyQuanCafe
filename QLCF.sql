IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QLCF')
    DROP DATABASE QLCF
GO

CREATE DATABASE QLCF
GO

USE QLCF
GO

CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    TenNV NVARCHAR(100),
    NgaySinh DATE,
    SDT NVARCHAR(20),
    GioiTinh NVARCHAR(10), 
    DiaChi NVARCHAR(200),
    ChucVu NVARCHAR(50),
    Luong FLOAT
)

-- BẢNG TÀI KHOẢN
CREATE TABLE TaiKhoan
(
    TenDangNhap NVARCHAR(50),
    MatKhau NVARCHAR(50)
);

-- DATA TEST TÀI KHOẢN
INSERT INTO TaiKhoan VALUES
('admin', '123'),
('user', '123');

-- DATA TEST NHÂN VIÊN
INSERT INTO NhanVien (TenNV, NgaySinh, SDT, GioiTinh, DiaChi, ChucVu, Luong)
VALUES 
(N'A', '2004-01-01', '0123456789', N'Nam', N'Bình Dương', N'Nhân viên', 5000000),
(N'B', '2003-05-10', '0987654321', N'Nam', N'HCM', N'Quản lý', 10000000);

-- ================= BÀN =================
CREATE TABLE Ban (
    MaBan INT IDENTITY(1,1) PRIMARY KEY,
    TenBan NVARCHAR(100),
    TrangThai NVARCHAR(50)
)

INSERT INTO Ban VALUES
(N'Bàn 1', N'Trống'),
(N'Bàn 2', N'Có khách')

-- ================= MÓN =================
CREATE TABLE Mon (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100),
    Gia FLOAT,
    Loai NVARCHAR(50)
)

INSERT INTO Mon VALUES
(N'Cà phê sữa', 20000, N'Cafe'),
(N'Trà đào', 25000, N'Trà'),
(N'Nước suối', 10000, N'Nước')

-- ================= NGUYÊN LIỆU =================
CREATE TABLE NguyenLieu (
    MaNL NVARCHAR(20) PRIMARY KEY,
    TenNL NVARCHAR(100),
    SoLuong INT
)

INSERT INTO NguyenLieu VALUES
('NL01', N'Cà phê', 50),
('NL02', N'Sữa', 30),
('NL03', N'Trà', 40)

-- ================= HÓA ĐƠN =================
CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    Ngay DATETIME,
    TongTien FLOAT
)

INSERT INTO HoaDon VALUES
(GETDATE(), 100000),
(GETDATE(), 200000)

-- ================= TEST =================
SELECT * FROM NhanVien
SELECT * FROM Ban
SELECT * FROM Mon
SELECT * FROM NguyenLieu
SELECT * FROM HoaDon