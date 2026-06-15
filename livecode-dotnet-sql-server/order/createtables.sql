CREATE TABLE [dbo].[Customer]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[Product]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Sku] NVARCHAR(15) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Price] INT NOT NULL
)

CREATE TABLE [dbo].[Inventory]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ProductId] INT NOT NULL, 
    [Availability] INT NOT NULL
    CONSTRAINT FK_Inventory_Product FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([Id])
)

CREATE TABLE [dbo].[Order]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [CustomerId] INT NOT NULL, 
    [TotalPrice] INT NOT NULL,
    CONSTRAINT FK_Order_Customer FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([Id])
)

CREATE TABLE [dbo].[OrderItem]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [OrderId] INT NOT NULL, 
    [Price] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [ProductId] INT NOT NULL,
    CONSTRAINT FK_OrderItem_Order FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([Id]),
    CONSTRAINT FK_OrderItem_Product FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([Id])
)