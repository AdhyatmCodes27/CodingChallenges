
CREATE DATABASE Car
USE Car
CREATE TABLE Vehicle (
  vehicleID INT PRIMARY KEY,
  make VARCHAR(50) NOT NULL,
  model VARCHAR(100) NOT NULL,
  year INT NOT NULL,
  dailyRate DECIMAL(10, 2) NOT NULL,
  status VARCHAR(15) CHECK(status IN ('available', 'notAvailable')) DEFAULT 'available',
  passengerCapacity INT NOT NULL,
  engineCapacity DECIMAL(5, 2) NOT NULL
);

INSERT INTO Vehicle (vehicleID, make, model, year, dailyRate, status, passengerCapacity, engineCapacity)
VALUES
(1, 'Toyota', 'Camry', 2020, 40.00, 'available', 5, 2.5),
(2, 'Honda', 'Civic', 2019, 35.00, 'available', 5, 1.8),
(3, 'Ford', 'Mustang', 2022, 60.00, 'notAvailable', 4, 5.0),
(4, 'Nissan', 'Altima', 2018, 30.00, 'available', 5, 2.5),
(5, 'Volkswagen', 'Golf', 2021, 45.00, 'available', 5, 1.4),
(6, 'BMW', '328i', 2022, 80.00, 'notAvailable', 5, 2.0),
(7, 'Mercedes-Benz', 'C-Class', 2020, 70.00, 'available', 5, 2.5),
(8, 'Hyundai', 'Elantra', 2019, 25.00, 'available', 5, 2.0),
(9, 'Kia', 'Optima', 2021, 38.00, 'available', 5, 2.4),
(10, 'Audi', 'A4', 2022, 75.00, 'notAvailable', 5, 2.0);
USE CAR;
SELECT * From Vehicle;

CREATE TABLE Customer (
  customerID INT PRIMARY KEY ,
  firstName VARCHAR(50) NOT NULL,
  lastName VARCHAR(50) NOT NULL,
  email VARCHAR(100) UNIQUE NOT NULL,
  phoneNumber VARCHAR(20) NOT NULL
);

INSERT INTO Customer (customerID, firstName, lastName, email, phoneNumber)
VALUES

(1, 'Rahul', 'Sharma', 'rahul.sharma@gmail.com', '9812345678'),
(2, 'Priya', 'Jain', 'priya.jain@yahoo.com', '9998887777'),
(3, 'Rajesh', 'Kumar', 'rajesh.kumar@hotmail.com', '7896543210'),
(4, 'Sonia', 'Gupta', 'sonia.gupta@outlook.com', '7564932189'),
(5, 'Vikram', 'Singh', 'vikram.singh@gmail.com', '9638527410'),
(6, 'Nalini', 'Rao', 'nalini.rao@yahoo.com', '8976543210'),
(7, 'Amit', 'Patel', 'amit.patel@hotmail.com', '6543210987'),
(8, 'Rita', 'Shah', 'rita.shah@outlook.com', '5432109876'),
(9, 'Sandeep', 'Joshi', 'sandeep.joshi@gmail.com', '9876543210'),
(10, 'Deepika', 'Chopra', 'deepika.chopra@yahoo.com', '7418529632');

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
(6, 6, '2024-06-01', '2024-07-01', 'Monthly'),
(7, 7, '2024-07-15', '2024-07-20', 'Daily'),
(8, 8, '2024-08-01', '2024-09-01', 'Monthly'),
(9, 9, '2024-09-10', '2024-09-15', 'Daily'),
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
(2, '2024-03-01', 500.00),
(3, '2024-03-20', 250.00),
(4, '2024-05-01', 600.00),
(5, '2024-05-15', 300.00),
(6, '2024-07-01', 700.00),
(7, '2024-07-20', 350.00),
(8, '2024-09-01', 800.00),
(9, '2024-09-15', 400.00),
(10, '2024-11-01', 900.00);

SELECT * FROM Payment;