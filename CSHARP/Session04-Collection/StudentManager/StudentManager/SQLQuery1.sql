-- Tạo cơ sở dữ liệu
CREATE DATABASE StudentManagement;
GO

-- Sử dụng cơ sở dữ liệu vừa tạo
USE StudentManagement;
GO

-- Tạo bảng Role
CREATE TABLE Role (
    id INT PRIMARY KEY IDENTITY(1,1),
    nameRole NVARCHAR(50) NOT NULL
);
GO

-- Tạo bảng Account
CREATE TABLE Account (
    id INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(50) NOT NULL UNIQUE,
    password NVARCHAR(100) NOT NULL,
    roleId INT NOT NULL,
    FOREIGN KEY (roleId) REFERENCES Role(id)
);
GO

-- Tạo bảng Student
CREATE TABLE Student (
    mssv NVARCHAR(20) PRIMARY KEY,
    fullname NVARCHAR(100) NOT NULL,
    dob DATE NOT NULL,
    major NVARCHAR(100) NOT NULL
);
GO

-- Thêm dữ liệu vào bảng Role (nếu chưa có)
INSERT INTO Role (nameRole) VALUES 
('Admin'),
('Teacher'),
('Student');
GO

-- Thêm 2 tài khoản Admin (roleId = 1)
INSERT INTO Account (username, password, roleId) VALUES
('admin1', 'admin123', 1),
('admin2', 'admin456', 1);
GO

-- Thêm 3 tài khoản Teacher (roleId = 2)
INSERT INTO Account (username, password, roleId) VALUES
('teacher1', 'teacher123', 2),
('teacher2', 'teacher456', 2),
('teacher3', 'teacher789', 2);
GO

-- Thêm 10 tài khoản Student (roleId = 3)
INSERT INTO Account (username, password, roleId) VALUES
('student1', 'student123', 3),
('student2', 'student456', 3),
('student3', 'student789', 3),
('student4', 'student101', 3),
('student5', 'student112', 3),
('student6', 'student131', 3),
('student7', 'student415', 3),
('student8', 'student161', 3),
('student9', 'student718', 3),
('student10', 'student192', 3);
GO

-- Thêm 10 sinh viên vào bảng Student
INSERT INTO Student (mssv, fullname, dob, major) VALUES
('SV001', 'Nguyễn Văn A', '2000-01-15', 'Công nghệ thông tin'),
('SV002', 'Trần Thị B', '2000-03-22', 'Kế toán'),
('SV003', 'Lê Văn C', '2001-05-10', 'Quản trị kinh doanh'),
('SV004', 'Phạm Thị D', '2000-07-30', 'Công nghệ thông tin'),
('SV005', 'Hoàng Văn E', '2001-02-14', 'Điện tử viễn thông'),
('SV006', 'Vũ Thị F', '2000-11-05', 'Ngôn ngữ Anh'),
('SV007', 'Đặng Văn G', '2001-04-18', 'Công nghệ thông tin'),
('SV008', 'Bùi Thị H', '2000-09-25', 'Quản trị khách sạn'),
('SV009', 'Mai Văn I', '2001-06-12', 'Kỹ thuật cơ khí'),
('SV010', 'Lý Thị K', '2000-12-03', 'Tài chính ngân hàng');
GO