create database PRN212_DatabaseFirst
use PRN212_DatabaseFirst
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Price DECIMAL(18, 2),
    Quantity INT
);
INSERT INTO Products (Name, Price, Quantity) VALUES
('Laptop', 1200.99, 10),
('Smartphone', 799.49, 20),
('Tablet', 499.99, 15),
('Monitor', 199.99, 30),
('Keyboard', 49.99, 50),
('Mouse', 19.99, 100),
('Printer', 150.00, 8),
('External Hard Drive', 89.99, 25),
('Webcam', 39.99, 40),
('Speaker', 59.99, 35);
SELECT * FROM Products
