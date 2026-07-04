-- Insert 10 Products
INSERT INTO Product (Name, Description, Price) VALUES
('Laptop',        'High performance laptop',       150000),
('Mouse',         'Wireless optical mouse',          2500),
('Keyboard',      'Mechanical keyboard RGB',         8000),
('Monitor',       '27 inch 4K display',            55000),
('Headset',       'Noise cancelling headset',       12000),
('Webcam',        'Full HD 1080p webcam',            9000),
('USB Hub',       '7-port USB 3.0 hub',             3500),
('SSD 1TB',       'NVMe solid state drive',        20000),
('Chair',         'Ergonomic office chair',         80000),
('Desk Lamp',     'LED adjustable desk lamp',        4500);

-- Insert 10 Inventory records (ProductId 1–10 match the inserted products)
INSERT INTO Inventory (ProductId, Quantity, Price) VALUES
(1,  15, 150000),
(2, 100,   2500),
(3,  50,   8000),
(4,  20,  55000),
(5,  30,  12000),
(6,  40,   9000),
(7,  75,   3500),
(8,  60,  20000),
(9,  10,  80000),
(10, 90,   4500);