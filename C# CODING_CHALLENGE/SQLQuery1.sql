CREATE DATABASE OMS

USE OMS 

CREATE TABLE Products (
    productId INT PRIMARY KEY,
    productName VARCHAR(255) NOT NULL,
    description VARCHAR(255),
    price DECIMAL(10, 2) NOT NULL,
    quantityInStock INT NOT NULL,
    type VARCHAR(50) CHECK (type IN ('Electronics', 'Clothing'))
);

INSERT INTO Products (productId, productName, description, price, quantityInStock, type)
VALUES 
(1, 'Smartphone', 'Latest model smartphone with 6GB RAM', 499.99, 50, 'Electronics'),
(2, 'Laptop', '15-inch display laptop with 256GB SSD', 899.99, 30, 'Electronics'),
(3, 'T-shirt', '100% cotton, unisex T-shirt', 19.99, 100, 'Clothing'),
(4, 'Jeans', 'Slim-fit blue jeans', 49.99, 40, 'Clothing'),
(5, 'Smartwatch', 'Water-resistant smartwatch with fitness tracking', 199.99, 20, 'Electronics');

SELECT * FROM Products;


CREATE TABLE Users (
    userId INT PRIMARY KEY,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    role VARCHAR(50) CHECK (role IN ('Admin', 'User'))
);

INSERT INTO Users (userId, username, password, role)
VALUES
(1, 'john_doe', 'password123', 'User'),
(2, 'admin1', 'adminPass', 'Admin'),
(3, 'jane_smith', 'janeSecure', 'User'),
(4, 'superadmin', 'superSecure', 'Admin'),
(5, 'user123', 'userPass', 'User');

SELECT * FROM Users;


CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1), 
    UserId INT NOT NULL,                    
    OrderDate DATETIME NOT NULL,           
    FOREIGN KEY (UserId) REFERENCES Users(userId) -- Reference to Users table
);

-- Assuming UserId 1 and 2 already exist in the Users table
INSERT INTO Orders (UserId, OrderDate)
VALUES 
    (1, GETDATE()), 
    (2, GETDATE()),  
    (1, GETDATE()),  
    (2, GETDATE()),  
    (1, GETDATE()); 

SELECT * FROM Orders;

