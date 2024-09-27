
CREATE DATABASE CC;
USE CC;
CREATE TABLE Vehicle (
  vehicleID INT PRIMARY KEY,
  make VARCHAR(50) NOT NULL,
  model VARCHAR(100) NOT NULL,
  year INT NOT NULL,
  dailyRate DECIMAL(10, 2) NOT NULL,
  available INT NOT NULL,
  passengerCapacity INT NOT NULL,
  engineCapacity INT NOT NULL
);

INSERT INTO Vehicle (vehicleID, make, model, year, dailyRate, available, passengerCapacity, engineCapacity)
VALUES
(1, 'Toyota', 'Camry', 2022, 50.00, 1, 4, 1450),
(2, 'Honda', 'Civic', 2023, 45.00, 1, 7, 1500),
(3, 'Ford', 'Focus', 2022, 48.00, 0, 4, 1400),
(4, 'Nissan', 'Altima', 2023, 52.00, 1, 7, 1200),
(5, 'Chevrolet', 'Malibu', 2022, 47.00, 1, 7, 1800),
(6, 'Hyundai', 'Sonata', 2023, 49.00, 0, 7, 1400),
(7, 'BMW', '3 Series', 2023, 60.00, 1, 7, 2499),
(8, 'Mercedes', 'C-Class', 2022, 58.00, 1, 8, 2599),
(9, 'Audi', 'A4', 2022, 58.00, 1, 8, 2599),
(10, 'Lexus', 'ES', 2023, 54.00, 1, 4, 2500);

SELECT * FROM Vehicle;

CREATE TABLE Customer (
  customerID INT PRIMARY KEY IDENTITY (1,1) ,
  firstName VARCHAR(50) NOT NULL,
  lastName VARCHAR(50) NOT NULL,
  email VARCHAR(100) UNIQUE NOT NULL,
  phoneNumber VARCHAR(20) NOT NULL
);

INSERT INTO Customer (firstName, lastName, email, phoneNumber)
VALUES
('John', 'Doe', 'johndoe@example.com', '555-555-5555'),
('Jane', 'Smith', 'janesmith@example.com', '555-123-456'),
('Robert', 'Johnson', 'johnson@example.com', '555-123-4567'),
('Sarah', 'Brown', 'sarah@example.com', '555-937-2365'),
('David', 'Lee', 'david@example.com', '555-287-3872'),
('Laura', 'Hall', 'laura@example.com', '555-983-2187'),
('Michael', 'Davis', 'michael@example.com', '555-358-1398'),
('Emma', 'Wilson', 'emma@example.com', '555-391-9378'),
('William', 'Taylor', 'william@example.com', '555-563-3987'),
('Olivia', 'Adams', 'olivia@example.com', '555-389-9138');

SELECT * FROM Customer;

CREATE TABLE Lease (
  leaseID INT PRIMARY KEY IDENTITY(1,1),
  vehicleID INT NOT NULL,
  customerID INT NOT NULL,
  startDate DATE NOT NULL,
  endDate DATE NOT NULL,
  type VARCHAR(10) CHECK(type IN ('Daily', 'Monthly')) NOT NULL,

  CONSTRAINT FK_Vehicle FOREIGN KEY (vehicleID) REFERENCES Vehicle(vehicleID),
  CONSTRAINT FK_Customer FOREIGN KEY (customerID) REFERENCES Customer(customerID)
);

INSERT INTO Lease (vehicleID, customerID, startDate, endDate, type)
VALUES
(1, 1, '2024-01-01', '2024-01-05', 'Daily'),
(2, 2, '2024-02-01', '2024-03-01', 'Monthly'),
(3, 3, '2024-03-15', '2024-03-20', 'Daily'),
(4, 4, '2024-04-01', '2024-05-01', 'Monthly'),
(5, 5, '2024-05-10', '2024-05-15', 'Daily'),
(4, 3, '2024-06-01', '2024-07-01', 'Monthly'),
(7, 7, '2024-07-15', '2024-07-20', 'Daily'),
(8, 8, '2024-08-01', '2024-09-01', 'Monthly'),
(3, 3, '2024-09-10', '2024-09-15', 'Daily'),
(10, 10, '2024-10-01', '2024-11-01', 'Monthly');

SELECT * FROM Lease;

CREATE TABLE Payment (
paymentID INT PRIMARY KEY IDENTITY(1,1),
leaseID INT NOT NULL,
paymentDate DATE NOT NULL,
amount DECIMAL(10, 2) NOT NULL,

CONSTRAINT FK_Lease FOREIGN KEY (leaseID) REFERENCES Lease(leaseID)
);

INSERT INTO Payment (leaseID, paymentDate, amount)
VALUES
(1, '2024-01-05', 200.00),
(2, '2024-03-01', 1000.00),
(3, '2024-03-20', 75.00),
(4, '2024-05-01', 900.00),
(5, '2024-05-15', 60.00),
(6, '2024-07-01', 1200.00),
(7, '2024-07-20', 40.00),
(8, '2024-09-01', 1100.00),
(9, '2024-09-15', 80.00),
(10, '2024-11-01', 1500.00);

SELECT * FROM Payment;


--QUERIES
--1. Update the daily rate for a Mercedes car to 68.
UPDATE Vehicle
SET dailyRate = '68.00'
WHERE vehicleID = '8' ;
SELECT * FROM Vehicle;

--2. Delete a specific customer and all associated leases and payments.
SELECT * FROM Customer;

DELETE FROM Payment
WHERE leaseID = 10;
DELETE FROM Lease
WHERE leaseID = 10 AND customerID = 10;
DELETE FROM Customer
WHERE customerID = 10;
SELECT * FROM Customer;

--3. Rename the "paymentDate" column in the Payment table to "transactionDate". 
EXEC sp_rename 'Payment.paymentDate', 'transactionDate', 'COLUMN';
SELECT * FROM Payment;

--4. Find a specific customer by email. 
SELECT * 
FROM Customer 
WHERE email = 'emma@example.com';

--5. Get active leases for a specific customer. 
SELECT * 
FROM Lease 
WHERE customerID = 3
AND endDate >= '2024-03-10' 
AND startDate <= '2024-03-31';

--6.Find all payments made by a customer with a specific phone number. 
SELECT p.*
FROM Payment p
JOIN Lease l ON p.leaseID = l.leaseID
JOIN Customer c ON l.customerID = c.customerID
WHERE c.phoneNumber = '555-287-3872';

--7. Calculate the average daily rate of all available cars. 
SELECT AVG(dailyRate) AS averageDailyRate
FROM Vehicle
WHERE available = '1'

--8. Find the car with the highest daily rate. 
SELECT *
FROM Vehicle
WHERE dailyRate = (SELECT MAX(dailyRate) FROM Vehicle);

--9. Retrieve all cars leased by a specific customer. 
SELECT v.* 
FROM Vehicle v 
JOIN Lease l ON v.vehicleID = l.vehicleID 
JOIN Customer c ON l.customerID = c.customerID 
WHERE c.customerID = '2';

--10. Find the details of the most recent lease. 
SELECT *
FROM Lease
WHERE startDate = (SELECT MAX(startDate) FROM Lease);

--11. List all payments made in the year 2024.
SELECT *
FROM Payment
WHERE transactionDate >= '2024-01-01'
AND transactionDate < '2025-01-01';    --red line showing  bcoz we changed the name of paymentDate to transactionDate in Q3

--12. Retrieve customers who have not made any payments.
SELECT c.* 
FROM Customer c
JOIN Payment p ON c.customerID = p.paymentID
WHERE p.paymentID IS NULL;
-- all customers have made payment is empty output is shown

--13. Retrieve Car Details and Their Total Payments. 
SELECT v.vehicleID, v.make, v.model, v.year, SUM(p.amount) AS TotalPayment
FROM Vehicle v
LEFT JOIN Lease l ON v.vehicleID = l.vehicleID
LEFT JOIN Payment p ON l.leaseID = p.leaseID
GROUP BY v.vehicleID, v.make, v.model, v.year
ORDER BY TotalPayment DESC;

--14. Calculate Total Payments for Each Customer. 
SELECT c.customerID, c.firstName, SUM(p.amount) AS TotalPayment
FROM Customer c
LEFT JOIN Lease l ON c.customerID = l.customerID
LEFT JOIN Payment p ON l.leaseID = p.leaseID
GROUP BY c.customerID, c.firstName
ORDER BY TotalPayment DESC;

--15. List Car Details for Each Lease. 
SELECT l.leaseID, v.make, v.model, v.year, v.vehicleID
FROM Lease l
JOIN Vehicle v ON l.vehicleID = v.vehicleID
GROUP BY l.leaseID, v.make, v.model, v.year, v.vehicleID;

--16. Retrieve Details of Active Leases with Customer and Car Information. 
SELECT 
  L.leaseID, 
  C.firstName AS customerName, 
  C.email AS customerEmail, 
  V.make , 
  V.model , 
  V.year , 
  L.startDate, 
  L.endDate

FROM Lease L
JOIN Customer C ON L.customerID = C.customerID
JOIN Vehicle V ON L.vehicleID = V.vehicleID
WHERE L.endDate > GETDATE()
ORDER BY 
L.startDate DESC;

--17. Find the Customer Who Has Spent the Most on Leases. 
SELECT c.customerID,  c.firstName, c.lastName,  SUM(p.Amount) AS TotalSpent
FROM Customer c
JOIN  Lease l ON c.customerID = l.customerID
JOIN Payment p ON l.leaseID = p.leaseID
GROUP BY c.customerID, c.firstName, c.lastName
ORDER BY TotalSpent DESC;

--18. List All Cars with Their Current Lease Information. 
SELECT v.vehicleID, v.make, v.model, v.year, l.leaseID, l.customerID, l.startDate, l.endDate
FROM Vehicle v
LEFT JOIN Lease l ON v.vehicleID = l.vehicleID
WHERE l.endDate >= GETDATE();