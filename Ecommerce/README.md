
# E-commerce Project

A modern and scalable e-commerce application developed with software development best practices and software architecture best practices.

## Technologies Used

- **Backend:** C# using .NET, segmented into microservices.
- **Frontend:** Next.js with micro frontends, following Atomic Design and dependent on Material UI.
- **API Gateway:** Leverages caching and rate limiting for maximum performance and enhanced security.

## Principles and Best Practices

- **DDD (Domain-Driven Design):** Structured the code based on business domains.
- **TDD (Test-Driven Development):** Ensures quality and stability with tests.
- **SOLID:** Principles for maintainable, modular design.
- **DRY (Don't Repeat Yourself):** Encourages code reuse and prevents duplication.

## Project Structure

- **Backend:** Microservices such as User, Product, Order, Payment, each separated into Domain, Application, Infrastructure, and Tests.
- **Frontend:** Structures components into atoms, molecules, organisms, and templates, enabling independent development of micro frontends.

## Additional Features

- **API Gateway Caching and Rate Limiting:** Enhances request performance and protects against abuse, e.g., denial-of-service (DoS) attacks.

The project was developed following industry standards and best practices to deliver a high-quality, scalable, and secure solution.
