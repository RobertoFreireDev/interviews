# Inventory Frontend Context

**Stack:** Angular 22 (standalone components, no NgModules)  
**Port:** http://localhost:4200  
**Root:** `inventory/`

## Run
```bash
cd inventory && npm run start
```

## Test
```bash
cd inventory && npm run test   # vitest (NOT Karma/Jasmine)
```

## Rules
- Price stored/sent as cents (integer). Display only divides by 100.
- This app owns the `Inventory` entity only.
- `Inventory.Price` may differ from `Product.Price` — never sync them.
