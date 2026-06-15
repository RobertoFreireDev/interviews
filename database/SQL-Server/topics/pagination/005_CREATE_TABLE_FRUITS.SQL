-- =============================================
-- Author:      Passos, Roberto
-- Create Date: 08/29/2022
-- Description: Create Table FRUITS 
-- =============================================

DROP TABLE IF EXISTS FRUITS

CREATE TABLE FRUITS (
	Id INT PRIMARY KEY IDENTITY(1,1) , 
	FruitName VARCHAR(50) , 
	Price INT
)
GO

INSERT INTO FRUITS VALUES('Apple',20)
INSERT INTO FRUITS VALUES('Apricot',12)
INSERT INTO FRUITS VALUES('Banana',8)
INSERT INTO FRUITS VALUES('Cherry',11)
INSERT INTO FRUITS VALUES('Strawberry',26)
INSERT INTO FRUITS VALUES('Lemon',4)  
INSERT INTO FRUITS VALUES('Kiwi',14)  
INSERT INTO FRUITS VALUES('Coconut',34) 
INSERT INTO FRUITS VALUES('Orange',24)  
INSERT INTO FRUITS VALUES('Raspberry',13)
INSERT INTO FRUITS VALUES('Mango',9)
INSERT INTO FRUITS VALUES('Mandarin',19)
INSERT INTO FRUITS VALUES('Pineapple',22)
GO

SELECT * FROM FRUITS
ORDER BY FruitName

-- PAGINATION
DECLARE @PageNumber AS INT
DECLARE @RowsOfPage AS INT
SET @PageNumber=2
SET @RowsOfPage=4
SELECT * FROM FRUITS
ORDER BY FruitName 
OFFSET (@PageNumber-1)*@RowsOfPage ROWS
FETCH NEXT @RowsOfPage ROWS ONLY

-- Block by not commiting Transaction 1

BEGIN TRAN;

UPDATE FRUITS
SET FruitName = 'Apple - Transaction 1'
WHERE Id = 1;

-- second query

BEGIN TRAN;

UPDATE FRUITS
SET FruitName = 'Apple - Transaction 2'
WHERE Id = 1;

COMMIT;