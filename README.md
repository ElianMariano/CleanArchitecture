# Clean Architecture

This repository is a personal interpretation of **Clean Architecture** built with **.NET**, focusing on maintainability, separation of concerns, and long-term scalability.

Rather than trying to provide a definitive implementation of Clean Architecture, this project demonstrates architectural decisions that prioritize **evolution**, **low coupling**, and **future migration paths**. The goal is to serve as a reference architecture that can be extended from a traditional monolithic application to more distributed approaches, such as **Event-Driven Architecture**, with minimal impact on the business layer.

---

# Architecture Overview

The solution is organized into independent projects, each with a well-defined responsibility.

## CleanArchitecture.Domain

The **Domain** project contains the business model and the core rules of the application.

This layer has no knowledge of infrastructure, persistence, web frameworks, or external services. It represents the most stable part of the system and should remain independent from technological decisions.

Responsibilities include:

* Entities
* Value Objects
* Domain Exceptions
* Domain Logic

---

## CleanArchitecture.Application

The **Application** project contains the application use cases.

In this project, use cases are implemented as **Handlers**, responsible for orchestrating domain operations without containing infrastructure concerns.

The Application layer depends only on abstractions and communicates with external components through interfaces.

Responsibilities include:

* Use Cases (Handlers)
* Application Services
* Business Orchestration
* Repository Interfaces
* Dependency Injection Contracts

---

## CleanArchitecture.Infrastructure

The **Infrastructure** project contains all implementation details that interact with external resources.

This includes:

* Entity Framework Core
* Database Context
* Repository Implementations
* Entity Mappings
* Persistence Configuration

Because Infrastructure depends on Application abstractions, persistence technologies can be replaced without affecting business rules.

---

## CleanArchitecture.Contracts

One architectural decision that differs from many traditional Clean Architecture implementations is the introduction of a dedicated Contracts project.

This project centralizes interfaces and contracts shared across application boundaries.

The primary goal is to reduce coupling between layers and establish clear boundaries between the different parts of the system. By isolating shared contracts, the application becomes easier to evolve and adapt to new architectural requirements over time.

Although this project was not created specifically for Event-Driven Architecture, this separation can facilitate future migrations or integrations with distributed systems by minimizing changes required in the core application layers.

While this additional project is not a requirement of Clean Architecture, it represents a design decision made to improve maintainability, extensibility, and long-term evolution of the solution.

---

## CleanArchitecture.Api

The **API** project is responsible only for exposing HTTP endpoints.

It contains:

* FastEndpoints endpoints
* FluentValidation validators
* Dependency Injection
* Application configuration
* Middleware configuration

The API layer contains no business logic. Its responsibility is limited to receiving requests, validating input, invoking the appropriate application use case, and returning the response.

---

# Design Decisions

## This is not "the" Clean Architecture

There is no single canonical implementation of Clean Architecture.

Different projects have different requirements, and architecture should reflect those requirements rather than blindly following templates.

This project represents an interpretation of Clean Architecture designed with future evolution in mind. The chosen structure favors loose coupling and enables migration toward distributed architectures with minimal impact on the business layer.

---

## Why there is no "Common" project for DTOs

Many Clean Architecture examples introduce an additional project called **Common**, containing Request and Response DTOs used by the Application layer.

This project intentionally avoids that approach.

The reason is that application requests frequently reference domain concepts. Moving them into a separate shared project would either:

* introduce unnecessary coupling between projects, or
* force the creation of artificial abstractions solely to satisfy project references.

Both options increase complexity without providing clear architectural benefits.

Instead, DTOs remain close to the application use cases they belong to, preserving dependency direction and reducing the risk of circular references.

---

# Features

## Structured Logging

Logging is implemented throughout the application to provide consistent diagnostics and facilitate troubleshooting.

The implementation follows the standard .NET logging abstractions, making it easy to integrate with providers such as:

* Console
* Seq
* Serilog
* Elasticsearch
* Azure Monitor

without requiring changes to the business layer.

---

## Global Error Handling

The application provides centralized exception handling.

Rather than allowing exceptions to propagate to the API layer, they are intercepted and converted into standardized HTTP responses.

This approach keeps endpoint implementations clean while ensuring a consistent error format across the application.

---

## Localization

The project supports localized error messages using **.NET Resource (.resx) files**, following the same localization approach recommended by Microsoft.

Currently supported languages:

* Portuguese (default)
* English

The language is selected through the standard HTTP **Accept-Language** request header.

Example:

```
Accept-Language: en-US
```

If no language is provided, the application falls back to Portuguese.

Adding support for additional languages only requires creating new resource files, making localization easy to extend without changing application code.

---

# Running the Project

## 1. Start Docker containers

```
docker-compose up -d
```

---

## 2. Configure PgAdmin

Login using the default credentials:

```
Email: admin@admin.com
Password: admin123
```

Register a new PostgreSQL server with the following settings:

```
Host: postgres_db
Username: admin
Password: admin123
```

---

## 3. Create the database

Run the Entity Framework migrations.

Create the initial migration:

```bash
dotnet ef migrations add InitialCreate \
    --project src/CleanArchitecture.Infrastructure \
    --startup-project src/CleanArchitecture.Api
```

Apply the migration:

```bash
dotnet ef database update \
    --project src/CleanArchitecture.Infrastructure \
    --startup-project src/CleanArchitecture.Api
```

---

# Roadmap

The following features are planned for future versions:

* Automated Unit Tests
* Integration Tests