CREATE DATABASE Cyber_net
GO
USE Cyber_net

GO
--DROP DATABASE Cyber_net
CREATE TABLE dbo.District (
	Id INT NOT NULL,
	District NVARCHAR(255) NOT NULL,
	CONSTRAINT district_pk PRIMARY KEY (Id)
);

CREATE TABLE dbo.Chinhanh (
	Id INT NOT NULL,
	Chinhanh NVARCHAR(255) NOT NULL,
	Id_district INT NOT NULL
	CONSTRAINT chinhanh_pk PRIMARY KEY (Id),
	CONSTRAINT chinhanh_fk FOREIGN KEY (Id_district) REFERENCES dbo.District (Id)
);

CREATE TABLE dbo.Phongmay (
	Id INT NOT NULL,
	Typed NVARCHAR(50) NOT NULL,
	Count INT NOT NULL,
	Id_chinhanh INT NOT NULL,
	FOREIGN KEY (Id_chinhanh) REFERENCES dbo.Chinhanh (Id),
	CONSTRAINT phongmay_pk PRIMARY KEY (Id)
);

CREATE TABLE dbo.Maytinh (
	Id INT NOT NULL,
	Status CHAR(30) NOT NULL,
	Time_use TIME NOT NULL,
	Id_Phongmay INT NOT NULL,
	FOREIGN KEY (Id_Phongmay)
	REFERENCES dbo.Phongmay (Id),
	CONSTRAINT maytinh_pk PRIMARY KEY (Id,Id_Phongmay)
);

CREATE TABLE dbo.Nhanvien (
	Id INT PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Id_Manager INT NOT NULL,
	Gender NCHAR(10) NOT NULL,
	Address NVARCHAR(255) NOT NULL,
	Id_chinhanh INT NOT NULL,
	FOREIGN KEY (Id_Manager)
	REFERENCES dbo.Nhanvien (Id),
	FOREIGN KEY (Id_chinhanh)
	REFERENCES dbo.Chinhanh (Id)
);

CREATE TABLE dbo.Khachhang (
	Id INT PRIMARY KEY,
	Name NVARCHAR(255) NOT NULL,
	Password CHAR(50) NOT NULL,
	Phone CHAR(11) NOT NULL,
	Id_maytinh INT NOT NULL,
	Id_phongmay INT NOT NULL,
	CONSTRAINT khachhang_fk FOREIGN KEY (Id_maytinh,Id_phongmay) REFERENCES dbo.Maytinh (Id,Id_Phongmay)
);

CREATE TABLE dbo.Hoadon (
	Id INT PRIMARY KEY,
	Date DATETIME NOT NULL,
	Id_khachhang INT NOT NULL,
	Id_nhanvien INT NOT NULL,
	Time_use TIME NOT NULL,
	Fee INT NOT NULL,
	Extra_fee INT NOT NULL,
	Description CHAR(255) NOT NULL,
	Total INT NOT NULL,
	CONSTRAINT hoadon_fk_kh FOREIGN KEY (Id_khachhang) REFERENCES dbo.Khachhang (Id),
	CONSTRAINT hoadon_fk_nv	FOREIGN KEY (Id_nhanvien) REFERENCES dbo.Nhanvien(Id)
);

CREATE TABLE dbo.Thucan (
	Id INT PRIMARY KEY,
	Name NVARCHAR(255) NOT NULL,
	Price INT NOT NULL
);

CREATE TABLE dbo.Hoadon_thucan (
	Id INT PRIMARY KEY,
	Date DATETIME NOT NULL,
	Id_khachhang INT NOT NULL,
	Id_nhanvien INT NOT NULL,
	Total INT NOT NULL
	CONSTRAINT hoadon_thucan_fk_kh FOREIGN KEY (Id_khachhang) REFERENCES dbo.Khachhang(Id),
	CONSTRAINT hoadon_thucan_fk_nv FOREIGN KEY (Id_nhanvien) REFERENCES dbo.Nhanvien(Id),
);

CREATE TABLE dbo.Chitiet_hoadon (
	Id_thucan INT REFERENCES dbo.Thucan(Id) NOT NULL,
	Id_hoadon INT REFERENCES dbo.Hoadon_thucan (Id) NOT NULL,
	Count INT NOT NULL,
	Total INT NOT NULL,
	CONSTRAINT chitiet_hoadon_pk PRIMARY KEY (Id_thucan,Id_hoadon)
);
