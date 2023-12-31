# Project Documentation

This document provides an overview of the structure, design patterns and the endpoints available in this ASP.NET Core Web API, along with their descriptions and authentication requirements.

## Design Patterns and Middleware

### N-tier Architecture

- **Usage**: This project follows the N-tier architecture, which separates the application into distinct layers: Presentation (API controllers), Business Logic (Services), and Data Access (Repositories and Unit of Work). This architecture promotes modularity and maintainability.

### Generic Repository Pattern

- **Usage**: The Generic Repository pattern is employed to abstract data access operations. It provides a generic interface for CRUD (Create, Read, Update, Delete) operations on different data entities, making the data access layer more scalable and reusable.

### Unit of Work Pattern

- **Usage**: The Unit of Work pattern is used to manage transactions and ensure that data changes are consistent across multiple repositories. It allows multiple database operations to be treated as a single unit of work, helping maintain data integrity.

### Global Exception Handler Middleware

- **Usage**: A Global Exception Handler Middleware is implemented to centralize the handling of exceptions that occur during API requests. This middleware captures exceptions and returns appropriate error responses to clients, enhancing the reliability and maintainability of the API.

## Accounts Endpoints

### OpenAccount

- **HTTP Method:** POST
- **Endpoint:** `/api/accounts/openaccount`
- **Description:** Opens a "current account" for existing customers by providing the customerId (please use ids 1 and 3) and initialCredit .
- **Authentication:** No authentication required for this endpoint.

## Customers

### GetCustomerDetails

- **HTTP Method:** GET
- **Endpoint:** `/api/customers/GetCustomerDetails`
- **Description:** Get a customer's details (name, surname, balance, list of transactions)
- **Authentication:** No authentication required for this endpoint.

## Local Testing

To test these endpoints locally, follow these steps:

1. Restore the database backup in mssql.
2. Make sure .NET 8 is installed.
3. Clone the project repository.
4. Build and run the application.
5. Swagger UI will appear.
6. Test the endpoints.
