USE [master];
GO

-- Tạo CSDL
CREATE DATABASE [FUMiniHotelManagement];
GO

USE [FUMiniHotelManagement];
GO

-- Bảng RoomType
CREATE TABLE [dbo].[RoomType] (
    [RoomTypeID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [RoomTypeName] NVARCHAR(50) NOT NULL,
    [TypeDescription] NVARCHAR(250),
    [TypeNote] NVARCHAR(250)
);
GO

-- Bảng Customer
CREATE TABLE [dbo].[Customer] (
    [CustomerID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [CustomerFullName] NVARCHAR(50),
    [Telephone] NVARCHAR(12),
    [EmailAddress] NVARCHAR(50) NOT NULL UNIQUE,
    [CustomerBirthday] DATE,
    [CustomerStatus] TINYINT,
    [Password] NVARCHAR(50)
);
GO

-- Bảng BookingReservation
CREATE TABLE [dbo].[BookingReservation] (
    [BookingReservationID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [BookingDate] DATE,
    [TotalPrice] MONEY,
    [CustomerID] INT NOT NULL,
    [BookingStatus] TINYINT,
    CONSTRAINT [FK_BookingReservation_Customer] FOREIGN KEY ([CustomerID])
        REFERENCES [dbo].[Customer]([CustomerID])
        ON UPDATE CASCADE ON DELETE CASCADE
);
GO

-- Bảng RoomInformation
CREATE TABLE [dbo].[RoomInformation] (
    [RoomID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [RoomNumber] NVARCHAR(50) NOT NULL,
    [RoomDetailDescription] NVARCHAR(220),
    [RoomMaxCapacity] INT,
    [RoomTypeID] INT NOT NULL,
    [RoomStatus] TINYINT,
    [RoomPricePerDay] MONEY,
    CONSTRAINT [FK_RoomInformation_RoomType] FOREIGN KEY ([RoomTypeID])
        REFERENCES [dbo].[RoomType]([RoomTypeID])
        ON UPDATE CASCADE ON DELETE CASCADE
);
GO

-- Bảng BookingDetail
CREATE TABLE [dbo].[BookingDetail] (
    [BookingReservationID] INT NOT NULL,
    [RoomID] INT NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [ActualPrice] MONEY,
    CONSTRAINT [PK_BookingDetail] PRIMARY KEY ([BookingReservationID], [RoomID]),
    CONSTRAINT [FK_BookingDetail_BookingReservation] FOREIGN KEY ([BookingReservationID])
        REFERENCES [dbo].[BookingReservation]([BookingReservationID])
        ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT [FK_BookingDetail_RoomInformation] FOREIGN KEY ([RoomID])
        REFERENCES [dbo].[RoomInformation]([RoomID])
        ON UPDATE CASCADE ON DELETE CASCADE
);
GO

-- Dữ liệu mẫu
-- RoomType
SET IDENTITY_INSERT [dbo].[RoomType] ON;
INSERT [dbo].[RoomType] ([RoomTypeID], [RoomTypeName], [TypeDescription], [TypeNote]) VALUES
(1, N'Standard room', N'This is typically the most affordable option and provides basic amenities such as a bed, dresser, and TV.', N'N/A'),
(2, N'Suite', N'Suites usually offer more space and amenities than standard rooms, such as a separate living area, kitchenette, and multiple bathrooms.', N'N/A'),
(3, N'Deluxe room', N'Deluxe rooms offer additional features such as a balcony or sea view, upgraded bedding, and improved décor.', N'N/A'),
(4, N'Executive room', N'Executive rooms are designed for business travelers and offer perks such as free breakfast, evening drink, and high-speed internet.', N'N/A'),
(5, N'Family Room', N'A room specifically designed to accommodate families, often with multiple beds and additional space for children.', N'N/A'),
(6, N'Connecting Room', N'Two or more rooms with a connecting door, providing flexibility for larger groups or families traveling together.', N'N/A'),
(7, N'Penthouse Suite', N'An extravagant, top-floor suite with exceptional views and exclusive amenities, typically chosen for special occasions or VIP guests.', N'N/A'),
(8, N'Bungalow', N'A standalone cottage-style accommodation, providing privacy and a sense of seclusion often within a resort setting', N'N/A');
SET IDENTITY_INSERT [dbo].[RoomType] OFF;
GO

-- Customer
SET IDENTITY_INSERT [dbo].[Customer] ON;
INSERT [dbo].[Customer] ([CustomerID], [CustomerFullName], [Telephone], [EmailAddress], [CustomerBirthday], [CustomerStatus], [Password]) VALUES
(3, N'William Shakespeare', N'0903939393', N'WilliamShakespeare@FUMiniHotel.org', '1990-02-02', 1, N'123@'),
(5, N'Elizabeth Taylor', N'0903939377', N'ElizabethTaylor@FUMiniHotel.org', '1991-03-03', 1, N'144@'),
(8, N'James Cameron', N'0903946582', N'JamesCameron@FUMiniHotel.org', '1992-11-10', 1, N'443@'),
(9, N'Charles Dickens', N'0903955633', N'CharlesDickens@FUMiniHotel.org', '1991-12-05', 1, N'563@'),
(10, N'George Orwell', N'0913933493', N'GeorgeOrwell@FUMiniHotel.org', '1993-12-24', 1, N'177@'),
(11, N'Victoria Beckham', N'0983246773', N'VictoriaBeckham@FUMiniHotel.org', '1990-09-09', 1, N'654@');
SET IDENTITY_INSERT [dbo].[Customer] OFF;
GO

-- RoomInformation
SET IDENTITY_INSERT [dbo].[RoomInformation] ON;
INSERT [dbo].[RoomInformation] ([RoomID], [RoomNumber], [RoomDetailDescription], [RoomMaxCapacity], [RoomTypeID], [RoomStatus], [RoomPricePerDay]) VALUES
(1, N'2364', N'A basic room with essential amenities, suitable for individual travelers or couples.', 3, 1, 1, 149.0000),
(2, N'3345', N'Deluxe rooms offer additional features such as a balcony or sea view, upgraded bedding, and improved décor.', 5, 3, 1, 299.0000),
(3, N'4432', N'A luxurious and spacious room with separate living and sleeping areas, ideal for guests seeking extra comfort and space.', 4, 2, 1, 199.0000),
(5, N'3342', N'Foor 3, Window in the North West ', 5, 5, 1, 219.0000),
(7, N'4434', N'Floor 4, main window in the South ', 4, 1, 1, 179.0000);
SET IDENTITY_INSERT [dbo].[RoomInformation] OFF;
GO

-- BookingReservation
SET IDENTITY_INSERT [dbo].[BookingReservation] ON;
INSERT [dbo].[BookingReservation] ([BookingReservationID], [BookingDate], [TotalPrice], [CustomerID], [BookingStatus]) VALUES
(1, '2023-12-20', 378.0000, 3, 1),
(2, '2023-12-21', 1493.0000, 3, 1);
SET IDENTITY_INSERT [dbo].[BookingReservation] OFF;
GO

-- BookingDetail
INSERT [dbo].[BookingDetail] ([BookingReservationID], [RoomID], [StartDate], [EndDate], [ActualPrice]) VALUES
(1, 3, '2024-01-01', '2024-01-02', 199.0000),
(1, 7, '2024-01-01', '2024-01-02', 179.0000),
(2, 3, '2024-01-05', '2024-01-06', 199.0000),
(2, 5, '2024-01-05', '2024-01-09', 219.0000);
GO

-- Đặt chế độ Read-Write trở lại
USE [master];
GO
ALTER DATABASE [FUMiniHotelManagement] SET READ_WRITE;
GO
