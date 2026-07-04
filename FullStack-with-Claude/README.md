# Using Claude Code

How this keeps context small:

- Each task file references only the context files it needs and the exact directories it touches. Claude never loads the whole codebase.
- active/ holds exactly one task — there's no ambiguity about what's being worked on.
- Domain facts live in context/ once; task files link to them instead of repeating them.

Workflow:

- /new-task to create a new task given a context
- /start-task 001 — moves to active, confirms plan
- /task 001 — executes against the checklist
- Done → file auto-moves to done/

# Project

## Run

-  cd .\inventory\
    - npm install --force
    - npm run start  
    - http://localhost:4200/

- cd .\products\
    - npm install --force
    - npm run dev
    - http://localhost:5173/

## API

https://localhost:7296/swagger/index.html

## Overview

This project is a simple inventory management system composed of:

- React Frontend → Product CRUD management
- Angular Frontend → Inventory CRUD management
- .NET Web API → Backend services
- SQL Server Database → Data storage
- No authentication or authorization is required.

## Business Rules

- Price is stored as an integer in cents.
    - 1999 = $19.99
    - 500 = $5.00
    - 125050 = $1,250.50
- must be greater than or equal to 0.
- Frontend converts cents to a currency value for display.
- API accepts and returns prices in cents.
- Inventory price can differ from product price if inventory pricing changes independently.

## Models

```c#
public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    // Stored in cents
    public int Price { get; set; }
}

public class Inventory
{
    public int InventoryId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    // Stored in cents
    public int Price { get; set; }
}
```
## Database Design

```sql
CREATE TABLE Product (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    Price INT NOT NULL, -- Stored in cents
    CreatedDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Inventory (
    InventoryId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    Price INT NOT NULL, -- Stored in cents
    LastUpdated DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Inventory_Product
        FOREIGN KEY (ProductId)
        REFERENCES Product(Id)
);
```

## Frontend

```js
const displayPrice = (price / 100).toFixed(2);
```

## APIs

### Product Controller

- GET Products/{searchterm} (paginated)

- POST Product

```json
{
  "name": "Laptop",
  "description": "Gaming Laptop",
  "price": 120050
}
```

- PUT PRODUCT

```json
{
  "id": 1,
  "name": "Laptop",
  "description": "Gaming Laptop",
  "price": 120050
}
```

- DELETE PRODUCT/{id}

### Product Inventory

- GET Inventory/{searchterm} (paginated)

- POST Inventory

```json
{
  "productId": 1,
  "quantity": 100,
  "price": 120050
}
```

- PUT Inventory

```json
{
  "id": 1,
  "productId": 1,
  "quantity": 80,
  "price": 120050
}
```

- DELETE Inventory/{id}