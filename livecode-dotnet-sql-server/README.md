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