# 15 Interview Questions

## Basic

- List all orders with customer name.

```sql
SELECT ORDERID, CUSTOMERNAME FROM ORDERS O 
JOIN CUSTOMER C ON O.CUSTOMERID = C.CUSTOMERID 
```

- Show total amount per order.

```sql
SELECT ORDERID, SUM(UNITPRICE*QUANTITY) 
FROM ORDERITEM
GROUP BY ORDERID
```

- Find customers that never placed an order.

```sql
SELECT C.CUSTOMERID, C.CUSTOMERNAME FROM CUSTOMER C
LEFT JOIN ORDERS O ON O.CUSTOMERID = C.CUSTOMERID
WHERE O.CUSTOMERID IS NULL
```

- Find products never sold.

```sql
SELECT P.PRODUCTID, P.PRODUCTNAME FROM PRODUCT P
LEFT JOIN ORDERITEM I ON I.PRODUCTID = P.PRODUCTID
WHERE I.PRODUCTID IS NULL
```

- Show inventory value (StockQty * Price) and total inventory value

```sql
SELECT I.STOCKQTY * P.PRICE AS INVENTORYVALUE
FROM INVENTORY I
JOIN PRODUCT P ON I.PRODUCTID = P.PRODUCTID

SELECT SUM(I.STOCKQTY * P.PRICE) AS INVENTORYVALUE
FROM INVENTORY I
JOIN PRODUCT P ON I.PRODUCTID = P.PRODUCTID
```

## Intermediate

- Top 3 customers by revenue.

```sql
SELECT TOP 3 C.CUSTOMERID, SUM(QUANTITY*UNITPRICE) AS REVENUE
FROM CUSTOMER C
JOIN ORDERS O ON O.CUSTOMERID = C.CUSTOMERID
JOIN ORDERITEM I ON I.ORDERID = O.ORDERID
GROUP BY C.CUSTOMERID
ORDER BY REVENUE DESC
```

- Revenue by category.

```sql
SELECT P.CATEGORY, SUM(O.UNITPRICE * O.QUANTITY)
FROM PRODUCT P
JOIN ORDERITEM O ON O.PRODUCTID = P.PRODUCTID
GROUP BY P.CATEGORY
```

- Average order value per customer.

```sql
WITH ORDERTOTALS AS
(
	SELECT 
		O.ORDERID,
		O.CUSTOMERID, 
		SUM(I.QUANTITY*I.UNITPRICE) AS ORDERVALUE
	FROM ORDERS O
	JOIN ORDERITEM I ON I.ORDERID = O.ORDERID
	GROUP BY O.ORDERID, O.CUSTOMERID
)
SELECT 
	C.CUSTOMERNAME,
	AVG(ORDERVALUE) AS AVG_ORDERVALUE
FROM CUSTOMER C
JOIN ORDERTOTALS OT ON OT.CUSTOMERID = C.CUSTOMERID
GROUP BY C.CUSTOMERNAME
```

- Month-over-month sales.

```sql

```

- Find products sold in more than 3 orders.

```sql

```

## Senior

- Find the best-selling product in each category.

```sql

```

- Rank customers by total revenue using DENSE_RANK.

```sql

```

- Find the first order for every customer.

```sql

```

- Show running total sales by date.

```sql

```

- Find customers responsible for 80% of total revenue (Pareto analysis).

```sql

```