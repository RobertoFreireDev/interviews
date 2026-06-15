# SQL-Server

## Next Steps

- Complete lock topic

## Set up project

- docker-compose up in /docker folder
- run scripts in /scripts folder
- Use SSMS. ServerName : localhost. User : sa. Password : AS#G6f34G1162

## Project

<details>
<summary style="font-size:14px">ACID</summary>
<p>

Atomicity – requires that a transaction that involves two or more discrete parts of information must commit all parts or none.

Consistency – requires that a transaction must create a valid state of new data, or it must roll back all data to the state that existed before the transaction was executed.

Isolation – requires that a transaction that is still running and did not commit all data yet, must stay isolated from all other transactions.

Durability – requires that committed data must be stored using method that will preserve all data in correct state and available to a user, even in case of a failure.

</p></details>

<details>
<summary style="font-size:14px">Locking</summary>
<p>

```sql
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
```

Explain deadlock and how to solve it

https://www.sqlshack.com/how-to-resolve-deadlocks-in-sql-server/

</p></details>

<details>
<summary style="font-size:14px">Pagination</summary>
<p>

```sql
DECLARE @PageNumber AS INT
DECLARE @RowsOfPage AS INT
SET @PageNumber=2
SET @RowsOfPage=4
SELECT * FROM FRUITS
ORDER BY FruitName 
OFFSET (@PageNumber-1)*@RowsOfPage ROWS
FETCH NEXT @RowsOfPage ROWS ONLY
```

</p></details>

<details>
<summary style="font-size:14px">Indexes</summary>
<p>

#### Clustered Indexes

When you create a table with a primary key, SQL Server automatically creates a corresponding clustered index. Each table has only one clustered index because data rows can be only sorted in one order.

#### Non-clustered indexes

A nonclustered index is a data structure that improves the speed of data retrieval from tables. Unlike a clustered index, a nonclustered index sorts and stores data separately from the data rows in the table. It is a copy of selected columns of data from a table with the links to the associated table.

A table may have one or more nonclustered indexes and each non-clustered index may include one or more columns of the table.

A nonclustered index, when used properly, can greatly improve the performance of queries. However, the benefits of nonclustered indexes come at costs: 
- First, it takes additional storage to store the copy of data of the index key columns.
- Second, when you insert, update, or delete rows from the table, SQL Server needs to update the associated non-clustered index.

##### Filtered index

A filtered index is a nonclustered index with a predicate that allows you to specify which rows should be added to the index.

Some usages: not deleted rows or not null value.

##### Indexes on Computed Columns

Simulate function-based indexes in SQL Server using indexes on computed columns.

#### Unique index

- A unique index ensures the index key columns do not contain any duplicate values.
- A unique index can be clustered or non-clustered.
- A unique index may consist of one or many columns. If a unique index has one column, the values in this column will be unique. In case the unique index has multiple columns, the combination of values in these columns is unique.
- Any attempt to insert or update data into the unique index key columns that causes the duplicate will result in an error.
- If you create a unique index on a nullable column, you can only have only one NULL value in this column.
- When you create a unique constraint, behind the scene, SQL Server creates a unique index associated with this constraint.

</p></details>

# References:

https://www.sqlservertutorial.net/

https://www.sqlshack.com/pagination-in-sql-server/

https://www.sqlshack.com/locking-sql-server/

https://www.sqlservertutorial.net/sql-server-administration/sql-server-blocking/


