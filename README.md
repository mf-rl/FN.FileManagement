# File Management API

A comprehensive .NET solution demonstrating **N-Tier/Clean Architecture** with Domain-Driven Design (DDD) principles for file upload and management operations.

## 🏗️ Architecture Overview

This solution implements a **layered N-tier architecture** with clear separation of concerns, following SOLID principles and dependency inversion. The architecture consists of 8 distinct projects, each with specific responsibilities:

```
┌─────────────────────────────────────────────────────┐
│  Presentation Layer                                 │
│  • FN.Web (Razor Pages)                            │
│  • FN.WebApi (REST API)                            │
│  • FN.WinForm (Desktop Client)                     │
└──────────────────┬──────────────────────────────────┘
                   │
┌──────────────────▼──────────────────────────────────┐
│  Application Layer                                  │
│  • FN.Application (Use Cases, Services, DTOs)      │
└──────────────────┬──────────────────────────────────┘
                   │
┌──────────────────▼──────────────────────────────────┐
│  Business Logic Layer                               │
│  • FN.Business (Domain Services, Business Rules)   │
└──────────────────┬──────────────────────────────────┘
                   │
┌──────────────────▼──────────────────────────────────┐
│  Data Access Layer                                  │
│  • FN.DataLayer (Repositories, EF Core Context)    │
└──────────────────┬──────────────────────────────────┘
                   │
┌──────────────────▼──────────────────────────────────┐
│  Cross-Cutting Concerns                            │
│  • FN.Entities (Domain Models, DTOs)               │
│  • FN.Common (Utilities, Extensions, Validators)   │
│  • FN.Functions (Shared Helper Functions)          │
└─────────────────────────────────────────────────────┘
```

## 📦 Project Structure

### **Presentation Layer**
- **FN.Web** - ASP.NET Core Razor Pages web application for browser-based UI
- **FN.WebApi** - RESTful API with Swagger/OpenAPI documentation
- **FN.WinForm** - Windows Forms desktop application for file uploads

### **Application Layer**
- **FN.Application** - Application services implementing use cases
  - Services: `UploadService`
  - Interfaces: `IUploadService`
  - Validators: FluentValidation implementations

### **Business Logic Layer**
- **FN.Business** - Core business logic and domain services
  - Services: `UploadDataService`
  - Abstractions: `IUploadDataService`
  - Coordinates between application and data layers

### **Data Access Layer**
- **FN.DataLayer** - Entity Framework Core implementation
  - Repositories (Generic Repository Pattern)
  - DbContext with in-memory database support
  - Data initialization and seeding

### **Cross-Cutting Concerns**
- **FN.Entities** - Domain models, DTOs, and data transfer objects
  - `UploadModel`, `UploadEntity`, `UploadedModel`, `UploadedEntity`
- **FN.Common** - Shared utilities, extensions, and validators
  - FluentValidation configurations
  - Custom validation extensions
  - String extensions and regex patterns
- **FN.Functions** - Utility functions for file operations
  - File upload/download handlers
  - Image resizing with ImageSharp
  - Content type detection

## 🔑 Key Features

### Architecture Patterns
- ✅ **N-Tier Architecture** - Clear separation of layers
- ✅ **Repository Pattern** - Abstraction over data access
- ✅ **Dependency Injection** - Built-in ASP.NET Core DI container
- ✅ **Interface Segregation** - Small, focused interfaces
- ✅ **Domain-Driven Design** - Rich domain models and services

### Technical Features
- ✅ **FluentValidation** - Model validation across layers
- ✅ **Entity Framework Core 10.0** - ORM with in-memory database
- ✅ **AutoMapper/Custom Mappers** - Object-to-object mapping
- ✅ **RESTful API** - Standard HTTP methods (GET, POST, DELETE)
- ✅ **Image Processing** - SixLabors.ImageSharp for image manipulation
- ✅ **Swagger/OpenAPI** - API documentation
- ✅ **Async/Await** - Asynchronous operations with CancellationToken support

## 🛠️ Technology Stack

- **.NET 10.0** - Target framework
- **ASP.NET Core** - Web framework
- **Entity Framework Core 10.0** - ORM
- **FluentValidation 12.1.1** - Validation library
- **SixLabors.ImageSharp** - Image processing
- **Newtonsoft.Json** - JSON serialization
- **Swagger/OpenAPI** - API documentation
- **Windows Forms** - Desktop UI

## 📋 API Endpoints

### Uploads Controller (`/api/uploads`)
- `GET /api/uploads` - Retrieve all uploads
- `GET /api/uploads/{id}` - Get upload by ID
- `GET /api/uploads/{id}/{fileName}` - View file details
- `POST /api/uploads` - Upload a new file
- `DELETE /api/uploads/{id}` - Delete an upload
- `GET /api/uploads/download/{fileName}` - Download file

## 🚀 Getting Started

### Prerequisites
- .NET 10.0 SDK
- Visual Studio 2022 or later / VS Code

### Running the Application

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Run the Web API**
   ```bash
   cd FN.WebApi
   dotnet run
   ```
   API will be available at: `https://localhost:5001` or `http://localhost:5000`

4. **Run the Web Application**
   ```bash
   cd FN.Web
   dotnet run
   ```

5. **Run the WinForms Application**
   ```bash
   cd FN.WinForm
   dotnet run
   ```

### Configuration

The solution uses `appsettings.json` for configuration:
- **UseInMemoryDatabase**: Toggle between in-memory and persistent database
- **UploadPath**: Configure file upload directory
- **Connection strings**: Configure database connections

## 🧪 Testing

The solution includes:
- FluentValidation for input validation
- In-memory database for testing scenarios
- Proper exception handling and error responses

## 📝 Development Guidelines

### Layer Dependencies
- **Presentation → Application → Business → Data**
- Each layer only depends on layers below it
- Common/Entities can be referenced from any layer
- No upward dependencies

### Adding New Features
1. Define domain models in `FN.Entities`
2. Create repository interface in `FN.DataLayer.Abstractions`
3. Implement repository in `FN.DataLayer.Repositories`
4. Create business service in `FN.Business.Services`
5. Create application service in `FN.Application.Services`
6. Add API endpoints in `FN.WebApi.Controllers`

## 🔗 Related Projects

**Frontend Example**: [Angular.Test.Web](https://github.com/YawarPandar/Angular.Test.Web.git) - Angular web application consuming this API

## 📄 License

This is a template/example project for demonstrating multitier architecture patterns.

## 👥 Contributing

This is a template project. Feel free to use it as a starting point for your own applications.

---

**Note**: This solution serves as an educational template demonstrating best practices in .NET application architecture, including proper separation of concerns, dependency management, and scalable design patterns.
