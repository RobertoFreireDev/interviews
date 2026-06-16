INSERT INTO [dbo].[Customer] ([Name]) VALUES
('Alice Smith'),
('Bob Jones'),
('Charlie Brown');


INSERT INTO [dbo].[Product] ([Sku], [Name], [Price]) VALUES
('PROD-LAP-001', 'Wireless Laptop', 120000),
('PROD-MOU-002', 'Ergonomic Mouse', 4500),
('PROD-KEY-003', 'Mechanical Keyboard', 9000);

--delete from [dbo].[Inventory]
--delete from [dbo].[Order]
--delete from [dbo].[OrderItem]

INSERT INTO [dbo].[Inventory] ([ProductId], [Availability]) VALUES
(1, 50),
(2, 150),
(2, 85);

Select * from [dbo].[Customer]
Select * from [dbo].[Product]
Select * from [dbo].[Inventory]
Select * from [dbo].[Order]
Select * from [dbo].[OrderItem]

