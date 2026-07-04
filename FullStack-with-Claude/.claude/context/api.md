# API Context

Base URL: `http://localhost:5000` (not yet running — .NET project in `api/`)

## Endpoints

| Method | Path | Body |
|--------|------|------|
| GET | `/Products/{searchterm}` | — |
| POST | `/Product` | `{ name, description, price }` |
| PUT | `/Product` | `{ id, name, description, price }` |
| DELETE | `/Product/{id}` | — |
| GET | `/Inventory/{searchterm}` | — |
| POST | `/Inventory` | `{ productId, quantity, price }` |
| PUT | `/Inventory` | `{ id, productId, quantity, price }` |
| DELETE | `/Inventory/{id}` | — |

## Price rule
All prices are **integers in cents** — never floats.  
`1999` = $19.99. Display: `(price / 100).toFixed(2)`.

## Models
```
Product   { Id, Name, Description, Price }
Inventory { InventoryId, ProductId, Quantity, Price }
```
Inventory.Price is independent from Product.Price — never auto-sync them.
