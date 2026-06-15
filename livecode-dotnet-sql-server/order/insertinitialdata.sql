INSERT INTO [dbo].[Customer] ([Id], [Name]) VALUES
(1, 'Alice Smith'),
(2, 'Bob Jones'),
(3, 'Charlie Brown');


INSERT INTO [dbo].[Product] ([Id], [Sku], [Name], [Price]) VALUES
(1, 'PROD-LAP-001', 'Wireless Laptop', 120000),
(2, 'PROD-MOU-002', 'Ergonomic Mouse', 4500),
(3, 'PROD-KEY-003', 'Mechanical Keyboard', 9000);

delete from [dbo].[Inventory]
delete from [dbo].[Order]
delete from [dbo].[OrderItem]

INSERT INTO [dbo].[Inventory] ([Id], [ProductId], [Availability]) VALUES
(1, 1, 50),
(2, 2, 150),
(3, 2, 85);

Select * from [dbo].[Customer]
Select * from [dbo].[Product]
Select * from [dbo].[Inventory]
Select * from [dbo].[Order]
Select * from [dbo].[OrderItem]

