# DotNet9WithSQLite

Welcome to the DotNet9WithSQLite project! This is a minimal API built with .NET 9 and SQLite. The project demonstrates how to create a simple yet powerful API using the latest features of .NET and a lightweight, file-based database.

## Features

- **Minimal API**: Utilizes the new minimal API feature in .NET 9 to create a simple and efficient API with minimal setup and configuration.
- **SQLite Integration**: Uses SQLite, a self-contained, serverless, and zero-configuration database engine, making it perfect for small to medium-sized applications.
- **Entity Framework Core**: Leverages EF Core for database operations, providing a robust and easy-to-use ORM for data access.
- **Dependency Injection**: Implements built-in dependency injection to manage service lifetimes and dependencies.
- **OpenAPI/Swagger**: Integrates Swagger for API documentation and testing, making it easy to explore and interact with the API endpoints.
- **Logging**: Configures logging to help with debugging and monitoring the application.

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQLite](https://www.sqlite.org/download.html)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/DotNet9WithSQLite.git
   ```
2. Navigate to the project directory:
   ```sh
   cd DotNet9WithSQLite
   ```
3. Restore the dependencies:
   ```sh
   dotnet restore
   ```

### Running the Application

1. Apply the database migrations:
   ```sh
   dotnet ef database update
   ```
2. Run the application:
   ```sh
   dotnet run
   ```

The API will be available at `https://localhost:5001` (or `http://localhost:5000`).

### API Endpoints

- `GET /items`: Retrieves a list of items.
- `GET /items/{id}`: Retrieves a specific item by ID.
- `POST /items`: Creates a new item.
- `PUT /items/{id}`: Updates an existing item by ID.
- `DELETE /items/{id}`: Deletes an item by ID.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Contact

For more information, visit my blog at [sma.im](https://sma.im). Stay updated with the latest tutorials, tips, and insights on software development.

Thank you for checking out DotNet9WithSQLite! Happy coding!
