-- =============================================
-- Our task today is to create a report (using SQL Server PIVOT operator) 
-- where each city will be in a separate row, and where we’ll count the 
-- number of all call outcomes related to each city. Therefore, all 
-- outcomes (all values from the dictionary) shall be columns in our 
-- report.
-- https://www.sqlshack.com/learn-sql-sql-server-pivot-tables/
-- =============================================


-- SEE ALL DATA
SELECT * 
FROM CITY
GO

SELECT * 
FROM CUSTOMER
GO

SELECT * 
FROM CALL_OUTCOME
GO

SELECT * 
FROM CALLS
GO


-- SEE ALL POSSIBILITIES OF CITIES AND CALL OUTCOMES
SELECT 
  C.ID AS CITY_ID,
  C.CITY_NAME AS CITY_NAME,
  CO.ID AS CALL_OUTCOME_ID,
  CO.OUTCOME_TEXT AS OUTCOME_TEXT
FROM CITY C 
CROSS JOIN CALL_OUTCOME CO
ORDER BY
  C.ID ASC,
  CO.ID ASC;


-- SEE ALL CALLS AND ITS CITIES AND CALL OUTCOMES
SELECT 
	C.ID AS CALL_ID,
	CI.ID AS CITY_ID,
	CI.CITY_NAME AS CITY_NAME,
	CO.ID AS CALL_OUTCOME_ID,
	CO.OUTCOME_TEXT AS OUTCOME_TEXT
FROM CALLS C
JOIN CALL_OUTCOME CO ON C.CALL_OUTCOME_ID = CO.ID
JOIN CUSTOMER CU ON C.CUSTOMER_ID = CU.ID
JOIN CITY CI ON CU.CITY_ID = CI.ID;


-- PIVOT
SELECT * FROM   
(
	SELECT
	 RC.CITY_NAME,
	 RD.OUTCOME_TEXT
	FROM
	(
		SELECT 
		  C.ID AS CITY_ID,
		  C.CITY_NAME AS CITY_NAME,
		  CO.ID AS CALL_OUTCOME_ID
		FROM CALL_OUTCOME CO
		CROSS JOIN CITY C 
	) RC
	LEFT JOIN
	(
		SELECT 
			CI.ID AS CITY_ID,
			CO.ID AS CALL_OUTCOME_ID,
			CO.OUTCOME_TEXT AS OUTCOME_TEXT
		FROM CALLS C
			JOIN CALL_OUTCOME CO ON C.CALL_OUTCOME_ID = CO.ID
			JOIN CUSTOMER CU ON C.CUSTOMER_ID = CU.ID
			JOIN CITY CI ON CU.CITY_ID = CI.ID
	) RD ON RC.CITY_ID = RD.CITY_ID AND RC.CALL_OUTCOME_ID = RD.CALL_OUTCOME_ID
) REPORT_DATA
PIVOT(
	COUNT(OUTCOME_TEXT)
	FOR OUTCOME_TEXT IN (
		[CALL STARTED], 
        [FINISHED SUCCESFULLY], 
        [FINISHED UNSUCCESFULLY])
) AS PIVOT_TABLE

-- Dynamic SQL Server PIVOT TABLE
DECLARE 
    @columns  NVARCHAR(MAX) = '', 
    @query    NVARCHAR(MAX) = '';
 
-- get all column names for the table we need for pivot
SELECT 
  @columns += QUOTENAME(TRIM(co.outcome_text)) + ','
FROM 
  call_outcome co
ORDER BY 
  co.outcome_text;
 
-- remove "," from the end of the string
SET @columns = LEFT(@columns, LEN(@columns) - 1);
 
-- dynamic SQL query
SET @query ='
SELECT * FROM   
(
	SELECT
	 RC.CITY_NAME,
	 RD.OUTCOME_TEXT
	FROM
	(
		SELECT 
		  C.ID AS CITY_ID,
		  C.CITY_NAME AS CITY_NAME,
		  CO.ID AS CALL_OUTCOME_ID
		FROM CALL_OUTCOME CO
		CROSS JOIN CITY C 
	) RC
	LEFT JOIN
	(
		SELECT 
			CI.ID AS CITY_ID,
			CO.ID AS CALL_OUTCOME_ID,
			CO.OUTCOME_TEXT AS OUTCOME_TEXT
		FROM CALLS C
			JOIN CALL_OUTCOME CO ON C.CALL_OUTCOME_ID = CO.ID
			JOIN CUSTOMER CU ON C.CUSTOMER_ID = CU.ID
			JOIN CITY CI ON CU.CITY_ID = CI.ID
	) RD ON RC.CITY_ID = RD.CITY_ID AND RC.CALL_OUTCOME_ID = RD.CALL_OUTCOME_ID
) REPORT_DATA
PIVOT(
	COUNT(OUTCOME_TEXT)
	FOR outcome_text IN ('+ @columns +')
) AS PIVOT_TABLE';
 
-- execute dynamic query
EXECUTE sp_executesql @query;