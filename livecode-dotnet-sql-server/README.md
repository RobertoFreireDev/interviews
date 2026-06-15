## Challenge: Order Management System

- Estimated time: 90-120 minutes

## Business Requirement

An e-commerce company needs a feature to process customer orders.

When an order is placed:

- Validate customer exists
- Validate products exist
- Validate stock availability
- Create order
- Create order items
- Decrease stock
- Calculate order total
- Everything must be transactional

## Test

https://localhost:7046/swagger/index.html

```json
{
  "order": {
    "items": [
      {
        "productId": 1,
        "price": 120000,
        "quantity": 1
      }
    ],
    "totalPrice": 120000
  }
}
```

## You need a transaction.

The important point is not SaveChangesAsync(). EF Core already wraps a single SaveChangesAsync() in a transaction, but your code performs reads + validation + updates before calling SaveChangesAsync().

Without an explicit transaction:

- Read inventory
- Validate stock
- Another order modifies stock
- Your order continues
- SaveChanges

This can result in overselling inventory.

Your transaction ensures:

- Inventory rows remain locked (XLOCK)
- Validation uses a consistent view of the data
- Stock updates, order creation, and order items are committed atomically
- No other transaction can modify the locked inventory rows until commit/rollback

So the transaction is protecting the entire workflow, not just the final save.