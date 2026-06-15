-- =============================================
-- Author:      Passos, Roberto
-- Create Date: 10/19/2022
-- Description: Create database ECOMMERCE and table ORDERS
-- =============================================

-- =============================================
-- Author:      Passos, Roberto
-- Create Date: 10/19/2022
-- Description: Create database ECOMMERCE and table ORDERS
-- =============================================

Create database ECOMMERCE
go
use ECOMMERCE
go

DROP TABLE IF EXISTS ORDERS

CREATE TABLE ORDERS (
	ORDERID INT,
	ORDERDATE DATE,
	CUSTOMERNAME VARCHAR(100),
	CUSTOMERCITY VARCHAR(100),
	ORDERAMOUNT MONEY
)
GO

INSERT INTO ORDERS VALUES(216090, CAST(N'1826-12-19' AS Date), N'Edward', N'Phoenix', 4713.89)
INSERT INTO ORDERS VALUES(508220, CAST(N'1826-12-09' AS Date), N'Aria', N'San Francisco', 9832.72)
INSERT INTO ORDERS VALUES(271510, CAST(N'1902-09-03' AS Date), N'Lawrence', N'Chicago', 7199.61)
INSERT INTO ORDERS VALUES(517050, CAST(N'1873-07-05' AS Date), N'Roland', N'Austin', 936.12)
INSERT INTO ORDERS VALUES(834677, CAST(N'1932-09-29' AS Date), N'Stella', N'San Francisco', 2471.47)
INSERT INTO ORDERS VALUES(339137, CAST(N'2019-12-26' AS Date), N'Salvador', N'Columbus', 4275.76)
INSERT INTO ORDERS VALUES(830492, CAST(N'1801-06-05' AS Date), N'Ernest', N'Houston', 3858.43)
INSERT INTO ORDERS VALUES(126979, CAST(N'1885-05-03' AS Date), N'Nicholas', N'San Jose', 8624.99)
INSERT INTO ORDERS VALUES(590451, CAST(N'2012-04-20' AS Date), N'Ray', N'New York', 6377.95) 
INSERT INTO ORDERS VALUES(173941, CAST(N'1808-12-16' AS Date), N'Aaliyah', N'Columbus', 5308.58) 
INSERT INTO ORDERS VALUES(648122, CAST(N'1942-02-24' AS Date), N'Gilbert', N'Columbus', 6427.80) 
INSERT INTO ORDERS VALUES(547728, CAST(N'1854-01-20' AS Date), N'Jorge', N'Austin', 2326.46) 
INSERT INTO ORDERS VALUES(76596, CAST(N'1982-05-27' AS Date), N'Marvin', N'Chicago', 7577.90) 
INSERT INTO ORDERS VALUES(306085, CAST(N'1905-06-26' AS Date), N'Alex', N'Chicago', 6847.66)
INSERT INTO ORDERS VALUES(764581, CAST(N'1790-10-05' AS Date), N'Jerome', N'Chicago', 1843.83) 
GO

SELECT * 
FROM ORDERS
GO