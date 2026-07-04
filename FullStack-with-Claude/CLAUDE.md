# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Inventory management system with three separate services:

- `products/` — React 19 + Vite frontend for Product CRUD (http://localhost:5173)
- `inventory/` — Angular 22 frontend for Inventory CRUD (http://localhost:4200)
- `api/` — .NET 10 Web API backend (Clean Architecture)
- SQL Server database (LocalDB for development)

## Commands

### React Frontend (`products/`)
```bash
cd products
npm install --force
npm run dev       # start dev server
npm run build     # production build
npm run lint      # eslint
npm run preview   # preview production build
```

### Angular Frontend (`inventory/`)
```bash
cd inventory
npm install --force
npm run start     # ng serve → http://localhost:4200
npm run build     # ng build
npm run test      # vitest
ng test           # also runs tests
```

## Key Business Rules

**Price is always stored as an integer in cents** — never floats.
- `1999` = $19.99, `120050` = $1,200.50
- Frontend display: `(price / 100).toFixed(2)`
- API accepts and returns prices in cents
- Inventory price is independent from product price (can diverge)

## API Contract

All prices in requests/responses are in cents.

| Method | Endpoint | Notes |
|--------|----------|-------|
| GET | `Products/{searchterm}` | Paginated |
| POST | `Product` | `{ name, description, price }` |
| PUT | `Product` | `{ id, name, description, price }` |
| DELETE | `Product/{id}` | |
| GET | `Inventory/{searchterm}` | Paginated |
| POST | `Inventory` | `{ productId, quantity, price }` |
| PUT | `Inventory` | `{ id, productId, quantity, price }` |
| DELETE | `Inventory/{id}` | |

## Data Models

```csharp
Product  { Id, Name, Description, Price (cents) }
Inventory { InventoryId, ProductId, Quantity, Price (cents) }
```

## API Backend (`api/`)

### Commands
```bash
cd api
dotnet build
dotnet run --project Api   # starts on http://5248 / https://7296
dotnet test                # run unit tests
```

### Project Structure (Clean Architecture)
```
api/
├── Api/          — Minimal API endpoints, DI wiring, exception handler
├── Application/  — Business logic, interfaces, DTOs, mapper
├── Domain/       — Pure domain entities (no dependencies)
├── Infra/        — EF Core DbContext, repositories, entity configs
└── Tests/        — xUnit + NSubstitute unit tests
```

### Key Details
- **Framework**: .NET 10, Minimal APIs (no controllers)
- **ORM**: Entity Framework Core 10 with SQL Server
- **Connection string**: `(localdb)\MSSQLLocalDB`, database `order`
- **DI registration lives in**: `Api/Extensions/IoC.cs`
- **Global exception handler**: `Api/Handlers/GlobalExceptionHandler.cs` — returns 500 JSON
- **Tests**: xUnit + NSubstitute (mock via `IProductRepository`)

### Currently Implemented
- `GET /Products/{searchterm}` — paginated product search (`?Page=1&PageSize=10`)

### Not Yet Implemented
- `POST /Product`, `PUT /Product`, `DELETE /Product/{id}`
- All Inventory endpoints

## Architecture Notes

The React app (`products/`) owns the Product entity; the Angular app (`inventory/`) owns the Inventory entity. Both talk to the same .NET backend. The `Inventory.Price` field allows inventory pricing to diverge from `Product.Price` — don't conflate them or auto-sync them.

All the infrastructure code, packages and references should be in Infra layer. Example: AddDbContext

The Angular project uses **standalone components** (Angular 22, no NgModules). Tests use **vitest** (not Karma/Jasmine).
