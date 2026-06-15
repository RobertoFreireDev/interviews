CREATE TABLE Customer
(
    CustomerId INT PRIMARY KEY,
    CustomerName NVARCHAR(100) NOT NULL,
    City NVARCHAR(50) NOT NULL,
    RegistrationDate DATE NOT NULL
);

CREATE TABLE Product
(
    ProductId INT PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders
(
    OrderId INT PRIMARY KEY,
    CustomerId INT NOT NULL,
    OrderDate DATE NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
);

CREATE TABLE OrderItem
(
    OrderItemId INT PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
);

CREATE TABLE Inventory
(
    ProductId INT PRIMARY KEY,
    StockQty INT NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
);